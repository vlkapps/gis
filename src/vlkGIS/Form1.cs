using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using vlkGIS.langs;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace vlkGIS
{
    public partial class Form1 : Form
    {
        private string ToolStripLabelTextTemp;

        internal static string Language;

        // НАСТРОЙКИ
        internal static IniFile INI = new IniFile("config.ini");
        internal static string GPS_Port;
        internal static int GPS_Speed;
        internal static int GPS_Accuracy;
        internal static int Map_Service;
        internal static int Map_Layer;

        // МАСШТАБ
        private readonly int[] zoom = {
            10000000, 5000000, 2000000,
            1000000, 500000, 200000,
            100000, 50000, 25000,
            10000, 5000, 2000,
            1000, 500, 200,
            100, 50, 20,
            10 };

        // ПОЛНЫЙ ЭКРАН
        private bool fullscreen = false;

        private bool move_after_start = false;

        // СКОРОСТЬ ПОРТОВ
        public static int[] speed = { 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200 };

        // ПОСТАВЩИКИ КАРТ
        public static string[] maps = { "Google", "Yandex", "OpenStreetMap", "Bing" };

        // ПАРСЕР NMEA
        private NMEAparser nmea_parser;

        // СОСТОЯНИЕ ЗАПИСИ ТРЕКА
        private bool Rec = false;

        // ВРЕМЯ ЗАПИСИ ТРЕКА
        private double time = 0;

        // ИМЯ ПРОЕКТА
        internal static string ProjectName = "";

        // ПУТЬ К ПРОЕКТУ
        internal static string path;

        // ИМЯ ФАЙЛА ЗАПИСИ МАРШРУТА
        private string recFileName;

        ///// ЯЗЫК /////
        public static Language lang;

        // ПОРТ
        private SerialPort port;

        private List<PointLatLng> points; // Массив точек

        // ТАЙМЕР ДЛЯ ОБНОВЛЕНИЯ ДАННЫХ С GPS
        private readonly Timer timer = new Timer();
        private readonly Timer timerRec = new Timer();

        // ЗАПИСЬ ДАННЫХ В ФАЙЛ ПО СТРОКАМ
        private StreamWriter writetext;

        // РИСОВАНИЕ ПУТИ ПРИ ЗАПИСИ МАРШРУТА
        private GMapRoute polygon_for_rec;
        private GMapOverlay polyOverlay_for_rec;

        // РИСОВАНИЕ ПУТИ ПРИ ОТКРЫТИИ МАРШРУТА
        private GMapRoute polygon_for_open;
        private GMapOverlay polyOverlay_for_open;

        // ДАННЫЕ О ТЕКУЩЕМ ПРОЕКТЕ
        internal static string[] project_info;

        GMapOverlay markers;

        // ВРЕМЯ ОБНОВЛЕНИЯ ДАННЫХ С GPS В мс
        private int GPS_Acc = 500;

        // ШИРОТА И ДОЛГОТА НА КАРТЕ
        private double lat_cur, lng_cur;

        // ШИРОТА И ДОЛГОТА С GPS
        private double lat_gps = 0, lng_gps = 0;

        private GMapMarker selectedListMarkers;

        private XmlDocument xDoc;

        MouseButtons _lastButtonUp = MouseButtons.None;

        internal static int SmoothingType;
        internal static int WidthLine;

        internal static string RecentOpen;
        private readonly ToolStripMenuItem[] items = new ToolStripMenuItem[10];

        CultureInfo cultureInfo;

        int mousePosition;
        float bearing, lastBearing;

        public Form1()
        {
            InitializeComponent();
            Start(true);
        }

        // ИНИЦИАЛИЗАЦИЯ
        private void Start(bool changeTab)
        {
            GPS_Close_Port(); // ЗАКРЫТЬ ПОРТ, ЕСЛИ ОН БЫЛ ОТКРЫТ
            LoadSettings(); // ЗАГРУЗКА НАСТРОЕК
            InitMap(); // ИНИЦИАЛИЗАЦИЯ НАСТРОЕК КАРТЫ
            InitInterface(); // ИНИЦИАЛИЗАЦИЯ ИНТЕРФЕЙСА
            GPS_Work(); // ЗАПУСК GPS-МОДУЛЯ
            if (changeTab)
                Tabs(0); // ВЫБОР ВКЛАДКИ С GPS МОДУЛЕМ
        }

        // ЗАГРУЗКА НАСТРОЕК
        private void LoadSettings()
        {
            Language = INI.Read("UI", "Language", "en");
            lang = new Language(Language);
            cultureInfo = lang.getCultureInfo(Language);

            // GPS
            GPS_Port = INI.Read("GPS", "Port", ""); // Порт
            GPS_Speed = int.Parse(INI.Read("GPS", "Speed", "4")); // Скорость
            GPS_Accuracy = int.Parse(INI.Read("GPS", "Accuracy", "2")); // Точность

            // Определение точности
            if (GPS_Accuracy == 0)
                GPS_Acc = 500;
            else if (GPS_Accuracy == 1)
                GPS_Acc = 750;
            else if (GPS_Accuracy == 2)
                GPS_Acc = 1000;
            else if (GPS_Accuracy == 3)
                GPS_Acc = 1500;
            else if (GPS_Accuracy == 4)
                GPS_Acc = 2000;

            SmoothingType = int.Parse(INI.Read("Track", "SmoothingType", "1"));
            WidthLine = int.Parse(INI.Read("Track", "WidthLine", "3"));

            timer.Interval = (GPS_Acc);
            timerRec.Interval = (GPS_Acc);
            timerRec.Tick += new EventHandler(RecStart);

            if (!ScanPorts()) // Если доступных портов нет ...
                GPS_Port = ""; //... то порт пустой ...
            else // ... иначе создаём переменную с доступным портом
                port = new SerialPort(GPS_Port, speed[GPS_Speed], Parity.None, 8, StopBits.One);

            // КАРТА
            Map_Service = int.Parse(INI.Read("Map", "Service", "0"));
            Map_Layer = int.Parse(INI.Read("Map", "Layer", "0"));

            // Выбор сервиса карты
            // Google
            if (Map_Service == 0)
            {
                if (Map_Layer == 0)
                    MapControl.MapProvider = GMapProviders.GoogleMap;
                else if (Map_Layer == 1)
                    MapControl.MapProvider = GMapProviders.GoogleSatelliteMap;
                else if (Map_Layer == 2)
                    MapControl.MapProvider = GMapProviders.GoogleHybridMap;
            }
            // Яндекс
            else if (Map_Service == 1)
            {
                if (Map_Layer == 0)
                    MapControl.MapProvider = GMapProviders.YandexMap;
                else if (Map_Layer == 1)
                    MapControl.MapProvider = GMapProviders.YandexSatelliteMap;
                else if (Map_Layer == 2)
                    MapControl.MapProvider = GMapProviders.YandexHybridMap;
            }
            // OpenStreetMap
            else if (Map_Service == 2)
            {
                if (Map_Layer == 0)
                    MapControl.MapProvider = GMapProviders.OpenStreetMap;
            }
            // Bing
            else if (Map_Service == 3)
            {
                if (Map_Layer == 0)
                    MapControl.MapProvider = GMapProviders.BingMap;
                else if (Map_Layer == 1)
                    MapControl.MapProvider = GMapProviders.BingSatelliteMap;
                else if (Map_Layer == 2)
                    MapControl.MapProvider = GMapProviders.BingHybridMap;
            }

            // Восстановление последней сохранённой позиции карты
            lat_cur = Convert.ToDouble(INI.Read("Last", "Lat", "0"));
            lng_cur = Convert.ToDouble(INI.Read("Last", "Lng", "0"));
            MapControl.Position = new PointLatLng(lat_cur, lng_cur);
            GMapControl1_OnPositionChanged(MapControl.Position);

            bearing = Convert.ToSingle(INI.Read("Last", "Bearing", "0"));
            MapControl.Bearing = bearing;
            toolStripTextBox1.Text = bearing + "";

            // Восстановление последнего сохранённого значения увеличения карты
            MapControl.Zoom = Convert.ToInt32(INI.Read("Last", "Zoom", "5"));

            if (File.Exists("recent.txt"))
            {
                if (new FileInfo("recent.txt").Length > 0)
                {
                    RecentOpen = File.ReadAllLines("recent.txt")[0];
                    string[] recent = RecentOpen.Split('?');
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (recent.Length - 1 > i)
                        {
                            items[i] = new ToolStripMenuItem
                            {
                                Name = "RecentItem" + i.ToString(),
                                Tag = recent[i],
                                Text = Path.GetFileName(recent[i])
                            };
                        }
                        else
                        {
                            items[i] = new ToolStripMenuItem
                            {
                                Name = "RecentItem" + i.ToString(),
                                Tag = "",
                                Text = "",
                                Visible = false
                            };
                        }
                        items[i].Click += new EventHandler(MenuItemClickHandler);
                    }
                    Open_ToolStripMenuItem.DropDownItems.AddRange(items);
                }
            }
            else
                File.Create("recent.txt");
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            OpenProject(clickedItem.Tag.ToString());
        }

        // ВЫБОР ВКЛАДКИ
        private void Tabs(int tab)
        {
            // ДАННЫЕ С GPS
            if (tab == 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                TitleTab_label.Text = panel2.Tag.ToString();

                GPS_tab_toolStripButton.Checked = true;
                Markers_toolStripButton.Checked = false;
            }

            // МАРКЕРЫ
            else if (tab == 1)
            {
                panel2.Visible = false;
                panel1.Visible = true;
                TitleTab_label.Text = panel1.Tag.ToString();

                GPS_tab_toolStripButton.Checked = false;
                Markers_toolStripButton.Checked = true;
            }

            panel1.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
        }

        // ИНИЦИАЛИЗАЦИЯ КАРТЫ
        private void InitMap()
        {
            // Фон карты
            MapControl.EmptyMapBackground = Color.FromArgb(100, 100, 100);

            // Текст для поля с маштабом
            Zoom_toolStripTextBox.Text = "1:" + zoom[(int)MapControl.Zoom - 1];
        }

        // ИНИЦИАЛИЗАЦИЯ ИНТЕРФЕЙСА
        private void InitInterface()
        {
            FileToolStripMenuItem.Text = lang.getString("file");
            ViewToolStripMenuItem.Text = lang.getString("view");
            Instruments_ToolStripMenuItem.Text = lang.getString("instruments");
            HelpToolStripMenuItem.Text = lang.getString("help");

            CreatePt_ToolStripMenuItem.Text = lang.getString("create_project");
            Open_ToolStripMenuItem.Text = lang.getString("open");
            Exit_ToolStripMenuItem.Text = lang.getString("exit");

            MapPanel_ToolStripMenuItem1.Text = lang.getString("map_panel");
            MainPanel_ToolStripMenuItem.Text = lang.getString("main_panel");
            StatusToolStripMenuItem.Text = lang.getString("status");
            Fullscreen_ToolStripMenuItem.Text = lang.getString("fullscreen");

            toolStripLabel1.Text = lang.getString("bearing");

            SettingsToolStripMenuItem.Text = lang.getString("settings");

            AboutToolStripMenuItem.Text = lang.getString("about");

            Zoom_toolStripLabel.Text = lang.getString("zoom");
            tabPage5.Text = lang.getString("general");
            label1.Text = lang.getString("satellites");
            label7.Text = lang.getString("position");
            label9.Text = lang.getString("speed");
            CurLocation_toolStripButton.Text = lang.getString("curLoc");
            GPS_tab_toolStripButton.Text = lang.getString("gps_data");
            panel2.Tag = lang.getString("gps_data").ToUpper();
            Markers_toolStripButton.Text = lang.getString("markers");
            panel1.Tag = lang.getString("markers").ToUpper();
            RecStop_toolStripButton.Text = lang.getString("rec");
            GPS_indicator.Text = lang.getString("receiver");

            ToolStripLabelTextTemp = lang.getString("ready");
            toolStripStatusLabel1.Text = ToolStripLabelTextTemp;

            изменитьToolStripMenuItem.Text = lang.getString("edit");
            удалитьToolStripMenuItem.Text = lang.getString("delete");

            // Название окна
            Text = Application.ProductName;

            // Индикаторы на строке состояния - справа
            GPS_indicator.Alignment = ToolStripItemAlignment.Right;
            Echolot_indicator.Alignment = ToolStripItemAlignment.Right;
        }

        // СКАНИРОВАНИЕ ДОСТУПНЫХ ПОРТОВ
        private bool ScanPorts()
        {
            string[] ports = SerialPort.GetPortNames(); // Получить все доступные порты
            foreach (string port in ports)
                if (port == GPS_Port) // Если найден порт, выбранный ранее в настройках ...
                    return true; // ... то возвращаем истину
            return false;
        }

        // РАБОТА С GPS
        private void GPS_Work()
        {
            timer.Tick += new EventHandler(GPS_Update);

            // Если порт не пустой ...
            if (port != null)
            {
                try
                {
                    // ... то попробовать открыть этот порт
                    port.Open();

                    // Если порт открыт ...
                    if (port.IsOpen)
                    {
                        GGA_textBox.Text = RMC_textBox.Text = GSV_textBox.Text = GSA_textBox.Text = lang.getString("receiver_wait");

                        // ... то запустить приём сообщений с приёмника
                        timer.Enabled = true;
                        timer.Start();
                    }
                }
                catch (IOException)
                {
                    timer.Enabled = false;
                    timer.Dispose();
                    port = null;
                    GGA_textBox.Text = RMC_textBox.Text = GSV_textBox.Text = GSA_textBox.Text = lang.getString("receiver_not");
                }
            }
            else
            {
                timer.Enabled = false;
                timer.Dispose();
                GGA_textBox.Text = RMC_textBox.Text = GSV_textBox.Text = GSA_textBox.Text = lang.getString("receiver_not");
            }
        }

        // ЗАКРЫТЬ ПОРТ С GPS
        private void GPS_Close_Port()
        {
            timer.Enabled = false;

            // Если порт не пустой ...
            if (port != null)
            {
                try
                {
                    // ... и если порт открыт ...
                    if (port.IsOpen)
                        // то попробовать закрыть этот порт
                        port.Close();

                    port.Dispose();
                }
                catch (IOException)
                {
                    port = null;
                }
            }
            port = null;
            IndicatorUI(GPS_indicator, -1);
        }

        // ОБНОВЛЕНИЕ ДАННЫХ С GPS
        private void GPS_Update(object sender, EventArgs e)
        {
            int status; // Статус подключения. 0 = ожидание, 1 = подключено, -1 = порт не найден.

            if (port != null)
            {
                if (port.IsOpen)
                {
                    status = 1;

                    string[] portLine = port.ReadExisting().Split('\n');
                    for (int i = 0; i < portLine.Length; i++)
                    {
                        if (portLine[i].StartsWith("$G") && portLine[i].Contains("*"))
                        {
                            nmea_parser = new NMEAparser(portLine[i]); // Считываем сообщение с порта, и проводим его через парсер
                            string type = nmea_parser.type;

                            if (type.EndsWith("RMC"))
                            {
                                RMC_textBox.Text = nmea_parser.Get_RMC();

                                // Координаты текущего местоположения
                                double lat = nmea_parser.Get_RMC_Latitude_Decimal();
                                if (lat != 0 && lat != -1)
                                    lat_gps = lat;

                                double lng = nmea_parser.Get_RMC_Longitude_Decimal();
                                if (lng != 0 && lng != -1)
                                    lng_gps = lng;

                                if (!move_after_start & lat != 0 && lat != -1 & lng != 0 && lng != -1)
                                {
                                    MapControl.Position = new PointLatLng(lat_gps, lng_gps);
                                    move_after_start = true;
                                }

                                if (nmea_parser.Get_RMC_Latitude_Deg() != -1)
                                    label8.Text = nmea_parser.Get_RMC_Latitude_Deg().ToString().Replace("-1", "-") + "° " + nmea_parser.Get_RMC_Latitude_Minute() + "' " + Math.Round(nmea_parser.Get_RMC_Latitude_Sec(), 2).ToString().Replace("-1", "-") + "'', " + nmea_parser.Get_RMC_Latitude_c_text()[0] + "\r\n"
                                        + nmea_parser.Get_RMC_Longitude_Deg().ToString().Replace("-1", "-") + "° " + nmea_parser.Get_RMC_Longitude_Minute() + "' " + Math.Round(nmea_parser.Get_RMC_Longitude_Sec(), 2).ToString().Replace("-1", "-") + "'', " + nmea_parser.Get_RMC_Longitude_c_text()[0];
                                else
                                    label8.Text = "--° --' --.--'' ?\r\n---° --' --.--'' ?";

                                label10.Text = nmea_parser.Get_RMC_Speed_Text();
                            }
                            else if (type.EndsWith("GSV"))
                            {
                                GSV_textBox.Text = nmea_parser.Get_GSV();

                                if (nmea_parser.Get_GSV_Number_Sat() > -1)
                                    label6.Text = nmea_parser.Get_GSV_Number_Sat() + "";
                                else
                                    label6.Text = "-";
                            }
                            else if (type.EndsWith("GSA"))
                            {
                                GSA_textBox.Text = nmea_parser.Get_GSA();

                                if (nmea_parser.Get_GSA_Prn_Num() > -1)
                                    label5.Text = nmea_parser.Get_GSA_Prn_Num() + "";
                                else
                                    label5.Text = "-";
                            }
                            else if (type.EndsWith("GGA"))
                            {
                                GGA_textBox.Text = nmea_parser.Get_GGA();
                            }
                        }
                    }
                }
                else
                {
                    status = 0;
                    GGA_textBox.Text = RMC_textBox.Text = GSV_textBox.Text = GSA_textBox.Text = "Ожидание приёмника";
                }
            }
            else
            {
                status = -1;
                GGA_textBox.Text = RMC_textBox.Text = GSV_textBox.Text = GSA_textBox.Text = "Приёмник не подключен";
            }

            IndicatorUI(GPS_indicator, status);

            Application.DoEvents();
        }

        // ОБНОВЛЕНИЕ ИНДИКАТОРОВ
        private void IndicatorUI(ToolStripLabel label, int status)
        {
            Color c1 = Color.White, c2 = Color.Black;
            bool enabled = false;

            if (status == 1) // ПОДКЛЮЧЕНО
            {
                c1 = label.BackColor == Color.Green ? Color.DarkGreen : Color.Green;
                c2 = Color.SpringGreen;
                enabled = true;
            }
            else if (status == -1) // НЕ ПОДКЛЮЧЕНО
            {
                c1 = Color.Maroon;
                c2 = Color.Red;
                enabled = false;
            }
            else if (status == 0) // ОЖИДАНИЕ
            {
                c1 = Color.Yellow;
                c2 = Color.DarkGoldenrod;
                enabled = false;
            }

            label.BackColor = c1;
            label.ForeColor = c2;

            // ЕСЛИ СТАТУС 0 или -1, ТО БЛОКИРОВАТЬ КНОПКИ
            CurLocation_toolStripButton.Enabled = enabled;
            RecStop_toolStripButton.Enabled = enabled && (ProjectName != "");

            //MarkerAdd_toolStripButton.Enabled = enabled && (ProjectName != "");
            MarkerAdd_toolStripButton.Enabled = true;
        }

        // ПОЛУЧИТЬ ТЕКУЩЕЕ МЕСТОПОЛОЖЕНИЕ
        private void CurLocationButton_Click(object sender, EventArgs e)
        {
            if (port != null && nmea_parser != null)
                MapControl.Position = new PointLatLng(lat_gps, lng_gps);
        }

        // ЗАПИСЬ МАРШРУТА
        private void RecStopButton_Click(object sender, EventArgs e)
        {
            if (ProjectName != null)
            {
                if (!Rec)
                {
                    Rec = true;

                    // Имя файла (Дата_Время.rec)
                    recFileName = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".rec";
                    writetext = new StreamWriter(path + "\\Records\\" + recFileName);

                    // Запись начальных данных
                    writetext.WriteLine("Color: Aqua");

                    if (lat_gps != 0 && lng_gps != 0)
                        MapControl.Position = new PointLatLng(lat_cur, lng_cur);

                    polyOverlay_for_rec = new GMapOverlay("polygons_for_rec");

                    if (points == null)
                        points = new List<PointLatLng> { };

                    polygon_for_rec = new GMapRoute(points, "mypolygon2")
                    {
                        Stroke = new Pen(Color.Aqua, 3)
                    };

                    timerRec.Enabled = true;
                    timerRec.Start();
                }
                else
                {
                    Rec = false;

                    RecStop_toolStripButton.Image = Properties.Resources.rec;

                    time = 0;

                    recFileName = "";
                    writetext.Close();

                    timerRec.Stop();
                    timerRec.Enabled = false;
                    timerRec.Dispose();
                    writetext.Dispose();

                    if (polygon_for_rec != null)
                        MapControl.ZoomAndCenterRoute(polygon_for_rec);
                }
                toolStripStatusLabel2.Visible = Rec;
            }
        }

        // ЗАПИСЬ МАРШРУТА (ТАЙМЕР)
        private void RecStart(object sender, EventArgs e)
        {
            if (Rec && nmea_parser != null && ProjectName != null)
            {
                if (lat_gps != 0 && lng_gps != 0)
                {
                    // Текущая дата и время
                    string dt = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond;

                    // Запись строки со значениями в файл (Дата_Время, Широта, Долгота, Глубина)
                    writetext.WriteLine(dt + " " + lat_gps + " " + lng_gps + " " + 0);

                    if (points == null)
                        points.Add(new PointLatLng(lat_gps, lng_gps));

                    polyOverlay_for_rec.Routes.Add(polygon_for_rec);
                    MapControl.Overlays.Add(polyOverlay_for_rec);
                }

                time += timerRec.Interval;
                TimeSpan time1 = TimeSpan.FromMilliseconds(time);
                string text = new DateTime(time1.Ticks).ToString("HH:mm:ss");
                toolStripStatusLabel2.Text = "● " + text;
            }
        }

        // СОЗДАНИЕ ПРОЕКТА
        private void CreatePtMenuItem_Click(object sender, EventArgs e)
        {
            New_Project new_Project = new New_Project();
            if (new_Project.ShowDialog() == DialogResult.OK)
            {
                // Имя проекта
                ProjectName = new_Project.GetName();

                // Полный путь
                path = new_Project.GetUri() + "\\" + ProjectName;

                try
                {
                    // Если папка по такому пути существует
                    if (Directory.Exists(path))
                    {
                        MessageBox.Show(lang.getString("error"), lang.getString("folder_exists"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Создание папок (главная, маркеры, записи, карты)
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    DirectoryInfo di1 = Directory.CreateDirectory(path + "\\Markers");
                    DirectoryInfo di2 = Directory.CreateDirectory(path + "\\Records");
                    DirectoryInfo di3 = Directory.CreateDirectory(path + "\\Maps");

                    // Создание файла со свойствами
                    string txt = "Created=" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + "\r\n" +
                        "Modified=" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                    File.WriteAllText(path + "\\vlkGIS_Project.info", txt);

                    markers = new GMapOverlay("Markers");
                    using (XmlWriter writer = XmlWriter.Create(path + "\\Markers\\markers.xml"))
                    {
                        writer.WriteStartDocument(true);
                        writer.WriteStartElement("Markers");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Dispose();
                    }

                    // Активация кнопок
                    Markers_toolStripButton.Enabled = true;

                    // Обновить название окна
                    Text = Application.ProductName + " | " + ProjectName;

                    RecentUpdate(path);
                }
                catch (Exception) { }
                finally
                {
                    new_Project.Dispose();
                }
            }
            new_Project.Dispose();
        }

        // ОТКРЫТЬ ПРОЕКТ
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenProject(folderBrowserDialog1.SelectedPath);
                RecentUpdate(folderBrowserDialog1.SelectedPath);
            }
        }

        private void RecentUpdate(string uri)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (i == 9)
                {
                    if (items[i].Tag.ToString() != "")
                    {
                        for (int a = 0; a < items.Length - 1; a++)
                        {
                            items[a].Name = items[a + 1].Name;
                            items[a].Tag = items[a + 1].Tag;
                            items[a].Text = items[a + 1].Text;
                        }
                        RecentOpen = RecentOpen.Remove(0, RecentOpen.IndexOf('?') + 1);
                        items[i].Tag = "";
                    }
                }

                if (items[i].Tag.ToString() == "")
                {
                    items[i].Name = "RecentItem" + i.ToString();
                    items[i].Tag = uri;
                    items[i].Text = Path.GetFileName(uri);
                    items[i].Visible = true;
                    RecentOpen += path + "?";
                    File.WriteAllText("recent.txt", RecentOpen);
                    break;
                }
            }
        }

        private void OpenProject(string uri)
        {
            if (File.Exists(uri + "\\vlkGIS_Project.info"))
            {
                if (ProjectName != null)
                    MapControl.Overlays.Clear();

                // Полный путь
                path = uri;

                // Имя проекта
                ProjectName = Path.GetFileName(uri);

                // Обновить название окна
                Text = Application.ProductName + " | " + ProjectName;

                // Активация кнопок
                Markers_toolStripButton.Enabled = true;

                LoadInfo();
                LoadMapCache();
                LoadMap();
                if (File.Exists(path + "\\Markers\\markers.xml"))
                    LoadMarkers();
            }
        }

        // ЗАГРУЗКА ИНФОРМАЦИИ О ПРОЕКТЕ ИЗ ФАЙЛА
        private void LoadInfo()
        {
            string file = path + "\\" + "vlkGIS_Project.info";
            if (File.Exists(file))
                project_info = File.ReadAllLines(file);
        }

        // ЗАГРУЗКА МАРКЕРОВ
        private void LoadMarkers()
        {
            xDoc = new XmlDocument();
            xDoc.Load(path + "\\Markers\\markers.xml");
            markers = new GMapOverlay("Markers");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            GMapMarker marker;
            // обход всех узлов в корневом элементе
            int i = 0;
            MapControl.Overlays.Add(markers);
            foreach (XmlNode xnode in xRoot)
            {
                double lat = 0, lng = 0;
                string color = "";
                string text = "";

                // получаем атрибут Date
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("Date");
                    if (attr != null)
                        text = attr.Value;
                    listView1.Items.Add(text);
                }

                listView1.Items[i].SubItems.Add(text);

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    listView1.Items[i].SubItems.Add(childnode.InnerText);

                    if (childnode.Name == "Name")
                    {
                        if (childnode.InnerText != "")
                        {
                            text = childnode.InnerText;
                            listView1.Items[i].Text = text;
                        }
                    }
                    if (childnode.Name == "Lat")
                    {
                        lat = Convert.ToDouble(childnode.InnerText);
                    }
                    if (childnode.Name == "Lng")
                    {
                        lng = Convert.ToDouble(childnode.InnerText);
                    }
                    if (childnode.Name == "Color")
                    {
                        color = childnode.InnerText;
                    }
                }

                marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new PointLatLng(lat, lng),
                    ChangeMarkerColor(color)
                    )
                {
                    Tag = text
                };
                markers.Markers.Add(marker);

                i += 1;
            }
        }

        private GMap.NET.WindowsForms.Markers.GMarkerGoogleType ChangeMarkerColor(string col)
        {
            switch (col)
            {
                case "LightBlue":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.lightblue;
                case "Yellow":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow;
                case "Green":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.green;
                case "Red":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red;
                case "Orange":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.orange;
                case "Pink":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink;
                case "Blue":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue;
                case "Purple":
                    return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple;
            }
            return GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue;
        }

        // ЗАГРУЗКА КАРТЫ
        private void LoadMapCache()
        {
            if (Directory.Exists(path + "\\Maps\\TileDBv5"))
            {
                MapControl.Manager.Mode = AccessMode.CacheOnly;
                MapControl.CacheLocation = path + "\\Maps";
            }
            else
            {
                MapControl.Manager.Mode = AccessMode.ServerAndCache;
            }
        }

        // ЗАГРУЗКА МАРШРУТОВ ИЗ ФАЙЛОВ
        private void LoadMap()
        {
            // ПОЛУЧЕНИЕ ВСЕХ ФАЙЛОВ С МАРШРУТАМИ ИЗ ПАПКИ
            DirectoryInfo d = new DirectoryInfo(path + "\\Records\\");
            FileInfo[] Files = d.GetFiles("*.rec");

            foreach (FileInfo file in Files)
            {
                polyOverlay_for_open = new GMapOverlay("polygons_for_open");

                points = new List<PointLatLng> { };

                Color c = Color.White;

                string[] lines = File.ReadAllLines(file.FullName);

                int i = 0, step = 0;
                double point1 = 0, point2 = 0;
                //double point1tmp1 = 0, point2tmp1 = 0;
                double point1tmp2 = 0, point2tmp2 = 0;
                double FilterLat = 0, FilterLng = 0;

                for (int ii = 0; ii < lines.Length; ii++)
                {
                    string[] info = lines[ii].Split(' ');
                    if (lines[ii].StartsWith("Color"))
                    {
                        c = Color.FromName(info[1]);
                    }
                    else if (lines[ii].StartsWith("Smoothing"))
                    {
                        step = int.Parse(info[1]);
                    }
                    else if (lines[ii].StartsWith("FilterLat"))
                    {
                        FilterLat = double.Parse(info[1]);
                    }
                    else if (lines[ii].StartsWith("FilterLng"))
                    {
                        FilterLng = double.Parse(info[1]);
                    }
                    else
                    {
                        if (ii == 0 || ii == lines.Length - 1 || step == 0)
                            points.Add(new PointLatLng(Convert.ToDouble(info[1]), Convert.ToDouble(info[2])));
                        else
                        {
                            if (i < step)
                            {
                                double point1tmp1 = Convert.ToDouble(info[1]);
                                double point2tmp1 = Convert.ToDouble(info[2]);

                                if ((point1tmp2 != 0 & point2tmp2 != 0) &
                                    (Math.Abs(point1tmp1 - point1tmp2) < FilterLat &
                                    (Math.Abs(point2tmp1 - point2tmp2) < FilterLng)))
                                {
                                    point1 += point1tmp1;
                                    point2 += point2tmp1;
                                    i += 1;
                                }

                                point1tmp2 = point1tmp1;
                                point2tmp2 = point2tmp1;
                            }
                            else
                            {
                                if (point1 != 0 & point2 != 0)
                                    points.Add(new PointLatLng(point1 / i, point2 / i));
                                point1 = 0;
                                point2 = 0;
                                i = 0;
                                if (SmoothingType == 1)
                                    ii -= step;
                            }
                        }
                    }
                }

                polygon_for_open = new GMapRoute(points, "mypolygon_open")
                {
                    Stroke = new Pen(c, WidthLine)
                };

                polyOverlay_for_open.Routes.Add(polygon_for_open);
                MapControl.Overlays.Add(polyOverlay_for_open);

                string[] a = lines[4].Split(' ');
                lat_cur = Convert.ToDouble(a[1]);
                lng_cur = Convert.ToDouble(a[2]);
                MapControl.Position = new PointLatLng(lat_cur, lng_cur);
                MapControl.ZoomAndCenterRoute(polygon_for_open);
            }
        }

        // ЗАКРЫТЬ
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ПОКАЗАТЬ/СКРЫТЬ ПАНЕЛЬ КАРТЫ
        private void PanelMapMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip2.Visible = MapPanel_ToolStripMenuItem1.Checked;
        }

        // ПОКАЗАТЬ/СКРЫТЬ ПАНЕЛЬ СЛЕВА
        private void PanelLeftMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !MainPanel_ToolStripMenuItem.Checked;
        }

        // ПОКАЗАТЬ/СКРЫТЬ СТАТУСНУЮ СТРОКУ
        private void StatusMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = StatusToolStripMenuItem.Checked;
        }

        // КНОПКА ПОЛНОЭКРАННЫЙ/ОКОННЫЙ РЕЖИМ
        private void FullScreenMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen();
        }

        // ВЫХОД ИЗ ПОЛНОЭКРАННОГО РЕЖИМА
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                if (fullscreen)
                    FullScreen();
        }

        // ПОЛНОЭКРАННЫЙ/ОКОННЫЙ РЕЖИМ
        private void FullScreen()
        {
            toolStrip2.Visible = fullscreen;
            statusStrip1.Visible = fullscreen;
            splitContainer1.Panel1Collapsed = !fullscreen;
            menuStrip1.Visible = fullscreen;

            if (!fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else if (fullscreen)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }

            fullscreen = !fullscreen;
        }

        // ВЫЗОВ НАСТРОЕК
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            if (settings.ShowDialog() == DialogResult.OK)
            {
                Start(false);
            }
            settings.Dispose();
        }

        // О ПРОГРАММЕ
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
            aboutBox.Dispose();
        }

        // ДЕЙСТВИЯ ПРИ ПЕРЕМЕЩЕНИИ КАРТЫ
        private void GMapControl1_OnMapDrag()
        {
            lat_cur = MapControl.Position.Lat;
            lng_cur = MapControl.Position.Lng;
        }

        // ДЕЙСТВИЯ ПРИ ИЗМЕНЕНИИ МЕСТОПОЛОЖЕНИЯ
        private void GMapControl1_OnPositionChanged(PointLatLng point)
        {
            string t_lat, t_lng;

            if (lat_cur < 0)
                t_lat = lang.getString("s_c");
            else
                t_lat = lang.getString("n_c");

            if (lng_cur < 0)
                t_lng = lang.getString("w_c");
            else
                t_lng = lang.getString("e_c");

            Lat_toolStripLabel.Text = Math.Abs(Math.Round(point.Lat, 6)).ToString("0.000000", cultureInfo) + "° " + t_lat;
            Lng_toolStripLabel.Text = Math.Abs(Math.Round(point.Lng, 6)).ToString("0.000000", cultureInfo) + "° " + t_lng;
        }

        // ДЕЙСТВИЯ ПРИ НАВЕДЕНИИ КУРСОРА НА КНОПКУ ПАНЕЛИ
        private void ToolStripButton_MouseEnter(object sender, EventArgs e)
        {
            ToolStripLabelTextTemp = toolStripStatusLabel1.Text;
            toolStripStatusLabel1.Text = ((ToolStripButton)sender).Text;
        }

        // ДЕЙСТВИЯ ПРИ НАВЕДЕНИИ КУРСОРА ОТ КНОПКИ ПАНЕЛИ
        private void ToolStripButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = ToolStripLabelTextTemp;
        }

        // ВЫЗОВ ДИАЛОГА ДЛЯ УСТАНОВКИ ДОЛГОТЫ И ШИРОТЫ
        private void ToolStripLabel2_Click(object sender, EventArgs e)
        {
            EnterLatLng enterLatLng = new EnterLatLng(lat_cur, lng_cur);
            if (enterLatLng.ShowDialog() == DialogResult.OK)
            {
                lat_cur = enterLatLng.GetLan();
                lng_cur = enterLatLng.GetLng();
                MapControl.Position = new PointLatLng(lat_cur, lng_cur);
                //SetTextMap();
            }
            enterLatLng.Dispose();
        }

        // ОБНОВЛЕНИЕ ПОЛЯ С МАСШТАБОМ
        private void MapControl_OnMapZoomChanged()
        {
            Zoom_toolStripTextBox.Text = "1:" + zoom[(int)MapControl.Zoom - 1];
            GMapControl1_OnMapDrag();
            GMapControl1_OnPositionChanged(MapControl.Position);
        }

        // ДЕЙСТВИЯ ПРИ ЗАКРЫТИИ ФОРМЫ
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Rec)
                {
                    notifyIcon1.Visible = true;
                    Hide();
                    e.Cancel = true;
                }
            }

            if (port != null)
                if (port.IsOpen)
                    if (!Rec)
                        port.Close();
        }

        // КНОПКА ПЕРЕКЛЮЧЕНИЯ НА ПАНЕЛЬ МАРКЕРЫ
        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            Tabs(1);
        }

        // КНОПКА ПЕРЕКЛЮЧЕНИЯ НА ПАНЕЛЬ ДАННЫЕ С GPS
        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            Tabs(0);
        }

        // КНОПКА ДЛЯ УВЕЛИЧЕНИЯ МАСШТАБА
        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            MapControl.Zoom += 1;
        }

        // КНОПКА ДЛЯ УМЕНЬШЕНИЯ МАСШТАБА
        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            MapControl.Zoom -= 1;
        }

        // ПОДЧЁРКИВАНИЕ LABEL ШИРОТЫ/ДОЛГОТЫ ПРИ НАВЕДЕНИИ МЫШИ
        private void Lat_Lng_toolStripLabel_MouseEnter(object sender, EventArgs e)
        {
            ((ToolStripLabel)sender).Font = new Font(((ToolStripLabel)sender).Font.Name, ((ToolStripLabel)sender).Font.SizeInPoints, FontStyle.Underline);
        }

        // УБРАТЬ ПОДЧЁРКИВАНИЕ LABEL ШИРОТЫ/ДОЛГОТЫ ПРИ ОТВЕДЕНИИ МЫШИ
        private void Lat_Lng_toolStripLabel_MouseLeave(object sender, EventArgs e)
        {
            ((ToolStripLabel)sender).Font = new Font(((ToolStripLabel)sender).Font.Name, ((ToolStripLabel)sender).Font.SizeInPoints, FontStyle.Regular);
        }

        // КНОПКА ДОБАВИТЬ НОВЫЙ МАРКЕР
        private void MarkerAdd_toolStripButton_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(path + "\\Markers\\markers.xml");
            XElement root = new XElement("Marker");
            string dt = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            root.Add(new XAttribute("Date", dt));
            root.Add(new XElement("Name", ""));
            root.Add(new XElement("Desc", ""));
            root.Add(new XElement("Lat", lat_gps));
            root.Add(new XElement("Lng", lng_gps));
            root.Add(new XElement("Pic", ""));
            root.Add(new XElement("Color", ""));
            doc.Element("Markers").Add(root);
            doc.Save(path + "\\Markers\\markers.xml");

            GMapMarker marker =
                new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    new PointLatLng(lat_gps, lng_gps),
                    GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue
                    );
            markers.Markers.Add(marker);
            MapControl.Overlays.Add(markers);

            listView1.Items.Add(dt);
        }

        // ДВОЙНОЕ НАЖАТИЕ НА ЭЛЕМЕНТ СПИСКА С МАРКЕРАМИ
        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (_lastButtonUp == MouseButtons.Left)
            {
                Click_on_list();
            }
        }

        // ВЫЗОВ ДИАЛОГА С ВЫБРАННЫМ МАРКЕРОМ
        private void Click_on_list()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string date = listView1.SelectedItems[0].SubItems[1].Text;

                MarkerEdit markerEdit = new MarkerEdit(
                    date,
                    listView1.SelectedItems[0].SubItems[2].Text,
                    listView1.SelectedItems[0].SubItems[3].Text,
                    listView1.SelectedItems[0].SubItems[4].Text,
                    listView1.SelectedItems[0].SubItems[5].Text,
                    listView1.SelectedItems[0].SubItems[6].Text,
                    listView1.SelectedItems[0].SubItems[7].Text
                    );

                if (markerEdit.ShowDialog() == DialogResult.OK)
                {
                    xDoc.SelectSingleNode("/Markers/Marker[@Date='" + date + "']/Name").InnerText = markerEdit.GetName();
                    xDoc.SelectSingleNode("/Markers/Marker[@Date='" + date + "']/Lat").InnerText = markerEdit.GetLat();
                    xDoc.SelectSingleNode("/Markers/Marker[@Date='" + date + "']/Lng").InnerText = markerEdit.GetLng();
                    xDoc.SelectSingleNode("/Markers/Marker[@Date='" + date + "']/Desc").InnerText = markerEdit.GetDesc();
                    xDoc.SelectSingleNode("/Markers/Marker[@Date='" + date + "']/Pic").InnerText = markerEdit.GetPics();
                    xDoc.SelectSingleNode("/Markers/Marker[@Date='" + date + "']/Color").InnerText = markerEdit.GetColor();

                    string name = markerEdit.GetName();

                    if (name != "")
                        listView1.SelectedItems[0].Text = name;
                    else
                        listView1.SelectedItems[0].Text = date;

                    listView1.SelectedItems[0].SubItems[2].Text = name;
                    listView1.SelectedItems[0].SubItems[3].Text = markerEdit.GetDesc();
                    listView1.SelectedItems[0].SubItems[4].Text = markerEdit.GetLat();
                    listView1.SelectedItems[0].SubItems[5].Text = markerEdit.GetLng();
                    listView1.SelectedItems[0].SubItems[6].Text = markerEdit.GetPics();
                    listView1.SelectedItems[0].SubItems[7].Text = markerEdit.GetColor();

                    string copy = markerEdit.GetCopyPic();
                    if (copy != "")
                    {
                        string newDir = path + "\\Markers\\" + date;
                        if (!Directory.Exists(newDir))
                            Directory.CreateDirectory(newDir);

                        string[] c = copy.Split(',');
                        for (int i = 0; i < c.Length; i++)
                            File.Copy(c[i], newDir + "\\" + Path.GetFileName(c[i]));
                    }

                    string delete = markerEdit.GetDeletedPic();
                    if (delete != "")
                    {
                        string[] d = delete.Split(',');
                        for (int i = 0; i < d.Length; i++)
                            File.Delete(d[i]);

                        if (Directory.GetFiles(Path.GetDirectoryName(d[0])).Length == 0)
                            Directory.Delete(Path.GetDirectoryName(d[0]));
                    }

                    GMap.NET.WindowsForms.Markers.GMarkerGoogle marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                        new PointLatLng(Convert.ToDouble(markerEdit.GetLat()), Convert.ToDouble(markerEdit.GetLng())),
                        ChangeMarkerColor(listView1.SelectedItems[0].SubItems[7].Text))
                    {
                        Tag = listView1.SelectedItems[0].Text
                    };

                    markers.Markers[listView1.SelectedItems[0].Index] = marker;

                    //markers.Markers[listView1.SelectedItems[0].Index].Position = new PointLatLng(Convert.ToDouble(markerEdit.GetLat()), Convert.ToDouble(markerEdit.GetLng()));

                    xDoc.Save(path + "\\Markers\\markers.xml");
                }
            }
        }

        // НАЖАТИЕ КНОПКАМИ НА КЛАВИАТУРЕ НА МАРКЕР В СПИСКЕ
        private void ListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Click_on_list();
            }
        }

        private void ListView1_MouseUp(object sender, MouseEventArgs e)
        {
            _lastButtonUp = e.Button;
        }

        // ДВОЙНОЕ НАЖАТИЕ НА МАРКЕР НА КАРТЕ
        private void MapControl_OnMarkerDoubleClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Click_on_list();
        }

        // НАЖАТИЕ НА МАРКЕР НА КАРТЕ
        private void MapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                selectedListMarkers = item;
                listView1.FindItemWithText(selectedListMarkers.Tag.ToString()).Selected = true;
                listView1.Select();
                if (e.Button == MouseButtons.Right)
                    contextMenuStrip1.Show(Cursor.Position);
            }
        }

        // ДЕЙСТВИЯ ПРИ ЗАКРЫТИИ ФОРМЫ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            INI.Write("Last", "Lat", lat_cur.ToString());
            INI.Write("Last", "Lng", lng_cur.ToString());
            INI.Write("Last", "Zoom", MapControl.Zoom.ToString());
            INI.Write("Last", "Bearing", MapControl.Bearing.ToString());
        }

        // КНОПКА УДАЛЕНИЯ МАРКЕРА
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                if (xDoc != null)
                {
                    XmlElement el = (XmlElement)xDoc.SelectSingleNode("/Markers/Marker[@Date='" + selectedListMarkers.Tag.ToString() + "']");
                    el.ParentNode.RemoveChild(el);
                    xDoc.Save(path + "\\Markers\\markers.xml");
                }
                listView1.FindItemWithText(selectedListMarkers.Tag.ToString()).Remove();
                markers.Markers.Remove(selectedListMarkers);
                selectedListMarkers = null;
            }
        }

        // НАЖАТИЕ НА ЭЛЕМЕНТ СПИСКА С МАРКЕРАМИ
        private void ListView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    selectedListMarkers = markers.Markers[listView1.SelectedItems[0].Index];
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Click_on_list();
        }

        private void MapControl_OnMarkerEnter(GMapMarker item)
        {
            toolTip1.Show(item.Tag.ToString(), MapControl);
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MapControl.Bearing = float.Parse(toolStripTextBox1.Text);
            }
        }

        private void MapControl_OnMarkerLeave(GMapMarker item)
        {
            toolTip1.Hide(MapControl);
        }

        // ДВОЙНОЕ НАЖАТИЕ НА ИКОНКУ В ТРЕЕ
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                lastBearing = MapControl.Bearing;
                mousePosition = MousePosition.X;
            }
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                bearing = lastBearing + (MousePosition.X - mousePosition) / 10;
                MapControl.Bearing = bearing;
                toolStripTextBox1.Text = bearing + "";
            }
        }
    }
}
