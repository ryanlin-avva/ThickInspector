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
            textBox1.Text = ((Form1)fm1).DataFolder;

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

        public string get_data_folder()
        {
            return textBox1.Text;
        }
        public string get_basefilename()
        {
            return textBox2.Text;
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
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = openFileDialog1.FileName;
        }
    }
}
