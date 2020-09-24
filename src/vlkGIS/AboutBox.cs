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
            labelVersion.Text = Form1.lang.getString("version") + Assembly.GetExecutingAssembly().GetName().Version;
            labelCopyright.Text = Form1.lang.getString("author");
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://vlkapps.ru/");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:vlkden@yandex.ru");
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:support@vlkapps.ru");
        }
    }
}
