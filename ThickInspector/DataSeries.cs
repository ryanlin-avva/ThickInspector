using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using System;

namespace ThickInspector
{
    class DataSeries
    {
        public float Xspacing { get; set; }
        public float Yspacing { get; set; }
        public int ColNumber { get; set; } //Real Number of Points in a row
        public int RowNumber { get; set; } //Real Number of rows
        public int BaseColNumber { get; set; } //Real Number of Points in a row
        public int BaseRowNumber { get; set; } //Real Number of rows
        public int DispColNumber { get; set; } //Display Number of Points in a row，最大為70點
        public int DispRowNumber { get; set; } //Display Number of rows，最大為70點
        private Point3[,] p3Array; //data array for display，[x, y]=[DispXnumber, DispYnumber]
        private Point[,] p3ToReal;
        private float[,] oriData; //data array from input，[row, col]=[總筆數, 192(*5)]
        private float[,] nzData; //data array with zero removed
        private float[,] lpfData; //data array after low-pass filter
        private float[,] insData; //intensity array from input，[row, col]=[總筆數, 192(*5)]
        private float[,] baseData; //data array as base
        public int[] XArray { get; set; } //length=192，value=[0, 970]，間隔=5
        public int[] YArray { get; set; } //length=input總筆數
        public int[] BaseYArray { get; set; } //length=Base總筆數
        public float Zmin { get; set; }
        public float Zmax { get; set; }
        public float Zavg { get; set; }
        public float Zdistance { get; set; }
        public float XBase { get; set; }
        public float YBase { get; set; }
        public int EncoderZ;
        public int BaseZ;
        public bool ParallelDisplay { get; set; }
        public int Threshold = 120;
        public int CutoffFreq = 30;

        private List<int> zmaxIndexList;
        private List<int> zminIndexList;
        private int minIdx = 0;
        private int maxIdx = 0;

        public void SetBaseZArray(int r, int c, float v)
        {
            baseData[r,c] = v;
        }
        public void SetZArray(int r, int c, float v, int y)
        {
            int idx;
            idx = r;
            if (y != BaseYArray[r])
            {
                int start_idx = Math.Max(r - 3, 0);
                int end_idx = Math.Min(r + 3, BaseYArray.Length);
                for (int i = start_idx; i < end_idx; i++)
                {
                    if (y >= BaseYArray[r])
                    {
                        idx = r;
                        break;
                    }
                }
            }
            oriData[r, c] = Math.Max(v - baseData[r, c] + EncoderZ, 0);
        }
        public void SetInsArray(int r, int c, float v)
        {
            insData[r, c] = v;
        }

        public int ZminIndex() 
        {
            if (zminIndexList.Count == minIdx) minIdx = 0;
            return zminIndexList[minIdx++];
        }
        public int ZmaxIndex() 
        {
            if (zmaxIndexList.Count == maxIdx) maxIdx = 0;
            return zmaxIndexList[maxIdx++];
        }

        public float GetZValue(int r)
        {
            if (nzData == null) return 0;
            return nzData[FindIndex(r), 0];
            //return p3Array[YCoor2DispIndex(r), 0].Z;
        }

        public DataStyle DataLine { get; set; }

        public DataSeries()
        {
            Xspacing = 5;
            Yspacing = 50;
            ColNumber = 20;
            RowNumber = 40;
            DataLine = new DataStyle();
            zmaxIndexList = new List<int>();
            zminIndexList = new List<int>();
        }

        public void DataArrange(string datapath)
        {
            CreateNoZeroArray();
            SaveNoneZeroData(datapath + ".ori");
            CreateFilteredArray();
            //CreateAndSaveFilteredArray(datapath);
            ZdataStat();
            MakeP3Array();
            //SaveP3Array(datapath + ".p3");
        }
        public void RemoveBaseZero()
        {
            for (int i = 0; i < BaseRowNumber; i++)
            {
                int start_idx = 0;
                int leading_zero = 0;
                for (int z = 0; z < BaseColNumber; z++)
                {
                    if (baseData[i, z] != 0) break;
                    leading_zero++;
                }
                if (leading_zero == BaseColNumber)
                {
                    for (int j = 0; j < BaseColNumber; j++)
                    {
                        baseData[i, j] = 0;
                    }
                    continue;
                }
                start_idx = leading_zero;
                for (int j = start_idx + 1; j < BaseColNumber; j++)
                {
                    if (baseData[i, j] == 0 )
                        continue;
                    if (start_idx + 1 < j)
                    {
                        float inc = (baseData[i, j] - baseData[i, start_idx]) / (j - start_idx);
                        float h = baseData[i, start_idx];
                        for (int k = start_idx + 1; k < j; k++)
                        {
                            h += inc;
                            baseData[i, k] = h;
                        }
                    }
                    start_idx = j;
                }
                //leading_zero substract one if out of range
                if (leading_zero >= BaseColNumber) leading_zero = BaseColNumber - 1;
                //remove starting zero
                for (int j = 0; j < leading_zero; j++)
                    baseData[i, j] = baseData[i, leading_zero];
                //remove trailing zero
                for (int j = start_idx + 1; j < BaseColNumber; j++)
                {
                    baseData[i, j] = baseData[i, start_idx];
                }
            }
        }
        private void CreateNoZeroArray()
        {
            for (int i = 0; i < RowNumber; i++)
            {
                int start_idx = 0;
                int leading_zero = 0;
                for (int z = 0; z < ColNumber; z++)
                {
                    if (oriData[i, z] != 0 && insData[i, z] > Threshold) break;
                    leading_zero++;
                }
                if (leading_zero == ColNumber)
                {
                    for (int j = 0; j < ColNumber; j++)
                    {
                        nzData[i, j] = 0;
                    }
                    continue;
                }
                start_idx = leading_zero;
                nzData[i, start_idx] = oriData[i, start_idx];
                for (int j = start_idx+1; j < ColNumber; j++)
                {
                    if (oriData[i, j] == 0 || insData[i, j] < Threshold)
                        continue;
                    if (start_idx + 1 < j)
                    {
                        float inc = (oriData[i, j] - oriData[i, start_idx]) / (j - start_idx);
                        float h = oriData[i, start_idx];
                        for (int k = start_idx + 1; k < j; k++)
                        {
                            h += inc;
                            nzData[i, k] = h;
                        }
                    }
                    nzData[i, j] = oriData[i, j];
                    start_idx = j;
                }
                if (leading_zero >= ColNumber) leading_zero = ColNumber - 1;
                //remove starting zero
                for (int j = 0; j < leading_zero; j++)
                    nzData[i, j] = oriData[i, leading_zero];
                //remove trailing zero
                for (int j = start_idx+1; j < ColNumber; j++)
                {
                    nzData[i, j] = oriData[i, start_idx];
                }
            }
        }

        public void SaveNoneZeroData(string path)
        {
            //try
            //{
                using (StreamWriter file = new StreamWriter(path))
                {
                    int dataRow = nzData.GetLength(0);
                    int dataCol = nzData.GetLength(1);
                    int gap = (dataCol == Constants.DotNumber) ? 5 : 1;
                    file.WriteLine(dataRow.ToString());
                    file.WriteLine(gap.ToString());
                    file.WriteLine((ParallelDisplay) ? "1" : "0");
                    for (int row = 0; row < dataRow; row++)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(YArray[row] + YBase);
                        sb.Append(",");
                        sb.Append(XBase);
                        sb.Append(",");
                        for (int i = 0; i < dataCol-1; i++)
                        {
                            sb.Append(nzData[row, i]);
                            sb.Append(",");
                        }
                        sb.Append(nzData[row, dataCol - 1]);
                        file.WriteLine(sb);
                    }
                }
            //}
            //catch (Exception e)
            //{
            //   Console.WriteLine(path + " Open Fail: " + e.Message);
            //}

        }
        public void SaveP3Array(string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                for (int row = 0; row < DispRowNumber; row++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < DispColNumber-1; i++)
                    {
                        sb.Append(p3Array[row, i]
                            +"(" + p3ToReal[row, i].X + "," + p3ToReal[row, i].Y + ")");
                        sb.Append(",");
                    }
                    sb.Append(p3Array[row, DispColNumber - 1]);
                    file.WriteLine(sb);
                }
            }
        }
        private void MakeP3Array()
        {
            if (XArray == null || XArray.Length == 0) return;

            Xspacing = XArray.Length / (float)DispColNumber;
            Yspacing = YArray.Length / (float)DispRowNumber;

            for (int i = 0; i < DispColNumber; i++)
            {
                for (int j = 0; j < DispRowNumber; j++)
                {
                    int row = (int)(j * Yspacing);
                    if (row >= RowNumber) row = RowNumber - 1;
                    int col = (int)(i * Xspacing);
                    if (col >= ColNumber) col = ColNumber - 1;
                    float height = nzData[row, col];
                    if (height == 0) height = Zmin;
                    p3Array[i, j] = new Point3(XArray[col], YArray[row], height, 1);
                    p3ToReal[i, j] = new Point(row, col);
                }
            }
        }

        private void CreateFilteredArray()
        {
            LowpassButterworth butter
                    = new LowpassButterworth(CutoffFreq, 1, ColNumber);
            for (int i=0; i<RowNumber; i++)
            {
                PointF[] pts = GetNZeroDataSet(i);
                for (int j = 0; j < pts.Length - 1; j++)
                {
                    lpfData[i,j] = (float)butter.compute(pts[j].Y);
                }

            }
        }
        private void CreateAndSaveFilteredArray(string path)
        {
            Process p = new Process();
            p.StartInfo.FileName = "filter1.exe";//需要執行的檔案路徑
            p.StartInfo.UseShellExecute = false; //必需
            p.StartInfo.RedirectStandardOutput = true;//輸出引數設定
            p.StartInfo.RedirectStandardInput = false;//傳入引數設定
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = path;//引數以空格分隔，如果某個引數為空，可以傳入””
            p.Start();
            p.StandardOutput.ReadToEnd();
            p.WaitForExit();//關鍵，等待外部程式退出後才能往下執行
            ReadFilteredData(path+".cvs");
            p.Close();
        }
        private void ReadFilteredData(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                int i = 0;
                while (!file.EndOfStream)
                {
                    string dataLine = file.ReadLine();
                    float[] data = Array.ConvertAll(dataLine.Split(','), float.Parse);
                    if (i==0) 
                    for (int z = 0; z < data.Length; z++)
                    {
                        if (ParallelDisplay)
                        {
                            lpfData[z, i] = data[z];
                        }
                        else
                        {
                            lpfData[i, z] = data[z];
                        }
                    }
                    i++;
                }
            }
        }

        public int YCoor2DispIndex(int pos)
        {
            int idx = DispRowNumber;
            for (int i = 0; i < DispRowNumber; i++)
            {
                if (p3Array[0, i].Y > pos)
                {
                    idx = i;
                    break;
                }
            }
            if (idx == DispRowNumber)
            {
                idx--;
            }
            //return DispRowNumber-idx;
            return idx;
        }
        public Point3[,] CloneDataSet()
        {
            Point3[,] p = new Point3[DispColNumber, DispRowNumber];
            for (int i=0; i < DispColNumber; i++)
            {
                for (int j=0; j< DispRowNumber; j++)
                {
                    p[i, j] = new Point3(p3Array[i, j]);
                }
            }
            return p;
        }

        public PointF[] GetOriDataSet(int y, bool isIdx=false)
        {
            int idx = y;
            if (!isIdx) idx = FindIndex(y);

            PointF[] data = new PointF[ColNumber];

            for (int i = 0; i < ColNumber; i++)
            {
                data[i] = new PointF(XArray[i], oriData[idx, i]);
            }
            return data;
        }
        public PointF[] GetNZeroDataSet(int y, bool isIdx = false)
        {
            int idx = y;
            if (!isIdx) idx = FindIndex(y);

            PointF[] data = new PointF[ColNumber];

            for (int i = 0; i < ColNumber; i++)
            {
                data[i] = new PointF(XArray[i], nzData[idx, i]);
            }
            return data;
        }

        public PointF[] GetFilteredDataSet(int y, bool isIdx = false)
        {
            int idx = y;
            if (!isIdx) idx = FindIndex(y);

            PointF[] data = new PointF[ColNumber];

            for (int i = 0; i < ColNumber; i++)
            {
                data[i] = new PointF(XArray[i], lpfData[idx, i]);
            }
            return data;
        }

        //Find the index associated with value y
        private int FindIndex(int y)
        {
            //if (YArray[0] y) return 0;
            for (int i = 0; i < RowNumber; i++)
            {
                if (YArray[i] > y) return i - 1;
            }
            return RowNumber - 1;
        }
        private void ZdataStat()
        {
            Zmax = nzData[0,0];
            Zmin = 32767;
            float sum = 0;
            for (int j = 0; j < RowNumber; j++)
            {
                for (int i = 0; i < ColNumber; i++)
                {
                    if (Zmax < nzData[j,i])
                    {
                        Zmax = nzData[j,i];
                        zmaxIndexList.Clear();
                        zmaxIndexList.Add(j);
                    } 
                    if (nzData[j, i] == 0) continue;
                    if (Zmin > nzData[j,i])
                    {
                        Zmin = nzData[j,i];
                        zminIndexList.Clear();
                        zminIndexList.Add(j);
                    }
                    sum += nzData[j,i];
                }
            }
            //Handle horizontal line case
            if (Zmin == Zmax)
            {
                Zmin = Zmin - 0.5F;
                Zmax = Zmax + 0.5F;
            } 
            else
            {
                for (int j = 0; j < RowNumber; j++)
                    for (int i = 0; i < ColNumber; i++)
                    {
                        if (Zmax == nzData[j, i])
                        {
                            zmaxIndexList.Add(j);
                        }
                        if (Zmin == nzData[j, i])
                        {
                            zminIndexList.Add(j);
                        }
                    }
            }

            Zavg = sum / (ColNumber * RowNumber);
            Zdistance = Zmax - Zmin;
        }

        public void ArraysAlloc(int r, int c)
        {
            ColNumber = c;
            RowNumber = r;

            oriData = new float[RowNumber, ColNumber];
            nzData = new float[RowNumber, ColNumber];
            lpfData = new float[RowNumber, ColNumber];
            insData = new float[RowNumber, ColNumber];
            XArray = new int[ColNumber];
            YArray = new int[RowNumber];

            DispColNumber = (Constants.Draw3DXPointTotal > ColNumber)
                        ? ColNumber : Constants.Draw3DXPointTotal;
            DispRowNumber = (Constants.Draw3DYPointTotal > RowNumber)
                        ? RowNumber : Constants.Draw3DYPointTotal;
            p3Array = new Point3[DispColNumber, DispRowNumber];
            p3ToReal = new Point[DispColNumber, DispRowNumber];
        }
        public void BaseArrayAlloc(int r, int c)
        {
            BaseColNumber = c;
            BaseRowNumber = r;

            baseData = new float[BaseRowNumber, BaseColNumber];
            BaseYArray = new int[BaseRowNumber];
        }
    }
}
