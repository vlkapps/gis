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
            button1.Text = Form1.lang.getString("ok");
            button2.Text = Form1.lang.getString("cancel");
            label1.Text = Form1.lang.getString("lat");
            label2.Text = Form1.lang.getString("lng");
            comboBox1.Items.AddRange(new string[] { Form1.lang.getString("north"), Form1.lang.getString("south") });
            comboBox2.Items.AddRange(new string[] { Form1.lang.getString("west"), Form1.lang.getString("east") });

            string t1 = lan + "";
            string t2 = lng + "";

            if (lan < 0)
            {
                comboBox1.SelectedIndex = 1;
                t1 = t1.Remove(0,1);
            }
            else
                comboBox1.SelectedIndex = 0;

            if (lng < 0)
            {
                comboBox2.SelectedIndex = 0;
                t2 = t2.Remove(0,1);
            }
            else
                comboBox2.SelectedIndex = 1;

            textBox1.Text = t1;
            textBox2.Text = t2;
        }

        public double GetLan()
        {
            if (comboBox1.SelectedIndex == 1)
                return -Lan;
            else
                return Lan;
        }

        public double GetLng()
        {
            if (comboBox2.SelectedIndex == 0)
                return -Lng;
            else
                return Lng;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out Lan) ||
                !double.TryParse(textBox2.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out Lng))
            {
                button1.DialogResult = DialogResult.Cancel;
                MessageBox.Show("Введены неверные значения");
            }
        }
    }
}
