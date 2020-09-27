using System.Reflection;
using System.Windows.Forms;

namespace vlkGIS
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Text = Form1.lang.getString("about");
            Version_Label.Text = Form1.lang.getString("version") + Assembly.GetExecutingAssembly().GetName().Version;
            Copyright_Label.Text = Form1.lang.getString("author");
        }

        private void Web_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://vlkapps.ru/");
        }

        private void Mail1_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:vlkden@yandex.ru");
        }

        private void Mail2_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:support@vlkapps.ru");
        }
    }
}
