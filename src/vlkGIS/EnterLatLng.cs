using System;
using System.Globalization;
using System.Windows.Forms;

namespace vlkGIS
{
    public partial class EnterLatLng : Form
    {
        private double Lan;
        private double Lng;

        public EnterLatLng(double lan, double lng)
        {
            InitializeComponent();

            Text = Form1.lang.getString("enter_value");
            OK_button.Text = Form1.lang.getString("ok");
            Cancel_button.Text = Form1.lang.getString("cancel");
            Lat_label.Text = Form1.lang.getString("lat");
            Lng_label.Text = Form1.lang.getString("lng");
            Lat_comboBox.Items.AddRange(new string[] { Form1.lang.getString("north"), Form1.lang.getString("south") });
            Lng_comboBox.Items.AddRange(new string[] { Form1.lang.getString("west"), Form1.lang.getString("east") });

            string t1 = lan + "";
            string t2 = lng + "";

            if (lan < 0)
            {
                Lat_comboBox.SelectedIndex = 1;
                t1 = t1.Remove(0,1);
            }
            else
                Lat_comboBox.SelectedIndex = 0;

            if (lng < 0)
            {
                Lng_comboBox.SelectedIndex = 0;
                t2 = t2.Remove(0,1);
            }
            else
                Lng_comboBox.SelectedIndex = 1;

            Lat_textBox.Text = t1;
            Lng_textBox.Text = t2;
        }

        public double GetLan()
        {
            if (Lat_comboBox.SelectedIndex == 1)
                return -Lan;
            else
                return Lan;
        }

        public double GetLng()
        {
            if (Lng_comboBox.SelectedIndex == 0)
                return -Lng;
            else
                return Lng;
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(Lat_textBox.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out Lan) ||
                !double.TryParse(Lng_textBox.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out Lng))
            {
                OK_button.DialogResult = DialogResult.Cancel;
                MessageBox.Show(Form1.lang.getString("enter_value_error"));
            }
        }
    }
}
