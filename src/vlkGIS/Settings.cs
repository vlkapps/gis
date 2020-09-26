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
                comboBox1.Items.Add(port);

            foreach (int s in Form1.speed)
                comboBox2.Items.Add(s);

            foreach (string m in Form1.maps)
                comboBox3.Items.Add(m);

            button3.Enabled = (comboBox1.SelectedIndex != -1);

            if (Form1.GPS_Port != "")
                for (int i = 0; i < comboBox1.Items.Count; i++)
                    if (comboBox1.Items[i].ToString() == Form1.GPS_Port)
                    {
                        comboBox1.SelectedItem = Form1.GPS_Port;
                        break;
                    }
            
            comboBox2.SelectedIndex = Form1.GPS_Speed;
            comboBox4.SelectedIndex = Form1.GPS_Accuracy;
            comboBox3.SelectedIndex = Form1.Map_Service;

            if (Form1.Language == "en")
                comboBox5.SelectedIndex = 0;
            else if(Form1.Language == "ru")
                comboBox5.SelectedIndex = 1;

            comboBox6.SelectedIndex = Form1.SmoothingType;
            numericUpDown1.Value = Form1.WidthLine;

            if (Form1.Map_Layer == 0) radioButton1.Checked = true;
            else if (Form1.Map_Layer == 1) radioButton2.Checked = true;
            else if (Form1.Map_Layer == 2) radioButton3.Checked = true;
        }

        private void InitString()
        {
            lang = new Language(language);

            Text = lang.getString("settings_");
            groupBox5.Text = lang.getString("ui");
            label6.Text = lang.getString("language");
            groupBox1.Text = lang.getString("sat_receiver");
            label2.Text = lang.getString("port");
            label3.Text = lang.getString("speed");
            button3.Text = lang.getString("test");
            label4.Text = lang.getString("accuracy");
            button2.Text = lang.getString("ok");
            button1.Text = lang.getString("cancel");
            
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new string[] { lang.getString("veryHigh"), lang.getString("high"), lang.getString("normal"), lang.getString("low"), lang.getString("veryLow"), lang.getString("users") });
            comboBox4.SelectedIndex = Form1.GPS_Accuracy;

            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(new string[] { lang.getString("smooth_a"), lang.getString("smooth_b") });
            comboBox6.SelectedIndex = Form1.SmoothingType;

            groupBox3.Text = lang.getString("route");
            label8.Text = lang.getString("smoothing_method");
            label5.Text = lang.getString("width_line");
            groupBox2.Text = lang.getString("Maps");
            label1.Text = lang.getString("map_provider");
            radioButton1.Text = lang.getString("map_scheme");
            radioButton2.Text = lang.getString("map_satellite");
            radioButton3.Text = lang.getString("map_hybrid");
        }

        public string GetPort()
        {
            if (comboBox1.SelectedIndex > -1)
                return comboBox1.SelectedItem.ToString();
            else
                return "";
        }

        public int GetSpeed()
        {
            return int.Parse(comboBox2.SelectedIndex.ToString());
        }

        public int GetAccuracy()
        {
            return comboBox4.SelectedIndex;
        }

        public int GetMap()
        {
            return comboBox3.SelectedIndex;
        }

        public int GetMapLayer()
        {
            if (radioButton1.Checked)
                return 0;
            else if (radioButton2.Checked)
                return 1;
            else if (radioButton3.Checked)
                return 2;
            else
                return -1;
        }

        public int GetSmoothingType()
        {
            return comboBox6.SelectedIndex;
        }

        public int GetWidthLine()
        {
            return (int)numericUpDown1.Value;
        }

        public string GetLang()
        {
            if (comboBox5.SelectedIndex == 0)
            {
                return "en";
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                return "ru";
            } 
            else
                return "en";
        }

        private void Button2_Click(object sender, EventArgs e)
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = (comboBox1.SelectedIndex != -1);
        }

        private void ComboBox1_TextUpdate(object sender, EventArgs e)
        {
            button3.Enabled = (comboBox1.Text != "");
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == Form1.maps[2])
            {
                radioButton1.Checked = true;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            } 
            else
            {
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = lang.getString("intervalRead"), ms = lang.getString("millisecond");
            int i = 0;

            if (comboBox4.SelectedIndex == 0)
                i = 500;
            else if (comboBox4.SelectedIndex == 1)
                i = 750;
            else if (comboBox4.SelectedIndex == 2)
                i = 1000;
            else if (comboBox4.SelectedIndex == 3)
                i = 1500;
            else if (comboBox4.SelectedIndex == 4)
                i = 2000;

            label7.Text = t + i + ms;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
                language = "en";
            else if (comboBox5.SelectedIndex == 1)
                language = "ru";
            InitString();
        }
    }
}
