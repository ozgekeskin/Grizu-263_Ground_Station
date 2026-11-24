namespace Grizu_263_Ground_Station
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.glControl1 = new OpenTK.GLControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.btnstop = new System.Windows.Forms.Button();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart5 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxport = new System.Windows.Forms.GroupBox();
            this.groupBoxgen = new System.Windows.Forms.GroupBox();
            this.buttonflight = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonst = new System.Windows.Forms.Button();
            this.buttonsım = new System.Windows.Forms.Button();
            this.buttonmecon = new System.Windows.Forms.Button();
            this.buttoncal = new System.Windows.Forms.Button();
            this.buttonsımp = new System.Windows.Forms.Button();
            this.buttoncxon = new System.Windows.Forms.Button();
            this.buttocxoff = new System.Windows.Forms.Button();
            this.timersımp = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).BeginInit();
            this.groupBoxport.SuspendLayout();
            this.groupBoxgen.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(925, 7);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(299, 250);
            this.glControl1.TabIndex = 1;
            this.glControl1.VSync = false;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(8, 508);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1521, 276);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(3, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 28);
            this.label2.TabIndex = 97;
            this.label2.Text = "BAUD RATE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 96;
            this.label1.Text = "COM PORT:";
            // 
            // btnrefresh
            // 
            this.btnrefresh.BackColor = System.Drawing.Color.MintCream;
            this.btnrefresh.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnrefresh.Location = new System.Drawing.Point(60, 208);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(148, 37);
            this.btnrefresh.TabIndex = 95;
            this.btnrefresh.Text = "REFRESH";
            this.btnrefresh.UseVisualStyleBackColor = false;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(158, 33);
            this.comboBoxPort.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(95, 36);
            this.comboBoxPort.TabIndex = 91;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // btnstop
            // 
            this.btnstop.BackColor = System.Drawing.Color.MintCream;
            this.btnstop.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnstop.Location = new System.Drawing.Point(60, 166);
            this.btnstop.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnstop.Name = "btnstop";
            this.btnstop.Size = new System.Drawing.Size(148, 37);
            this.btnstop.TabIndex = 94;
            this.btnstop.Text = "STOP";
            this.btnstop.UseVisualStyleBackColor = false;
            this.btnstop.Click += new System.EventHandler(this.btnstop_Click);
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(158, 75);
            this.comboBoxBaud.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(95, 36);
            this.comboBoxBaud.TabIndex = 92;
            this.comboBoxBaud.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaud_SelectedIndexChanged);
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.MintCream;
            this.btnstart.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnstart.Location = new System.Drawing.Point(60, 123);
            this.btnstart.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(148, 37);
            this.btnstart.TabIndex = 93;
            this.btnstart.Text = "START";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(5, 262);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Current";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 242);
            this.chart1.TabIndex = 98;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(311, 262);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Voltage";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(300, 242);
            this.chart2.TabIndex = 99;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(617, 262);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Pressure";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(300, 242);
            this.chart3.TabIndex = 100;
            this.chart3.Text = "chart3";
            // 
            // chart4
            // 
            this.chart4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart4.Legends.Add(legend4);
            this.chart4.Location = new System.Drawing.Point(923, 262);
            this.chart4.Name = "chart4";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Temparature";
            this.chart4.Series.Add(series4);
            this.chart4.Size = new System.Drawing.Size(300, 242);
            this.chart4.TabIndex = 101;
            this.chart4.Text = "chart4";
            // 
            // chart5
            // 
            this.chart5.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            this.chart5.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart5.Legends.Add(legend5);
            this.chart5.Location = new System.Drawing.Point(1229, 262);
            this.chart5.Name = "chart5";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Altitude";
            this.chart5.Series.Add(series5);
            this.chart5.Size = new System.Drawing.Size(300, 242);
            this.chart5.TabIndex = 102;
            this.chart5.Text = "chart5";
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(1230, 7);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(296, 250);
            this.gMapControl1.TabIndex = 103;
            this.gMapControl1.Zoom = 0D;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBoxport
            // 
            this.groupBoxport.Controls.Add(this.label1);
            this.groupBoxport.Controls.Add(this.btnstart);
            this.groupBoxport.Controls.Add(this.comboBoxBaud);
            this.groupBoxport.Controls.Add(this.btnstop);
            this.groupBoxport.Controls.Add(this.comboBoxPort);
            this.groupBoxport.Controls.Add(this.btnrefresh);
            this.groupBoxport.Controls.Add(this.label2);
            this.groupBoxport.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxport.Location = new System.Drawing.Point(6, 6);
            this.groupBoxport.Name = "groupBoxport";
            this.groupBoxport.Size = new System.Drawing.Size(299, 251);
            this.groupBoxport.TabIndex = 119;
            this.groupBoxport.TabStop = false;
            this.groupBoxport.Text = "Port Controls";
            this.groupBoxport.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxport_Paint);
            // 
            // groupBoxgen
            // 
            this.groupBoxgen.Controls.Add(this.buttonflight);
            this.groupBoxgen.Controls.Add(this.radioButton1);
            this.groupBoxgen.Controls.Add(this.buttonst);
            this.groupBoxgen.Controls.Add(this.buttonsım);
            this.groupBoxgen.Controls.Add(this.buttonmecon);
            this.groupBoxgen.Controls.Add(this.buttoncal);
            this.groupBoxgen.Controls.Add(this.buttonsımp);
            this.groupBoxgen.Controls.Add(this.buttoncxon);
            this.groupBoxgen.Controls.Add(this.buttocxoff);
            this.groupBoxgen.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBoxgen.Location = new System.Drawing.Point(311, 6);
            this.groupBoxgen.Name = "groupBoxgen";
            this.groupBoxgen.Size = new System.Drawing.Size(606, 251);
            this.groupBoxgen.TabIndex = 120;
            this.groupBoxgen.TabStop = false;
            this.groupBoxgen.Text = "Commands";
            this.groupBoxgen.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBoxgen_Paint);
            // 
            // buttonflight
            // 
            this.buttonflight.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonflight.Location = new System.Drawing.Point(325, 48);
            this.buttonflight.Name = "buttonflight";
            this.buttonflight.Size = new System.Drawing.Size(186, 36);
            this.buttonflight.TabIndex = 127;
            this.buttonflight.Text = "FLIGHT MODE";
            this.buttonflight.UseVisualStyleBackColor = true;
            this.buttonflight.Click += new System.EventHandler(this.buttonflight_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(163, 177);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(163, 31);
            this.radioButton1.TabIndex = 125;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Use GPS Time";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonst
            // 
            this.buttonst.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonst.Location = new System.Drawing.Point(26, 174);
            this.buttonst.Name = "buttonst";
            this.buttonst.Size = new System.Drawing.Size(130, 36);
            this.buttonst.TabIndex = 116;
            this.buttonst.Text = "ST";
            this.buttonst.UseVisualStyleBackColor = true;
            this.buttonst.Click += new System.EventHandler(this.buttonst_Click);
            // 
            // buttonsım
            // 
            this.buttonsım.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonsım.Location = new System.Drawing.Point(325, 90);
            this.buttonsım.Name = "buttonsım";
            this.buttonsım.Size = new System.Drawing.Size(186, 36);
            this.buttonsım.TabIndex = 117;
            this.buttonsım.Text = "SIM MODE";
            this.buttonsım.UseVisualStyleBackColor = true;
            this.buttonsım.Click += new System.EventHandler(this.buttonsım_Click);
            // 
            // buttonmecon
            // 
            this.buttonmecon.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonmecon.Location = new System.Drawing.Point(174, 48);
            this.buttonmecon.Name = "buttonmecon";
            this.buttonmecon.Size = new System.Drawing.Size(130, 36);
            this.buttonmecon.TabIndex = 119;
            this.buttonmecon.Text = "MEC";
            this.buttonmecon.UseVisualStyleBackColor = true;
            this.buttonmecon.Click += new System.EventHandler(this.buttonmecon_Click);
            // 
            // buttoncal
            // 
            this.buttoncal.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttoncal.Location = new System.Drawing.Point(26, 132);
            this.buttoncal.Name = "buttoncal";
            this.buttoncal.Size = new System.Drawing.Size(130, 36);
            this.buttoncal.TabIndex = 118;
            this.buttoncal.Text = "CAL";
            this.buttoncal.UseVisualStyleBackColor = true;
            this.buttoncal.Click += new System.EventHandler(this.buttoncal_Click);
            // 
            // buttonsımp
            // 
            this.buttonsımp.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonsımp.Location = new System.Drawing.Point(174, 90);
            this.buttonsımp.Name = "buttonsımp";
            this.buttonsımp.Size = new System.Drawing.Size(130, 36);
            this.buttonsımp.TabIndex = 120;
            this.buttonsımp.Text = "SIMP";
            this.buttonsımp.UseVisualStyleBackColor = true;
            this.buttonsımp.Click += new System.EventHandler(this.buttonsımp_Click);
            // 
            // buttoncxon
            // 
            this.buttoncxon.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttoncxon.Location = new System.Drawing.Point(26, 48);
            this.buttoncxon.Name = "buttoncxon";
            this.buttoncxon.Size = new System.Drawing.Size(130, 36);
            this.buttoncxon.TabIndex = 115;
            this.buttoncxon.Text = "CXON";
            this.buttoncxon.UseVisualStyleBackColor = true;
            this.buttoncxon.Click += new System.EventHandler(this.buttoncxon_Click);
            // 
            // buttocxoff
            // 
            this.buttocxoff.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttocxoff.Location = new System.Drawing.Point(26, 90);
            this.buttocxoff.Name = "buttocxoff";
            this.buttocxoff.Size = new System.Drawing.Size(130, 36);
            this.buttocxoff.TabIndex = 122;
            this.buttocxoff.Text = "CXOFF";
            this.buttocxoff.UseVisualStyleBackColor = true;
            this.buttocxoff.Click += new System.EventHandler(this.buttocxoff_Click);
            // 
            // timersımp
            // 
            this.timersımp.Interval = 1000;
            this.timersımp.Tick += new System.EventHandler(this.timersımp_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1538, 793);
            this.Controls.Add(this.groupBoxgen);
            this.Controls.Add(this.groupBoxport);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.chart5);
            this.Controls.Add(this.chart4);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.glControl1);
            this.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Grizu-263 Ground Station";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart5)).EndInit();
            this.groupBoxport.ResumeLayout(false);
            this.groupBoxport.PerformLayout();
            this.groupBoxgen.ResumeLayout(false);
            this.groupBoxgen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ListView listView1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button btnstop;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart5;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBoxport;
        private System.Windows.Forms.GroupBox groupBoxgen;
        private System.Windows.Forms.Button buttonst;
        private System.Windows.Forms.Button buttonsım;
        private System.Windows.Forms.Button buttonmecon;
        private System.Windows.Forms.Button buttoncal;
        private System.Windows.Forms.Button buttonsımp;
        private System.Windows.Forms.Button buttoncxon;
        private System.Windows.Forms.Button buttocxoff;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Timer timersımp;
        private System.Windows.Forms.Button buttonflight;
    }
}

