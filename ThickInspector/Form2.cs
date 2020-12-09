using System;
using System.Windows.Forms;

namespace ThickInspector
{
    public partial class Form2 : Form
    {
        public Form fm1;
        public Form2()
        {
            InitializeComponent();            
        }

        public void InitParam()
        {
            cbxOrigin.Checked = ((Form1)fm1).IsRawDisplay();
            cbxNonZero.Checked = ((Form1)fm1).IsNzDisplay();
            cbxFilter.Checked = ((Form1)fm1).IsFilteredDisplay();
            tb_intense.Text = ((Form1)fm1).get_threshold();
            tb_cutoff.Text = ((Form1)fm1).get_cutoff();
            txbDataFolder.Text = ((Form1)fm1).DataFolder;
            txbBaseFile.Text = ((Form1)fm1).BaseFileName;
            cbxThick.Checked = ((Form1)fm1).MeasureThick;
            cbxFullScale.Checked = ((Form1)fm1).is_fullScale();
            tb_division.Text = ((Form1)fm1).get_thick_steps().ToString();
            tb_distance.Text = ((Form1)fm1).get_thick_distance().ToString();
            tb_halfHeight.Text = ((Form1)fm1).get_thick_half_height().ToString();
        }

        public int get_divisions()
        {
            return int.Parse(tb_division.Text);
        }
        public int get_distance()
        {
            return int.Parse(tb_distance.Text);
        }
        public float get_half_height()
        {
            return float.Parse(tb_halfHeight.Text);
        }
        public int get_intensity_per()
        {
            return int.Parse(tb_intense.Text);
        }

        public int get_cutoff_freq()
        {
            return int.Parse(tb_cutoff.Text);
        }
        public bool raw_data()
        {
            return cbxOrigin.Checked;
        }
        public bool nozero_displayed()
        {
            return cbxNonZero.Checked;
        }

        public bool need_filter()
        {
            return cbxFilter.Checked;
        }

        public bool measure_thick()
        {
            return cbxThick.Checked;
        }

        public bool is_full_scale()
        {
            return cbxFullScale.Checked;
        }

        public string get_data_folder()
        {
            return txbDataFolder.Text;
        }
        public string get_basefilename()
        {
            return txbBaseFile.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void tb_intense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txbDataFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txbBaseFile.Text = openFileDialog1.FileName;
        }
    }
}
