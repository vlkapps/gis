using vlkGIS.langs;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace vlkGIS
{
    public partial class Settings : Form
    {
        string language;
        Language lang;

        public Settings()
        {
            InitializeComponent();
            language = Form1.Language;
            InitString();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                Port_comboBox.Items.Add(port);

            foreach (int s in Form1.speed)
                Speed_comboBox.Items.Add(s);

            foreach (string m in Form1.maps)
                Map_comboBox.Items.Add(m);

            Test_button.Enabled = (Port_comboBox.SelectedIndex != -1);

            if (Form1.GPS_Port != "")
                for (int i = 0; i < Port_comboBox.Items.Count; i++)
                    if (Port_comboBox.Items[i].ToString() == Form1.GPS_Port)
                    {
                        Port_comboBox.SelectedItem = Form1.GPS_Port;
                        break;
                    }
            
            Speed_comboBox.SelectedIndex = Form1.GPS_Speed;
            Accuracy_comboBox.SelectedIndex = Form1.GPS_Accuracy;
            Map_comboBox.SelectedIndex = Form1.Map_Service;

            if (Form1.Language == "en")
                Language_comboBox.SelectedIndex = 0;
            else if (Form1.Language == "ru")
                Language_comboBox.SelectedIndex = 1;

            Smooth_comboBox.SelectedIndex = Form1.SmoothingType;
            Width_num.Value = Form1.WidthLine;

            if (Form1.Map_Layer == 0) Scheme_radioButton.Checked = true;
            else if (Form1.Map_Layer == 1) Satellite_radioButton.Checked = true;
            else if (Form1.Map_Layer == 2) Hybrid_radioButton.Checked = true;
        }

        private void InitString()
        {
            lang = new Language(language);

            Text = lang.getString("settings_");
            UI_groupBox.Text = lang.getString("ui");
            Language_label.Text = lang.getString("language");
            Satellite_groupBox.Text = lang.getString("sat_receiver");
            Port_label.Text = lang.getString("port");
            Speed_label.Text = lang.getString("speed");
            Test_button.Text = lang.getString("test");
            Accuracy_label.Text = lang.getString("accuracy");
            OK_button.Text = lang.getString("ok");
            Cancel_button.Text = lang.getString("cancel");
            
            Accuracy_comboBox.Items.Clear();
            Accuracy_comboBox.Items.AddRange(new string[] { lang.getString("veryHigh"), lang.getString("high"), lang.getString("normal"), lang.getString("low"), lang.getString("veryLow"), lang.getString("users") });
            Accuracy_comboBox.SelectedIndex = Form1.GPS_Accuracy;

            Smooth_comboBox.Items.Clear();
            Smooth_comboBox.Items.AddRange(new string[] { lang.getString("smooth_a"), lang.getString("smooth_b") });
            Smooth_comboBox.SelectedIndex = Form1.SmoothingType;

            Route_groupBox.Text = lang.getString("route");
            Smooth_label.Text = lang.getString("smoothing_method");
            Width_label.Text = lang.getString("width_line");
            Maps_groupBox.Text = lang.getString("Maps");
            Map_label.Text = lang.getString("map_provider");
            Scheme_radioButton.Text = lang.getString("map_scheme");
            Satellite_radioButton.Text = lang.getString("map_satellite");
            Hybrid_radioButton.Text = lang.getString("map_hybrid");
        }

        public string GetPort()
        {
            if (Port_comboBox.SelectedIndex > -1)
                return Port_comboBox.SelectedItem.ToString();
            else
                return "";
        }

        public int GetSpeed()
        {
            return int.Parse(Speed_comboBox.SelectedIndex.ToString());
        }

        public int GetAccuracy()
        {
            return Accuracy_comboBox.SelectedIndex;
        }

        public int GetMap()
        {
            return Map_comboBox.SelectedIndex;
        }

        public int GetMapLayer()
        {
            if (Scheme_radioButton.Checked)
                return 0;
            else if (Satellite_radioButton.Checked)
                return 1;
            else if (Hybrid_radioButton.Checked)
                return 2;
            else
                return -1;
        }

        public int GetSmoothingType()
        {
            return Smooth_comboBox.SelectedIndex;
        }

        public int GetWidthLine()
        {
            return (int)Width_num.Value;
        }

        public string GetLang()
        {
            if (Language_comboBox.SelectedIndex == 0)
            {
                return "en";
            }
            else if (Language_comboBox.SelectedIndex == 1)
            {
                return "ru";
            } 
            else
                return "en";
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            Form1.INI.Write("GPS", "Port", GetPort());
            Form1.INI.Write("GPS", "Speed", GetSpeed() + "");
            Form1.INI.Write("GPS", "Accuracy", GetAccuracy() + "");
            Form1.INI.Write("Map", "Service", GetMap() + "");
            Form1.INI.Write("Map", "Layer", GetMapLayer() + "");
            Form1.INI.Write("UI", "Language", GetLang());

            Form1.INI.Write("Track", "SmoothingType", GetSmoothingType() + "");
            Form1.INI.Write("Track", "WidthLine", GetWidthLine() + "");
        }

        private void Port_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test_button.Enabled = (Port_comboBox.SelectedIndex != -1);
        }

        private void Port_ComboBox_TextUpdate(object sender, EventArgs e)
        {
            Test_button.Enabled = (Port_comboBox.Text != "");
        }

        private void Map_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Map_comboBox.SelectedItem.ToString() == Form1.maps[2])
            {
                Scheme_radioButton.Checked = true;
                Satellite_radioButton.Enabled = false;
                Hybrid_radioButton.Enabled = false;
            } 
            else
            {
                Satellite_radioButton.Enabled = true;
                Hybrid_radioButton.Enabled = true;
            }
        }

        private void Accuracy_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = lang.getString("intervalRead"), ms = lang.getString("millisecond");
            int i = 0;

            if (Accuracy_comboBox.SelectedIndex == 0)
                i = 500;
            else if (Accuracy_comboBox.SelectedIndex == 1)
                i = 750;
            else if (Accuracy_comboBox.SelectedIndex == 2)
                i = 1000;
            else if (Accuracy_comboBox.SelectedIndex == 3)
                i = 1500;
            else if (Accuracy_comboBox.SelectedIndex == 4)
                i = 2000;

            Interval_label.Text = t + i + ms;
        }

        private void Language_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language_comboBox.SelectedIndex == 0)
                language = "en";
            else if (Language_comboBox.SelectedIndex == 1)
                language = "ru";
            InitString();
        }
    }
}
