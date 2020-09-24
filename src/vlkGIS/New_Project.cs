using System;
using System.Windows.Forms;

namespace vlkGIS
{
    public partial class New_Project : Form
    {
        public string name;
        public string uri;

        public New_Project()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return name;
        }

        public string GetUri()
        {
            return uri;
        }

        // СОЗДАТЬ ПРОЕКТ
        private void CreateButton_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        // ОБЗОР ПАПОК
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                uri = folderBrowserDialog1.SelectedPath;
                textBox2.Text = uri;
            }
        }

        private void New_Project_Load(object sender, EventArgs e)
        {
            Text = Form1.lang.getString("create_project");
            label1.Text = Form1.lang.getString("name_project");
            label2.Text = Form1.lang.getString("uri");
            button2.Text = Form1.lang.getString("explore");
            CreateButton.Text = Form1.lang.getString("create");
        }
    }
}
