namespace SInspector
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_intense = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxOrigin = new System.Windows.Forms.CheckBox();
            this.cbxNonZero = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxFilter = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tb_cutoff = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(43, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Intensity Threshold";
            // 
            // tb_intense
            // 
            this.tb_intense.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_intense.Location = new System.Drawing.Point(234, 47);
            this.tb_intense.Name = "tb_intense";
            this.tb_intense.Size = new System.Drawing.Size(143, 35);
            this.tb_intense.TabIndex = 1;
            this.tb_intense.Text = "120";
            this.tb_intense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_intense_KeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(50, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(80, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Original Data (zero included)";
            // 
            // cbxOrigin
            // 
            this.cbxOrigin.AutoSize = true;
            this.cbxOrigin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxOrigin.Location = new System.Drawing.Point(50, 182);
            this.cbxOrigin.Name = "cbxOrigin";
            this.cbxOrigin.Size = new System.Drawing.Size(14, 13);
            this.cbxOrigin.TabIndex = 4;
            this.cbxOrigin.UseVisualStyleBackColor = true;
            // 
            // cbxNonZero
            // 
            this.cbxNonZero.AutoSize = true;
            this.cbxNonZero.Checked = true;
            this.cbxNonZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxNonZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxNonZero.Location = new System.Drawing.Point(50, 248);
            this.cbxNonZero.Name = "cbxNonZero";
            this.cbxNonZero.Size = new System.Drawing.Size(14, 13);
            this.cbxNonZero.TabIndex = 6;
            this.cbxNonZero.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(80, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Non-Zero Data";
            // 
            // cbxFilter
            // 
            this.cbxFilter.AutoSize = true;
            this.cbxFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFilter.Location = new System.Drawing.Point(50, 312);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(14, 13);
            this.cbxFilter.TabIndex = 8;
            this.cbxFilter.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(80, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Low Pass Filtered Data";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(50, 408);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(618, 35);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "C:/avva";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(674, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 10;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(46, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Set Data Folder";
            // 
            // tb_cutoff
            // 
            this.tb_cutoff.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tb_cutoff.Location = new System.Drawing.Point(234, 106);
            this.tb_cutoff.Name = "tb_cutoff";
            this.tb_cutoff.Size = new System.Drawing.Size(143, 35);
            this.tb_cutoff.TabIndex = 13;
            this.tb_cutoff.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(43, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cutoff Frequency";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(46, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Set Base File";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.Location = new System.Drawing.Point(47, 514);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(618, 35);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "C:/avva/base.data";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("PMingLiU", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(671, 514);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 35);
            this.button3.TabIndex = 16;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 677);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_cutoff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxNonZero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxOrigin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_intense);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_intense;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxOrigin;
        private System.Windows.Forms.CheckBox cbxNonZero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbxFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tb_cutoff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
    }
}