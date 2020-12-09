namespace ThickInspector
{
    partial class Form1
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
            this.tblWhole = new System.Windows.Forms.TableLayoutPanel();
            this.tblLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tblTrackBar = new System.Windows.Forms.TableLayoutPanel();
            this.tbInspectPos = new System.Windows.Forms.TextBox();
            this.trkInspectPos = new System.Windows.Forms.TrackBar();
            this.tblRightButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.tbGreenLength = new System.Windows.Forms.Label();
            this.tbBlueLength = new System.Windows.Forms.Label();
            this.lb_ttv = new System.Windows.Forms.Label();
            this.tbTTV = new System.Windows.Forms.Label();
            this.tblRight = new System.Windows.Forms.TableLayoutPanel();
            this.tblLeftLower = new System.Windows.Forms.TableLayoutPanel();
            this.tblStatistics = new System.Windows.Forms.TableLayoutPanel();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.lbAvg = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSetParam = new System.Windows.Forms.Button();
            this.lbStartPos = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.panel3D = new ThickInspector.DoubleBufferPanel();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2D = new ThickInspector.DoubleBufferPanel();
            this.tblWhole.SuspendLayout();
            this.tblLeft.SuspendLayout();
            this.tblTrackBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkInspectPos)).BeginInit();
            this.tblRightButton.SuspendLayout();
            this.tblRight.SuspendLayout();
            this.tblLeftLower.SuspendLayout();
            this.tblStatistics.SuspendLayout();
            this.panel3D.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblWhole
            // 
            this.tblWhole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblWhole.AutoSize = true;
            this.tblWhole.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tblWhole.ColumnCount = 2;
            this.tblWhole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.62528F));
            this.tblWhole.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.374713F));
            this.tblWhole.Controls.Add(this.tblLeft, 0, 0);
            this.tblWhole.Controls.Add(this.tblRight, 1, 0);
            this.tblWhole.Location = new System.Drawing.Point(32, 12);
            this.tblWhole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblWhole.Name = "tblWhole";
            this.tblWhole.RowCount = 1;
            this.tblWhole.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblWhole.Size = new System.Drawing.Size(1518, 641);
            this.tblWhole.TabIndex = 0;
            // 
            // tblLeft
            // 
            this.tblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tblLeft.ColumnCount = 1;
            this.tblLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLeft.Controls.Add(this.tblTrackBar, 0, 1);
            this.tblLeft.Controls.Add(this.tblRightButton, 0, 3);
            this.tblLeft.Controls.Add(this.panel3D, 0, 0);
            this.tblLeft.Controls.Add(this.panel2D, 0, 2);
            this.tblLeft.Location = new System.Drawing.Point(3, 2);
            this.tblLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblLeft.Name = "tblLeft";
            this.tblLeft.RowCount = 4;
            this.tblLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.48435F));
            this.tblLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.96771F));
            this.tblLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.58023F));
            this.tblLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.96771F));
            this.tblLeft.Size = new System.Drawing.Size(1369, 637);
            this.tblLeft.TabIndex = 0;
            // 
            // tblTrackBar
            // 
            this.tblTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tblTrackBar.ColumnCount = 4;
            this.tblTrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.978328F));
            this.tblTrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.05264F));
            this.tblTrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.823529F));
            this.tblTrackBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.99071F));
            this.tblTrackBar.Controls.Add(this.tbInspectPos, 3, 0);
            this.tblTrackBar.Controls.Add(this.trkInspectPos, 1, 0);
            this.tblTrackBar.Controls.Add(this.btnRight, 2, 0);
            this.tblTrackBar.Controls.Add(this.btnLeft, 0, 0);
            this.tblTrackBar.Location = new System.Drawing.Point(3, 164);
            this.tblTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblTrackBar.Name = "tblTrackBar";
            this.tblTrackBar.RowCount = 1;
            this.tblTrackBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTrackBar.Size = new System.Drawing.Size(1363, 27);
            this.tblTrackBar.TabIndex = 1;
            // 
            // tbInspectPos
            // 
            this.tbInspectPos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInspectPos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInspectPos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInspectPos.Location = new System.Drawing.Point(1214, 7);
            this.tbInspectPos.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.tbInspectPos.Name = "tbInspectPos";
            this.tbInspectPos.Size = new System.Drawing.Size(146, 23);
            this.tbInspectPos.TabIndex = 3;
            this.tbInspectPos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbInspectPos_KeyUp);
            // 
            // trkInspectPos
            // 
            this.trkInspectPos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkInspectPos.LargeChange = 10;
            this.trkInspectPos.Location = new System.Drawing.Point(125, 2);
            this.trkInspectPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trkInspectPos.Maximum = 2000;
            this.trkInspectPos.Name = "trkInspectPos";
            this.trkInspectPos.Size = new System.Drawing.Size(963, 23);
            this.trkInspectPos.SmallChange = 5;
            this.trkInspectPos.TabIndex = 0;
            this.trkInspectPos.TickFrequency = 100;
            this.trkInspectPos.Value = 1000;
            this.trkInspectPos.Scroll += new System.EventHandler(this.trkInspectPos_Scroll);
            // 
            // tblRightButton
            // 
            this.tblRightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tblRightButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tblRightButton.ColumnCount = 8;
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tblRightButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tblRightButton.Controls.Add(this.btnBlue, 0, 0);
            this.tblRightButton.Controls.Add(this.btnGreen, 3, 0);
            this.tblRightButton.Controls.Add(this.tbGreenLength, 4, 0);
            this.tblRightButton.Controls.Add(this.tbBlueLength, 1, 0);
            this.tblRightButton.Controls.Add(this.lb_ttv, 6, 0);
            this.tblRightButton.Controls.Add(this.tbTTV, 7, 0);
            this.tblRightButton.Location = new System.Drawing.Point(261, 607);
            this.tblRightButton.Name = "tblRightButton";
            this.tblRightButton.RowCount = 1;
            this.tblRightButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRightButton.Size = new System.Drawing.Size(847, 27);
            this.tblRightButton.TabIndex = 1;
            // 
            // btnBlue
            // 
            this.btnBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlue.AutoSize = true;
            this.btnBlue.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBlue.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlue.Location = new System.Drawing.Point(5, 0);
            this.btnBlue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(49, 27);
            this.btnBlue.TabIndex = 0;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGreen.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGreen.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGreen.Location = new System.Drawing.Point(275, 0);
            this.btnGreen.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(49, 27);
            this.btnGreen.TabIndex = 1;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // tbGreenLength
            // 
            this.tbGreenLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGreenLength.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGreenLength.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tbGreenLength.Location = new System.Drawing.Point(334, 5);
            this.tbGreenLength.Margin = new System.Windows.Forms.Padding(5);
            this.tbGreenLength.Name = "tbGreenLength";
            this.tbGreenLength.Size = new System.Drawing.Size(159, 17);
            this.tbGreenLength.TabIndex = 3;
            this.tbGreenLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBlueLength
            // 
            this.tbBlueLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBlueLength.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBlueLength.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tbBlueLength.Location = new System.Drawing.Point(64, 5);
            this.tbBlueLength.Margin = new System.Windows.Forms.Padding(5);
            this.tbBlueLength.Name = "tbBlueLength";
            this.tbBlueLength.Size = new System.Drawing.Size(159, 17);
            this.tbBlueLength.TabIndex = 2;
            this.tbBlueLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_ttv
            // 
            this.lb_ttv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ttv.AutoSize = true;
            this.lb_ttv.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ttv.ForeColor = System.Drawing.Color.Maroon;
            this.lb_ttv.Location = new System.Drawing.Point(585, 0);
            this.lb_ttv.Name = "lb_ttv";
            this.lb_ttv.Size = new System.Drawing.Size(61, 27);
            this.lb_ttv.TabIndex = 4;
            this.lb_ttv.Text = "TTV";
            this.lb_ttv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTTV
            // 
            this.tbTTV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTTV.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTTV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tbTTV.Location = new System.Drawing.Point(654, 5);
            this.tbTTV.Margin = new System.Windows.Forms.Padding(5);
            this.tbTTV.Name = "tbTTV";
            this.tbTTV.Size = new System.Drawing.Size(188, 17);
            this.tbTTV.TabIndex = 5;
            this.tbTTV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblRight
            // 
            this.tblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblRight.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tblRight.ColumnCount = 1;
            this.tblRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRight.Controls.Add(this.tblLeftLower, 0, 0);
            this.tblRight.Controls.Add(this.btnSetParam, 0, 1);
            this.tblRight.Location = new System.Drawing.Point(1378, 2);
            this.tblRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblRight.Name = "tblRight";
            this.tblRight.RowCount = 2;
            this.tblRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.77F));
            this.tblRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.23F));
            this.tblRight.Size = new System.Drawing.Size(137, 637);
            this.tblRight.TabIndex = 1;
            // 
            // tblLeftLower
            // 
            this.tblLeftLower.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLeftLower.ColumnCount = 1;
            this.tblLeftLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLeftLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLeftLower.Controls.Add(this.tblStatistics, 0, 0);
            this.tblLeftLower.Location = new System.Drawing.Point(3, 3);
            this.tblLeftLower.Name = "tblLeftLower";
            this.tblLeftLower.RowCount = 1;
            this.tblLeftLower.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLeftLower.Size = new System.Drawing.Size(131, 540);
            this.tblLeftLower.TabIndex = 2;
            // 
            // tblStatistics
            // 
            this.tblStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblStatistics.AutoSize = true;
            this.tblStatistics.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tblStatistics.ColumnCount = 1;
            this.tblStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblStatistics.Controls.Add(this.btnMax, 0, 2);
            this.tblStatistics.Controls.Add(this.btnMin, 0, 4);
            this.tblStatistics.Controls.Add(this.lbAvg, 0, 1);
            this.tblStatistics.Controls.Add(this.lbMax, 0, 3);
            this.tblStatistics.Controls.Add(this.lbMin, 0, 5);
            this.tblStatistics.Controls.Add(this.label1, 0, 0);
            this.tblStatistics.Controls.Add(this.btnLoad, 0, 7);
            this.tblStatistics.Font = new System.Drawing.Font("Cambria", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblStatistics.Location = new System.Drawing.Point(3, 3);
            this.tblStatistics.Name = "tblStatistics";
            this.tblStatistics.RowCount = 8;
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46864F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.18791F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.18791F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.18791F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.18791F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.18791F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.2959F));
            this.tblStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.2959F));
            this.tblStatistics.Size = new System.Drawing.Size(125, 534);
            this.tblStatistics.TabIndex = 0;
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMax.Location = new System.Drawing.Point(5, 136);
            this.btnMax.Margin = new System.Windows.Forms.Padding(5);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(115, 55);
            this.btnMax.TabIndex = 1;
            this.btnMax.Text = "Maximum";
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Location = new System.Drawing.Point(5, 266);
            this.btnMin.Margin = new System.Windows.Forms.Padding(5);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(115, 55);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "Minimum";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // lbAvg
            // 
            this.lbAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAvg.AutoSize = true;
            this.lbAvg.Location = new System.Drawing.Point(15, 76);
            this.lbAvg.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.lbAvg.Name = "lbAvg";
            this.lbAvg.Size = new System.Drawing.Size(95, 50);
            this.lbAvg.TabIndex = 3;
            this.lbAvg.Text = "0";
            this.lbAvg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbMax
            // 
            this.lbMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMax.AutoSize = true;
            this.lbMax.Location = new System.Drawing.Point(15, 206);
            this.lbMax.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(95, 50);
            this.lbMax.TabIndex = 4;
            this.lbMax.Text = "0";
            this.lbMax.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbMin
            // 
            this.lbMin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMin.AutoSize = true;
            this.lbMin.Location = new System.Drawing.Point(15, 336);
            this.lbMin.Margin = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(95, 50);
            this.lbMin.TabIndex = 5;
            this.lbMin.Text = "0";
            this.lbMin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Average";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(5, 467);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(115, 62);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSetParam
            // 
            this.btnSetParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetParam.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetParam.Location = new System.Drawing.Point(10, 556);
            this.btnSetParam.Margin = new System.Windows.Forms.Padding(10);
            this.btnSetParam.Name = "btnSetParam";
            this.btnSetParam.Size = new System.Drawing.Size(117, 71);
            this.btnSetParam.TabIndex = 3;
            this.btnSetParam.Text = "Set Param";
            this.btnSetParam.UseVisualStyleBackColor = true;
            this.btnSetParam.Click += new System.EventHandler(this.btnSetParam_Click);
            // 
            // lbStartPos
            // 
            this.lbStartPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartPos.AutoSize = true;
            this.lbStartPos.Location = new System.Drawing.Point(1155, 226);
            this.lbStartPos.Name = "lbStartPos";
            this.lbStartPos.Size = new System.Drawing.Size(168, 14);
            this.lbStartPos.TabIndex = 2;
            this.lbStartPos.Text = "起始座標 (0.000, 0.000) mm";
            this.lbStartPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.SystemColors.Window;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Image = global::ThickInspector.Properties.Resources.icon_right;
            this.btnRight.Location = new System.Drawing.Point(1094, 0);
            this.btnRight.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(43, 27);
            this.btnRight.TabIndex = 4;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Image = global::ThickInspector.Properties.Resources.icon_left;
            this.btnLeft.Location = new System.Drawing.Point(75, 0);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(44, 27);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // panel3D
            // 
            this.panel3D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3D.Controls.Add(this.tbStep);
            this.panel3D.Controls.Add(this.label3);
            this.panel3D.Location = new System.Drawing.Point(3, 3);
            this.panel3D.Name = "panel3D";
            this.panel3D.Size = new System.Drawing.Size(1363, 156);
            this.panel3D.TabIndex = 2;
            // 
            // tbStep
            // 
            this.tbStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbStep.Location = new System.Drawing.Point(39, 129);
            this.tbStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(45, 25);
            this.tbStep.TabIndex = 1;
            this.tbStep.Text = "10";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Step";
            // 
            // panel2D
            // 
            this.panel2D.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2D.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2D.Location = new System.Drawing.Point(3, 196);
            this.panel2D.Name = "panel2D";
            this.panel2D.Size = new System.Drawing.Size(1363, 405);
            this.panel2D.TabIndex = 3;
            this.panel2D.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2D_MouseDown);
            this.panel2D.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2D_MouseMove);
            this.panel2D.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2D_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 666);
            this.Controls.Add(this.tblWhole);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tblWhole.ResumeLayout(false);
            this.tblLeft.ResumeLayout(false);
            this.tblTrackBar.ResumeLayout(false);
            this.tblTrackBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkInspectPos)).EndInit();
            this.tblRightButton.ResumeLayout(false);
            this.tblRightButton.PerformLayout();
            this.tblRight.ResumeLayout(false);
            this.tblLeftLower.ResumeLayout(false);
            this.tblLeftLower.PerformLayout();
            this.tblStatistics.ResumeLayout(false);
            this.tblStatistics.PerformLayout();
            this.panel3D.ResumeLayout(false);
            this.panel3D.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblWhole;
        private System.Windows.Forms.TableLayoutPanel tblLeft;
        private System.Windows.Forms.TableLayoutPanel tblRight;
        private System.Windows.Forms.TableLayoutPanel tblTrackBar;
        private System.Windows.Forms.TrackBar trkInspectPos;
        private System.Windows.Forms.TextBox tbInspectPos;
        private System.Windows.Forms.TableLayoutPanel tblRightButton;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Label tbBlueLength;
        private System.Windows.Forms.TableLayoutPanel tblLeftLower;
        private System.Windows.Forms.TableLayoutPanel tblStatistics;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbAvg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.Label tbGreenLength;
        private System.Windows.Forms.Label lbStartPos;
        private System.Windows.Forms.Button btnSetParam;
        //private System.Windows.Forms.Panel panel3D;
        //private System.Windows.Forms.Panel panel2D;
        private DoubleBufferPanel panel3D;
        private DoubleBufferPanel panel2D;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_ttv;
        private System.Windows.Forms.Label tbTTV;
    }
}

