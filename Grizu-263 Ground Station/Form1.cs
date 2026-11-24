using AForge.Video;
using AForge.Video.DirectShow;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Grizu_263_Ground_Station
{
    public partial class Form1 : Form
    {
        double sonCurrent = 0;
        double sonPressure = 0;
        double sonTemperature = 0;
        double sonAltitude = 0;
        double sonVoltage = 0;
        double gyro_R = 0;
        double gyro_P = 0;
        double gyro_Y = 0;
        double gpstime = 0;
        string csvDosyaYolu = "C:\\Users\\Özge\\OneDrive\\Desktop\\GCS\\Grizu-263 Ground Station";
        string telemetrypacket;
        int port_sayisi = 0;

        //Harita için
        GMapOverlay overlayMarkers = new GMapOverlay("markers");

        public Form1()
        {
            InitializeComponent();
            glControl1.Paint += glControl1_Paint;
            glControl1.Resize += glControl1_Resize;
            glControl1.Load += glControl1_Load;
        }
        // GPS KONUM GÖSTER FONKSİYONU//
        private void ShowGpsPoint(double lat, double lng, double altitude)
        {
            overlayMarkers.Markers.Clear();  // Eski markerları temizle

            PointLatLng point = new PointLatLng(lat, lng);

            // Marker oluştur
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            marker.ToolTipText = $"Lat: {lat}\nLng: {lng}\nAlt: {altitude} m";

            overlayMarkers.Markers.Add(marker);

            // Haritayı bu noktaya odakla
            gMapControl1.Position = point;
        }


        //-------------------INTERFACE DESİGN----------------------//
        private void Form1_Load(object sender, EventArgs e)
        {
            GrafikAyarla(chart1, "CURRENT (A)", Color.Red);
            GrafikAyarla(chart2, "VOLTAGE (V)", Color.Blue);
            GrafikAyarla(chart3, "PRESSURE (Pa)", Color.Green); // Basınç artık dümdüz çizgi olmayacak!
            GrafikAyarla(chart4, "TEMPURATURE (°C)", Color.Orange);
            GrafikAyarla(chart5, "ALTİTUDE (m)", Color.Purple);
            //this.BackColor = Color.FromArgb(0, 255, 153);
            buttonsımp.Enabled = false;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 1;
            this.chart1.BorderlineColor = Color.Black;

            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderlineWidth = 1;
            this.chart2.BorderlineColor = Color.Black;

            this.chart3.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart3.BorderlineWidth = 1;
            this.chart3.BorderlineColor = Color.Black;

            this.chart4.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart4.BorderlineWidth = 1;
            this.chart4.BorderlineColor = Color.Black;

            this.chart5.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart5.BorderlineWidth = 1;
            this.chart5.BorderlineColor = Color.Black;

            // 1. Dosya ismini tarih ve saat ile oluştur (Örn: Telemetri_01.12.2025_14.30.csv)
            string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss");
            csvDosyaYolu = "Flight_" + tarihSaat + "_1023" + ".csv";

            // 2. CSV Başlıklarını (Sütun İsimleri) Yaz
            string basliklar = "TEAM_ID,MISSION_TIME,PACKET_COUNT,MODE,STATE,ALTITUDE,TEMPERATURE,PRESSURE,VOLTAGE,CURRENT,GYRO_R,GYRO_P,GYRO_Y,ACCEL_R,ACCEL_P,ACCEL_Y,GPS_TIME,GPS_ALTITUDE,GPS_LATITUDE,GPS_LONGITUDE,GPS_SATS,CMD_ECHO";

            // Dosyayı oluştur ve başlığı yaz
            File.WriteAllText(csvDosyaYolu, basliklar + Environment.NewLine);

            foreach (var seriPort in SerialPort.GetPortNames())
            {
                comboBoxPort.Items.Add(seriPort);
                port_sayisi++;
            }
            if (port_sayisi > 0)
            {
                comboBoxPort.SelectedIndex = 0;
            }

            comboBoxBaud.Items.Add("9600");
            comboBoxBaud.Items.Add("19200");
            comboBoxBaud.Items.Add("38400");
            comboBoxBaud.Items.Add("57600");
            comboBoxBaud.Items.Add("115200");
            comboBoxBaud.SelectedIndex = 1;
            serialPort1.ReadTimeout = 500;

            listView1.View = View.Details; // Görünüm ayarı önemli

            listView1.Columns.Add("TEAM_ID", 100);
            listView1.Columns.Add("MISSION_TIME", 120);
            listView1.Columns.Add("PACKET_COUNT", 120);
            listView1.Columns.Add("MODE", 80);
            listView1.Columns.Add("STATE", 80);
            listView1.Columns.Add("ALTITUDE", 100);
            listView1.Columns.Add("TEMPERATURE", 120);
            listView1.Columns.Add("PRESSURE", 100);
            listView1.Columns.Add("VOLTAGE", 100);
            listView1.Columns.Add("CURRENT", 100);
            listView1.Columns.Add("GYRO_R", 100);
            listView1.Columns.Add("GYRO_P", 100);
            listView1.Columns.Add("GYRO_Y", 100);
            listView1.Columns.Add("ACCEL_R", 100);
            listView1.Columns.Add("ACCEL_P", 100);
            listView1.Columns.Add("ACCEL_Y", 100);
            listView1.Columns.Add("GPS_TIME", 120);
            listView1.Columns.Add("GPS_ALTITUDE", 130);
            listView1.Columns.Add("GPS_LATITUDE", 130);
            listView1.Columns.Add("GPS_LONGITUDE", 130);
            listView1.Columns.Add("GPS_SATS", 100);
            listView1.Columns.Add("CMD_ECHO", 100);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);





            // Harita sağlayıcısı
            gMapControl1.MapProvider = GMapProviders.GoogleMap;

            // İnternet üzerinden harita gelsin
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerAndCache;

            // Başlangıç noktası
            gMapControl1.Position = new PointLatLng(41.45352099999999, 31.78938);

            // zoom ayarları
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 12;

            gMapControl1.Overlays.Add(overlayMarkers);

        }
        private void groupBoxport_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }

        private void groupBoxgen_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush, 1);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                // Clear text and border
                g.Clear(this.BackColor);
                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
        //------------------------DATA PROCESS------------------------//
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPort1.IsOpen)
                return;

            string telemetrypacket;

            try
            {
                telemetrypacket = serialPort1.ReadLine()?.Trim();
            }
            catch
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(telemetrypacket))
                return;

            string[] dataParts = telemetrypacket.Split(',');

            if (dataParts.Length < 22)
                return;

            // PARSE
            if (!int.TryParse(dataParts[0], out int teamID)) return;
            string missiontime = dataParts[1];
            if (!int.TryParse(dataParts[2], out int packetcount)) return;
            if (!char.TryParse(dataParts[3], out char mode)) return;
            string state = dataParts[4];

            if (!double.TryParse(dataParts[5], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double altitude)) return;
            if (!double.TryParse(dataParts[6], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double temperature)) return;
            if (!double.TryParse(dataParts[7], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double pressure)) return;
            if (!double.TryParse(dataParts[8], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double voltage)) return;
            if (!double.TryParse(dataParts[9], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double current)) return;

            if (!double.TryParse(dataParts[10], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out gyro_R)) return;
            if (!double.TryParse(dataParts[11], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out gyro_P)) return;
            if (!double.TryParse(dataParts[12], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out gyro_Y)) return;

            if (!double.TryParse(dataParts[13], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double accel_R)) return;
            if (!double.TryParse(dataParts[14], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double accel_P)) return;
            if (!double.TryParse(dataParts[15], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double accel_Y)) return;

            if (!double.TryParse(dataParts[16], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out gpstime)) return;
            if (!double.TryParse(dataParts[17], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double gpsaltitude)) return;
            if (!double.TryParse(dataParts[18], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double gpslatitude)) return;
            if (!double.TryParse(dataParts[19], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double gpslongtitude)) return;
            if (!int.TryParse(dataParts[20], out int gpsSats)) return;

            string cmdEcho = dataParts[21];

            // CSV WRITE
            try
            {
                File.AppendAllText(csvDosyaYolu, telemetrypacket + Environment.NewLine);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // UI THREAD
            this.Invoke(new Action(() =>
            {
                try
                {
                    ListViewItem satir = new ListViewItem(teamID.ToString());

                    satir.SubItems.Add(missiontime);
                    satir.SubItems.Add(packetcount.ToString());
                    satir.SubItems.Add(mode.ToString());
                    satir.SubItems.Add(state);

                    satir.SubItems.Add(altitude.ToString("0.0") + " m");
                    satir.SubItems.Add(temperature.ToString("0.0") + " °C");
                    satir.SubItems.Add(pressure.ToString("0") + " Pa");
                    satir.SubItems.Add(voltage.ToString("0.00") + " V");
                    satir.SubItems.Add(current.ToString("0.00") + " A");

                    satir.SubItems.Add(gyro_R.ToString("0.0"));
                    satir.SubItems.Add(gyro_P.ToString("0.0"));
                    satir.SubItems.Add(gyro_Y.ToString("0.0"));

                    satir.SubItems.Add(accel_R.ToString("0.0"));
                    satir.SubItems.Add(accel_P.ToString("0.0"));
                    satir.SubItems.Add(accel_Y.ToString("0.0"));

                    satir.SubItems.Add(gpstime.ToString());
                    satir.SubItems.Add(gpsaltitude.ToString("0.0") + " m");
                    satir.SubItems.Add(gpslatitude.ToString("0.00000"));
                    satir.SubItems.Add(gpslongtitude.ToString("0.00000"));
                    satir.SubItems.Add(gpsSats.ToString());
                    satir.SubItems.Add(cmdEcho);

                    satir.BackColor = listView1.Items.Count % 2 == 0 ? Color.WhiteSmoke : Color.White;

                    listView1.Items.Insert(0, satir);

                    // son değerler
                    sonCurrent = current;
                    sonPressure = pressure;
                    sonTemperature = temperature;
                    sonAltitude = altitude;
                    sonVoltage = voltage;

                    ShowGpsPoint(gpslatitude, gpslongtitude, gpsaltitude);

                    glControl1.Invalidate();
                }
                catch(Exception exW)
                {
                    MessageBox.Show(exW.Message);
                }
            }));
        }

        //-------------------CHARTS-------------------//

        void AddPoint(Chart chart, int x, double y)
        {
            
            // Eğer grafiğin içinde hiç seri yoksa (hata almamak için) işlem yapma
            if (chart.Series.Count == 0) 
                return;

            // [0] diyerek ismine bakmaksızın İLK seriyi seçiyoruz.
            chart.Series[0].Points.AddXY(x, y);
            // 20 veriden fazlasını sil (kayan grafik efekti)
            if (chart.Series[0].Points.Count > 20)
                chart.Series[0].Points.RemoveAt(0);
            // Eksenleri otomatik ayarla
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        int zaman = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Global değişkenleri al
            double voltage = sonVoltage;
            double pressure = sonPressure;
            double temp = sonTemperature;
            double altitude = sonAltitude;
            double current = sonCurrent;

            // (GRAFİK, X, Y) YAZIYORUZ.
            AddPoint(chart1, zaman, current);      // Akım
            AddPoint(chart2, zaman, voltage);      // Voltaj
            AddPoint(chart3, zaman, pressure);     // Basınç
            AddPoint(chart4, zaman, temp);         // Sıcaklık
            AddPoint(chart5, zaman, altitude);     // Yükseklik

            zaman++;
        }
        private void GrafikAyarla(Chart chart, string baslik, Color renk)
        {
            // 1.Temizlik
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // 2.Alan ve Seri Ekleme
            chart.ChartAreas.Add("Area1");
            chart.Series.Add("Veri");

            // 3.Görsellik
            chart.Series[0].Color = renk;
            chart.Series[0].BorderWidth = 3;
            chart.Series[0].ChartType = SeriesChartType.FastLine; // Hızlı çizim
            chart.BackColor = Color.White;
            chart.ChartAreas[0].BackColor = Color.WhiteSmoke;

            // --- X EKSENİ AYARLARI (Sıkışmayı Çözen Kısım) ---
            // Interval = 0 demek "Sen karar ver" demektir. Sıkışırsa 5'er 5'er gider.
            chart.ChartAreas[0].AxisX.Interval = 0;
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 0;

            // Etiketlerin yazı tipi boyutu (Biraz küçültelim ki sığsın)
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);

            // Etiketlerin çarpılmasını veya alt satıra geçmesini engelle
            chart.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false; // Alt alta zikzak yapma
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = 0; // Yazıları düz tut (Eğme)

            // --- Y EKSENİ AYARLARI ---
            chart.ChartAreas[0].AxisY.IsStartedFromZero = false; // Otomatik zoom (Düz çizgi olmasın)

            // Izgaralar
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Başlık
            chart.Titles.Clear();
            chart.Titles.Add(baslik);
            chart.Titles[0].Font = new Font("Arial", 10, FontStyle.Bold);
        }

        //----------------- SERİ PORT KONTROLLERİ -------------------//
        private void btnstart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (!serialPort1.IsOpen)
            {
                if (comboBoxPort.Items.Count > 0)
                {
                    serialPort1.PortName = comboBoxPort.Text;
                }
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                try
                {
                    serialPort1.Open();
                    MessageBox.Show("Port Açık: " + serialPort1.PortName + "-" + serialPort1.BaudRate);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Port açılırken bir hata oluştu: " + ex.Message);
                }
            }

            if (serialPort1.IsOpen)
            {
                btnstart.Enabled = false;
                btnstop.Enabled = true;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            port_sayisi = 0;
            if (!serialPort1.IsOpen)
            {
                foreach (var seriPort in SerialPort.GetPortNames())
                {
                    comboBoxPort.Items.Add(seriPort);
                    port_sayisi++;
                }
                string mesaj = "Port girişleri yenilendi!";
                MessageBox.Show(mesaj);
                if (comboBoxPort.Items.Count > 0)
                {
                    comboBoxPort.SelectedIndex = 0;
                }
            }
            else
            {
                string mesaj = "Portu Kapattıktan Sonra Tekrar Deneyiniz!";
                MessageBox.Show(mesaj);
            }
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteTimeout = 100;
                serialPort1.Close();
                string mesaj = "Port Kapalı: " + serialPort1.PortName + "-" + serialPort1.BaudRate;
                MessageBox.Show(mesaj);
            }

            if (!serialPort1.IsOpen)
            {
                btnstart.Enabled = true;
                btnstop.Enabled = false;
            }
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = comboBoxPort.Text;
                string mesaj = "Yeni Port Name: " + comboBoxPort.Text;
                MessageBox.Show(mesaj);
            }
            else
            {
                string mesaj = "Seri Portu Kapattıktan Sonra Tekrardan Deneyiniz!";
                MessageBox.Show(mesaj);
            }
        }

        private void comboBoxBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaud.Text);
                string mesaj = "Yeni Port Baudrate: " + comboBoxBaud.Text;
                MessageBox.Show(mesaj);
            }
            else
            {
                string mesaj = "Seri Portu Kapattıktan Sonra Tekrardan Deneyiniz!";
                MessageBox.Show(mesaj);
            }
        }

        //------------------GL İLE ÇİZİM VE KONTROLLER---------------------//
        private void glControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)glControl1.Width / glControl1.Height,
                1.0f,
                100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            Matrix4 lookat = Matrix4.LookAt(
                new Vector3(10, 15, 10), // Kamera konumu (Objeyi görecek bir yer)
                Vector3.Zero,            // Baktığı nokta (Merkez)
                Vector3.UnitZ            // Yukarı yön (Sizin sistemde Z yukarı)
            );
            GL.LoadMatrix(ref lookat);

            GL.Rotate((float)gyro_R, 1.0f, 0.0f, 0.0f); // X Ekseni etrafında dön
            GL.Rotate((float)gyro_P, 0.0f, 1.0f, 0.0f); // Y Ekseni etrafında dön
            GL.Rotate((float)gyro_Y, 0.0f, 0.0f, 1.0f); // Z Ekseni etrafında dön

            DrawCylindir(5, 4, 60, 8);

            glControl1.SwapBuffers();

        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(System.Drawing.Color.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        List<Vector3> ustKapak = new List<Vector3>();
        List<Vector3> altKapak = new List<Vector3>();
        private void DrawCylindir(float üstyariçap, float altyariçap, int kosesayisi, int yükseklik)
        {
            ustKapak.Clear();
            altKapak.Clear();
            //HESAPLAMALAR ÇİZİM İÇİN
            float açı = 360.0f / kosesayisi;
            int üçgensayisi = kosesayisi - 2;

            //-----ÇİZİM-----//


            //ÜST KAPAK
            for (int i = 0; i < kosesayisi; i++)
            {
                float yeniaçı = MathHelper.DegreesToRadians(açı * i);
                float üx = (float)(üstyariçap * Math.Cos(yeniaçı));
                float üy = (float)(üstyariçap * Math.Sin(yeniaçı));
                float üz = yükseklik / 2f;
                ustKapak.Add(new Vector3(üx, üy, üz));
            }
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(Color.Teal);
            GL.Vertex3(0.0f, 0.0f, yükseklik); // merkez
            foreach (var v in ustKapak)
                GL.Vertex3(v);
            GL.Vertex3(ustKapak[0]);
            GL.End();

            //ALT KAPAK
            for (int i = 0; i < kosesayisi; i++)
            {
                float yeniaçı = MathHelper.DegreesToRadians(açı * i);
                float ax = (float)(altyariçap * Math.Cos(yeniaçı));
                float ay = (float)(altyariçap * Math.Sin(yeniaçı));
                float az = -yükseklik / 2f;
                altKapak.Add(new Vector3(ax, ay, az));
            }
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(Color.Blue);
            GL.Vertex3(0.0f, 0.0f, -yükseklik / 2f); // merkez
            foreach (var v in altKapak)
                GL.Vertex3(v);
            GL.Vertex3(altKapak[0]);
            GL.End();


            //YANAL YÜZEY
            GL.Begin(PrimitiveType.QuadStrip);
            GL.Color3(Color.Orange);
            for (int i = 0; i < kosesayisi; i++)
            {
                float yeniaçı = MathHelper.DegreesToRadians(açı * i);
                float x = (float)(altyariçap * Math.Cos(yeniaçı));
                float y = (float)(altyariçap * Math.Sin(yeniaçı));

                GL.Vertex3(x, y, yükseklik / 2);
                GL.Vertex3(x, y, -yükseklik / 2);
            }
            GL.End();
        }
        //----------------------COMMANDS------------------------//
        private void buttonst_Click(object sender, EventArgs e)
        {
            string stcommand;
            if (radioButton1.Checked)
            {
                stcommand = "CMD,1023,ST,"+ gpstime;
            }
            else
            {
                string utcTime = DateTime.UtcNow.ToString("HH:mm:ss");
                stcommand = "CMD,1023,ST,"+ DateTime.UtcNow.ToString("HH:mm:ss");
            }

            serialPort1.WriteLine(stcommand);
            MessageBox.Show("Sent: " + stcommand);
        }

        private void buttoncal_Click(object sender, EventArgs e)
        {
            string calcommand= "CMD,1023,CAL";
            serialPort1.WriteLine(calcommand);
            MessageBox.Show("Sent: " + calcommand);
        }

        private void buttoncxon_Click(object sender, EventArgs e)
        {
            string cxoncommand = "CMD,1023,CX,ON";
            serialPort1.WriteLine(cxoncommand);
            MessageBox.Show("Sent: " + cxoncommand);
        }

        private void buttocxoff_Click(object sender, EventArgs e)
        {
            string cxoffcommand = "CMD,1023,CX,OFF";
            serialPort1.WriteLine(cxoffcommand);
            MessageBox.Show("Sent: " + cxoffcommand);
        }

        private void buttonmecon_Click(object sender, EventArgs e)
        {
            string meconcommand = "CMD,1023,MEC,DEVİCE,ON";
            serialPort1.WriteLine(meconcommand);//CMD,<TEAM ID>,MEC,<DEVICE>,<ON_OFF>
            MessageBox.Show("Sent: " + meconcommand);
        }

        private void buttonmecoff_Click(object sender, EventArgs e)
        {
            string mecoffcommand = "CMD,1023,MEC,DEVİCE,OFF";
            serialPort1.WriteLine(mecoffcommand);//CMD,<TEAM ID>,MEC,<DEVICE>,<ON_OFF>
            MessageBox.Show("Sent: " + mecoffcommand);
        }

        private void buttonsım_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("CMD,1023,SIM,ENABLE");
            serialPort1.WriteLine("CMD,1023,SIM,ACTİVATE");
        }

        private void buttonsımp_Click(object sender, EventArgs e)
        {
            timersımp.Start();
        }

        private void timersımp_Tick(object sender, EventArgs e)
        {
            string yol = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cansat_2026_simp.txt");
            try
            {
                foreach (string satir in File.ReadLines(yol))
                {
                    serialPort1.WriteLine(satir);
                }
            }
            catch
            {
                MessageBox.Show("Pressure datas are not readed or not sended");
            }


        }

        private void buttonflight_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("CMD,1023,SIM,DISABLE");
        }

        
    }
}
