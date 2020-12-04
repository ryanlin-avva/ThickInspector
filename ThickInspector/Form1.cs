using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SInspector
{
    public partial class Form1 : Form
    {
        private ChartStyle cs3;
        private Draw3DBase drawBase3;
        private Draw3DChart draw3;
        private Draw3DSkin skin3;
        private DrawSection draw2;
        private DataSeries ds;
        private DraggableLine[] dl_array;
        private PointF startPos;
        private string initPath = null;
        private string paramFileName = "C:\\avva\\raptor.ini";
        private string paramFolderName = "C:\\avva";
        private string baseFileName = "C:\\avva\\base.data";
        public string DataFolder { get; set; }

        private int CurrentInspectPos { get; set; }
        private int PosMin { get; set; }
        private int PosMax { get; set; }
        private String DatafileName { get; set; }

        private float yBase;
        private int dl_num = 4;
        private Point MousePos { get; set; }

        public Form1()
        {
            InitializeComponent();
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            float ratio = area.Width / area.Height;
            int w, h;
            Point pos;
            if (ratio < 1.5)
            {
                h = (int)(area.Height * 0.9);
                w = (int)(h * 1.5);
                pos = new Point(w / 12, h / 12);
            }
            else
            {
                w = (int)(area.Width * 0.9);
                h = (int)(w / 1.5);
                pos = new Point(w / 12, h / 12);
            }
            this.Size = new Size(w, h);
            this.Location = pos;
            this.BackColor = Color.AliceBlue;

            cs3 = new ChartStyle();
            drawBase3 = new Draw3DBase(panel3D, cs3);

            draw3 = new Draw3DChart(panel3D, cs3);
            draw3.NumberInterp = 5;
            ColorMap cm = new ColorMap();
            draw3.CMap = cm.Jet();

            skin3 = new Draw3DSkin(panel3D);
            skin3.PlotBackColor = this.BackColor;
            skin3.PlotBorderColor = this.BackColor;

            //Init trackBar
            PosMin = 0;
            PosMax = 50000;
            DrawTrackBar();

            //Data Generation
            InitCSPara();
            ds = new DataSeries();
            //ds.Random3D(cs3);
            ds.DataLine.LineColor = Color.DarkBlue;
            ds.DataLine.Thickness = 1;
            panel3D.Paint += new PaintEventHandler(Plot3D);
            panel3D.BackColor = Color.Cornsilk;

            //ds.ZdataStat();
            lbAvg.Text = ds.Zavg.ToString("0.000");
            lbMax.Text = ds.Zmax.ToString("0.000");
            lbMin.Text = ds.Zmin.ToString("0.000");

            //2D view
            panel2D.Paint += new PaintEventHandler(Plot2D);
            panel2D.BackColor = Color.Azure;
            draw2 = new DrawSection(panel2D, cs3);


            //two sets of horizontal and vertical rulers
            dl_array = new DraggableLine[dl_num];
            dl_array[0] = new DraggableLine(new Pen(Color.Navy, 2), 0, true);
            dl_array[1] = new DraggableLine(new Pen(Color.Navy, 2), 0, false);
            dl_array[2] = new DraggableLine(new Pen(Color.DarkGreen, 2), 15, true);
            dl_array[3] = new DraggableLine(new Pen(Color.DarkGreen, 2), 15, false);
        }

        private void DrawTrackBar()
        {
            trkInspectPos.Maximum = PosMax;
            trkInspectPos.Minimum = PosMin;
            trkInspectPos.TickFrequency = (PosMax + PosMin) / 18;
            trkInspectPos.Value = (PosMax + PosMin) / 2;
            tbInspectPos.Text = trkInspectPos.Value.ToString();
        }
        private void Plot3D(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            drawBase3.CreateBase(g);
            draw3.AddChart(g, ds, skin3);
            //draw3.DrawPosPointer(e.Graphics, trkInspectPos.Value, ds.GetZValue(trkInspectPos.Value));
            //draw3.AddPosIndicator(e.Graphics, ds.YCoor2DispIndex(trkInspectPos.Value), ds.GetZValue(trkInspectPos.Value));
            draw3.AddPosIndicator(e.Graphics, trkInspectPos.Value, ds.GetZValue(trkInspectPos.Value));
            panel2D.Invalidate();
        }

        private void Plot2D(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            bool needReCalc = draw2.SetPlotArea(g);
            //draw2.CreateBase(g);
            draw2.AddChart(g, ds, trkInspectPos.Value);
            //if (draw2.IsCalibrated) btnCali.BackColor = SystemColors.ControlDark;
            //else btnCali.BackColor = SystemColors.ControlLight;
            for (int i = 0; i < dl_num; i++)
            {
                if (needReCalc)
                    dl_array[i].SetBoundary(draw2.PlotArea.Left, draw2.PlotArea.Right
                        , draw2.PlotArea.Top, draw2.PlotArea.Bottom, draw2.GetStyle());
                if (dl_array[i].Visible) dl_array[i].Draw(g);
            }
            if (dl_array[0].Visible)
            {
                tbBlueLength.Text = "(" + dl_array[0].LenStr + ", " + dl_array[1].LenStr + ")";
                Debug.WriteLine(tbBlueLength.Text);
            }
            else
                tbBlueLength.Text = "                        ";
            if (dl_array[2].Visible)
                tbGreenLength.Text = "(" + dl_array[2].LenStr + ", " + dl_array[3].LenStr + ")";
            else
                tbGreenLength.Text = "                        ";
        }

        private void panel3D_Resize(object sender, System.EventArgs e)
        {
            panel3D.Refresh();
        }

        private void trkInspectPos_Scroll(object sender, System.EventArgs e)
        {
            int value = trkInspectPos.Value;

            if (value != CurrentInspectPos)
            {
                tbInspectPos.Text = value.ToString();
                panel3D.Invalidate();
                CurrentInspectPos = value;
            }
        }

        private void tbInspectPos_KeyUp(object sender, KeyEventArgs e)
        {
            int value;
            if (Int32.TryParse(tbInspectPos.Text, out value))
            {
                if (value > PosMax) value = PosMax;
                else if (value < PosMin) value = PosMin;
                CurrentInspectPos = value;
                trkInspectPos.Value = value;
                panel3D.Invalidate();
            }
        }

        private void panel2D_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < dl_num; i++)
            {
                if (dl_array[i].Visible && dl_array[i].IsAtLine(e.Location))
                {
                    Debug.WriteLine("[panel2D_MouseDown] atline" + i.ToString());
                    dl_array[i].SetMousePos(e.Location);
                    dl_array[i].IsDragging = true;
                    return;
                }
            }
        }

        private void panel2D_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < dl_num; i++)
            {
                if (dl_array[i].IsDragging)
                {
                    //Debug.WriteLine("panel2D_MouseMove");
                    dl_array[i].SetMousePos(e.Location);
                    dl_array[i].Move();
                    panel2D.Invalidate();
                    return;
                }
            }
        }

        private void panel2D_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < dl_num; i++)
            {
                if (dl_array[i].IsDragging)
                {
                    Debug.WriteLine("-----MouseUp");
                    dl_array[i].IsDragging = false;
                    return;
                }
            }
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (ds.YArray == null || ds.YArray.Length == 0) return;

            float idx = ds.YArray[ds.ZmaxIndex()];
            trkInspectPos.Value = (int)(idx + 0.5);
            tbInspectPos.Text = idx.ToString();
            panel3D.Invalidate();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (ds.YArray == null || ds.YArray.Length == 0) return;
            float idx = ds.YArray[ds.ZminIndex()];
            trkInspectPos.Value = (int)(idx + 0.5);
            tbInspectPos.Text = idx.ToString();
            panel3D.Invalidate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select file";
            dialog.InitialDirectory = ".\\";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("File Open Error");
                return;
            }
            DatafileName = dialog.FileName;
            LoadDataFile(DatafileName);
        }

        private void LoadDataFile(string fname)
        {
            try
            {
                if (ds.BaseZ==0)
                {
                    MessageBox.Show("Haven't set base data file yet!!");
                    return;
                }

                initPath = fname;
                using (StreamReader file = new StreamReader(fname))
                {
                    int dataRowNum = 0;
                    int xNumber = 0;
                    string dataLine;
                    dataLine = file.ReadLine(); //row number
                    dataRowNum = Convert.ToInt32(dataLine);
                    dataLine = file.ReadLine(); //scan interval
                    xNumber = Convert.ToInt32(dataLine);
                    dataLine = file.ReadLine(); //scribe line is parallet to scan line
                    ds.ParallelDisplay = (Convert.ToInt32(dataLine) == 1) ? true : false;
                    dataLine = file.ReadLine();
                    ds.EncoderZ = Convert.ToInt32(dataLine)-ds.BaseZ;
                    if (!ds.ParallelDisplay)
                    {
                        cs3.YLabel = "X";
                        cs3.XLabel = "Y";
                    }
                    int distance = Constants.DotDistance;
                    if (xNumber == 5)
                    {
                        xNumber = Constants.DotNumber;
                    } 
                    else
                    {
                        distance = Constants.DotDistance / 5;
                        xNumber = Constants.DotNumber * 5;
                    }
                    if (dataRowNum > ds.BaseRowNumber 
                        || xNumber > ds.BaseColNumber)
                    {
                        MessageBox.Show("Base data area is smaller than sample");
                        return;
                    }
                    if (ds.ParallelDisplay)
                    {
                        ds.ArraysAlloc(xNumber, dataRowNum);
                        for (int z = 0; z < xNumber; z++)
                        {
                            ds.YArray[z] = z * distance;
                        }
                        for (int z = 0; z < dataRowNum; z++)
                        {
                            ds.XArray[z] = z;
                        }
                    }
                    else
                    {
                        ds.ArraysAlloc(dataRowNum, xNumber);
                        for (int z = 0; z < xNumber; z++)
                        {
                            //xArray，等距 (5um) 排列
                            ds.XArray[z] = z * distance;

                        }
                        yBase = 0;
                    }

                    for (int i = 0; i < dataRowNum; i++)
                    {
                        dataLine = file.ReadLine();
                        if (dataLine == null)
                        {
                            MessageBox.Show("total Row = " + i.ToString()
                                + " not match target = " + dataRowNum.ToString());
                            return;
                        }
                        float[] data = Array.ConvertAll(dataLine.Split(','), float.Parse);
                        if (i == 0)
                        {
                            yBase = data[0];
                            ds.YBase = yBase;
                            ds.XBase = data[1];
                        }
                        if (!ds.ParallelDisplay)
                        {
                            //以um為單位，起點為0
                            ds.YArray[i] = data[0] - yBase;
                        }

                        if (data.Length < xNumber + 2)
                        {
                            MessageBox.Show("Data Row " + i.ToString()
                                + " Parsing Error, Total number = " + data.Length.ToString());
                            return;
                        }
                        //Must set XArray value first
                        //Otherwise ZArray will have zero in point.x value
                        for (int z = 0; z < xNumber; z++)
                        {
                            if (ds.ParallelDisplay)
                            {
                                ds.SetZArray(z, i, data[z + 2], data[0]);
                                ds.SetInsArray(z, i, data[z + 2 + xNumber]);
                            }
                            else
                            {
                                ds.SetZArray(i, z, data[z + 2], data[0]);
                                ds.SetInsArray(i, z, data[z + 2 + xNumber]);
                            }
                        }
                        if (i == 0) startPos = new PointF(data[0], data[1]);
                    }

                    SetDataProfile();
                    PosMin = (int)ds.YArray[0];
                    PosMax = (int)ds.YArray[ds.YArray.Length - 1];
                    lbStartPos.Text = String.Format("起始座標 ({0,8:F3}, {1,8:F3}) mm", startPos.X / 1000.0f, startPos.Y / 1000.0f);
                    DrawTrackBar();
                    for (int i = 0; i < dl_num; i++)
                    {
                        dl_array[i].Visible = false;
                    }
                    panel3D.Invalidate();
                }
        }
            catch (Exception e)
            {
                MessageBox.Show(fname + " Open Fail: " + e.Message);
            }
        }
        private void LoadBaseFile(string fname)
        {
            try
            {
                initPath = fname;
                using (StreamReader file = new StreamReader(fname))
                {
                    int dataRowNum = 0;
                    int xNumber = 0;
                    string dataLine;
                    dataLine = file.ReadLine(); //row number
                    dataRowNum = Convert.ToInt32(dataLine);
                    dataLine = file.ReadLine(); //scan interval
                    xNumber = Convert.ToInt32(dataLine);
                    dataLine = file.ReadLine(); //scribe line is parallet to scan line
                    //ds.ParallelDisplay = (Convert.ToInt32(dataLine) == 1) ? true : false;
                    ds.ParallelDisplay = false; //Use vertical to display
                    dataLine = file.ReadLine();
                    ds.BaseZ = Convert.ToInt32(dataLine);
                    int distance = Constants.DotDistance;
                    if (xNumber == 5)
                    {
                        xNumber = Constants.DotNumber;
                    }
                    else
                    {
                        distance = Constants.DotDistance / 5;
                        xNumber = Constants.DotNumber * 5;
                    }
                    if (ds.ParallelDisplay)
                    {
                        ds.BaseArrayAlloc(xNumber, dataRowNum);
                        for (int z = 0; z < xNumber; z++)
                        {
                            ds.BaseYArray[z] = z * distance;
                        }
                    }
                    else
                    {
                        ds.ArraysAlloc(dataRowNum, xNumber);
                    }

                    for (int i = 0; i < dataRowNum; i++)
                    {
                        dataLine = file.ReadLine();
                        if (dataLine == null)
                        {
                            MessageBox.Show("total Row = " + i.ToString()
                                + " not match target = " + dataRowNum.ToString());
                            return;
                        }
                        float[] data = Array.ConvertAll(dataLine.Split(','), float.Parse);
                        if (!ds.ParallelDisplay)
                        {
                            //以um為單位，起點為0
                            ds.BaseYArray[i] = data[0];
                        }

                        if (data.Length < xNumber + 2)
                        {
                            MessageBox.Show("Data Row " + i.ToString()
                                + " Parsing Error, Total number = " + data.Length.ToString());
                            return;
                        }
                        //Must set XArray value first
                        //Otherwise ZArray will have zero in point.x value
                        for (int z = 0; z < xNumber; z++)
                        {
                            if (ds.ParallelDisplay)
                            {
                                ds.SetBaseZArray(z, i, data[z + 2]);
                            }
                            else
                            {
                                ds.SetBaseZArray(i, z, data[z + 2]);
                            }
                        }
                        if (i == 0) startPos = new PointF(data[0], data[1]);
                    }
                    ds.RemoveBaseZero();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(fname + " Open Fail: " + e.Message);
            }
        }

        private void SetDataProfile()
        {
            String path = DataFolder + "\\" + Path.GetFileNameWithoutExtension(initPath);
            ds.DataArrange(path);

            //Data Boundary
            lbAvg.Text = ds.Zavg.ToString("0.000");
            lbMax.Text = ds.Zmax.ToString("0.000");
            lbMin.Text = ds.Zmin.ToString("0.000");

            //Chart Boundary
            cs3.XMin = 0;
            cs3.XMax = ds.XArray[ds.ColNumber - 1] - ds.XArray[0]; ;
            cs3.YMin = 0;
            cs3.YMax = ds.YArray[ds.RowNumber - 1] - ds.YArray[0];
            cs3.XTick = cs3.XMax / Constants.Draw3DXTickNumber;
            cs3.YTick = cs3.YMax / Constants.Draw3DYTickNumber;
            cs3.ZMin = ds.Zmin - Constants.Draw3DZAxisPadding;
            if (cs3.ZMin < 0) cs3.ZMin = 0;
            cs3.ZMax = ds.Zmax + Constants.Draw3DZAxisPadding;
            cs3.ZTick = (cs3.ZMax - cs3.ZMin) / Constants.Draw3DZTickNumber;
            draw2.UpdateChartStyle(cs3);
        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save Data File";
            saveFileDialog1.Filter = "Bitmap Image|*.bmp";
            saveFileDialog1.ShowDialog();
            MessageBox.Show(saveFileDialog1.FileName);
        }

        private void InitCSPara()
        {
            cs3.XMin = 0f;
            cs3.XMax = 200f;
            cs3.YMin = 0f;
            cs3.YMax = PosMax;
            cs3.ZMin = 0;
            cs3.ZMax = 220;
            cs3.XTick = 30f;
            cs3.YTick = cs3.YMax / Constants.Draw3DYTickNumber;
            cs3.ZTick = 40;
            cs3.GridColor = Color.LightGray;
            cs3.GridStyle = DashStyle.Dash;
            cs3.AxisThickness = 2f;
            cs3.AxisColor = Color.OliveDrab;

            cs3.TickFont = new Font("Arial Narrow", 8, FontStyle.Regular);
            cs3.TickColor = Color.Black;

            cs3.Title = "3D View";
            cs3.TitleFont = new Font("Arial Narrow", 12, FontStyle.Bold);
            cs3.TitleColor = Color.DarkSlateGray;
            cs3.Title2 = "Cross Section";

            cs3.LabelFont = new Font("Arial Narrow", 10, FontStyle.Regular);
            cs3.LabelColor = Color.Black;

            cs3.Elevation = Constants.Draw3DElevation;
            cs3.Azimuth = Constants.Draw3DAzimuth;

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            int step = Convert.ToInt32(tbStep.Text);
            int value = trkInspectPos.Value;
            if (value == PosMax) return;
            int newPos = value + step;
            if (newPos > PosMax) newPos = PosMax;
            tbInspectPos.Text = newPos.ToString();
            trkInspectPos.Value = newPos;
            panel3D.Invalidate();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            int step = Convert.ToInt32(tbStep.Text);
            int value = trkInspectPos.Value;
            if (value == PosMin) return;
            int newPos = value - step;
            if (newPos < PosMin) newPos = PosMin;
            tbInspectPos.Text = newPos.ToString();
            trkInspectPos.Value = newPos;
            panel3D.Invalidate();
        }
        public bool IsRawDisplay()
        {
            return draw2.RawDisplay;
        }
        public bool IsNzDisplay()
        {
            return draw2.NoZeroDisplay;
        }
        public bool IsFilteredDisplay()
        {
            return draw2.FilteredDisplay;
        }

        public string get_threshold()
        {
            return ds.Threshold.ToString();
        }

        public string get_cutoff()
        {
            return ds.CutoffFreq.ToString();
        }
        private void btnSetParam_Click(object sender, EventArgs e)
        {
            using (Form2 f2 = new Form2())
            {
                f2.fm1 = this;
                f2.InitParam();
                f2.ShowDialog();
                ds.Threshold = f2.get_intensity_per();
                draw2.RawDisplay = f2.raw_data();
                draw2.NoZeroDisplay = f2.nozero_displayed();
                draw2.FilteredDisplay = f2.need_filter();
                ds.CutoffFreq = f2.get_cutoff_freq();
                DataFolder = f2.get_data_folder();
                string basefile = f2.get_basefilename();
                if (basefile != baseFileName)
                {
                    LoadBaseFile(basefile);
                    baseFileName = basefile;
                }
                WriteParaFile();
                panel3D.Invalidate();
            }

        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            if (dl_array[2].Visible == false)
            {
                dl_array[2].Visible = true;
                dl_array[3].Visible = true;
            }
            else
            {
                dl_array[2].Visible = false;
                dl_array[3].Visible = false;
            }
            panel2D.Invalidate();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            if (dl_array[0].Visible == false)
            {
                dl_array[0].Visible = true;
                dl_array[1].Visible = true;
            }
            else
            {
                dl_array[0].Visible = false;
                dl_array[1].Visible = false;
            }
            panel2D.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadParaFile();
            LoadBaseFile(baseFileName);
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                initPath = args[1];
                LoadDataFile(initPath);
            }
        }

        private void WriteParaFile()
        {
            using (StreamWriter outputFile = new StreamWriter(paramFileName))
            {
                String text = "Threshold:" + ds.Threshold.ToString();
                outputFile.WriteLine(text);
                text = "Cutoff:" + ds.CutoffFreq.ToString();
                outputFile.WriteLine(text);
                text = "RawDisplay:" + draw2.RawDisplay.ToString();
                outputFile.WriteLine(text);
                text = "NoZeroDisplay:" + draw2.NoZeroDisplay.ToString();
                outputFile.WriteLine(text);
                text = "FilteredDisplay:" + draw2.FilteredDisplay.ToString();
                outputFile.WriteLine(text);
                text = "DataSavePath:" + DataFolder;
                outputFile.WriteLine(text);
                text = "BaseFileName:" + baseFileName;
                outputFile.WriteLine(text);
            }
        }
        private void ReadParaFile()
        {
            Directory.CreateDirectory(paramFolderName);
            if (!File.Exists(paramFileName)) //Set default
            {
                ds.Threshold = 120;
                ds.CutoffFreq = 30;
                draw2.NoZeroDisplay = true;
                draw2.RawDisplay = false;                
                draw2.FilteredDisplay = false; 
                DataFolder = paramFolderName;
                return;
            }
            using (StreamReader file = new StreamReader(paramFileName))
            {
                while (!file.EndOfStream)
                {
                    String dataLine = file.ReadLine(); //row number
                    int idx = dataLine.IndexOf(":");
                    String key = dataLine.Substring(0, idx);
                    switch (key)
                    {
                        case "Threshold":
                            ds.Threshold = Convert.ToInt32(dataLine.Substring(idx + 1));
                            break;
                        case "Cutoff":
                            ds.CutoffFreq = Convert.ToInt32(dataLine.Substring(idx + 1));
                            break;
                        case "NoZeroDisplay":
                            draw2.NoZeroDisplay = Convert.ToBoolean(dataLine.Substring(idx + 1));
                            break;
                        case "RawDisplay":
                            draw2.RawDisplay = Convert.ToBoolean(dataLine.Substring(idx + 1));
                            break;
                        case "FilteredDisplay":
                            draw2.FilteredDisplay = Convert.ToBoolean(dataLine.Substring(idx + 1));
                            break;
                        case "DataSavePath":
                            DataFolder = dataLine.Substring(idx + 1);
                            break;
                        case "BaseFileName":
                            baseFileName = dataLine.Substring(idx + 1);
                            break;
                    }
                }
            }
        }
    }
}
