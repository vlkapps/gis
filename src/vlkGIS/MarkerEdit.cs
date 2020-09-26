using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace vlkGIS
{
    public partial class MarkerEdit : Form
    {
        string pic;
        string deletePic = "";
        string copyPic = "";
        string date;
        
        public MarkerEdit(string date, string name, string desc, string lat, string lng, string pic, string color)
        {
            InitializeComponent();

            Text = Form1.lang.getString("marker");
            groupBox1.Text = Form1.lang.getString("location");
            label1.Text = Form1.lang.getString("lat");
            label2.Text = Form1.lang.getString("lng");
            comboBox1.Items.AddRange(new string[] { Form1.lang.getString("north"), Form1.lang.getString("south") });
            comboBox2.Items.AddRange(new string[] { Form1.lang.getString("west"), Form1.lang.getString("east") });
            label3.Text = Form1.lang.getString("name");
            label4.Text = Form1.lang.getString("desc");
            label5.Text = Form1.lang.getString("images");
            button3.Text = Form1.lang.getString("add");
            button1.Text = Form1.lang.getString("ok");
            button2.Text = Form1.lang.getString("cancel");

            label6.Text = Form1.lang.getString("color");
            comboBox3.Items.AddRange(new string[] { Form1.lang.getString("aqua"), Form1.lang.getString("yellow"), Form1.lang.getString("green"), Form1.lang.getString("red"), Form1.lang.getString("orange"), Form1.lang.getString("pink"), Form1.lang.getString("blue"), Form1.lang.getString("purple") });

            удалитьToolStripMenuItem.Text = Form1.lang.getString("delete");

            textBox1.Text = lat;
            textBox2.Text = lng;
            textBox3.Text = name;
            textBox4.Text = desc;
            this.date = date;

            if (Convert.ToDouble(lat) < 0)
                comboBox1.SelectedIndex = 1;
            else
                comboBox1.SelectedIndex = 0;

            if (Convert.ToDouble(lng) < 0)
                comboBox2.SelectedIndex = 0;
            else
                comboBox2.SelectedIndex = 1;

            this.pic = pic;

            switch (color)
            {
                case "LightBlue":
                    comboBox3.SelectedItem = Form1.lang.getString("aqua");
                    break;
                case "Yellow":
                    comboBox3.SelectedItem = Form1.lang.getString("yellow");
                    break;
                case "Green":
                    comboBox3.SelectedItem = Form1.lang.getString("green");
                    break;
                case "Red":
                    comboBox3.SelectedItem = Form1.lang.getString("red");
                    break;
                case "Orange":
                    comboBox3.SelectedItem = Form1.lang.getString("orange");
                    break;
                case "Pink":
                    comboBox3.SelectedItem = Form1.lang.getString("pink");
                    break;
                case "Blue":
                    comboBox3.SelectedItem = Form1.lang.getString("blue");
                    break;
                case "Purple":
                    comboBox3.SelectedItem = Form1.lang.getString("purple");
                    break;
                case "":
                    comboBox3.SelectedItem = Form1.lang.getString("blue");
                    break;
            }
        }

        public string GetLat()
        {
            if (comboBox1.SelectedIndex == 1)
                return "-" + textBox1.Text;
            else
                return textBox1.Text;
        }

        public string GetLng()
        {
            if (comboBox2.SelectedIndex == 0)
                return "-" + textBox2.Text;
            else
                return textBox2.Text;
        }

        public string GetName()
        {
            return textBox3.Text.ToString();
        }

        public string GetDesc()
        {
            return textBox4.Text;
        }

        public string GetColor()
        {
            string g = comboBox3.SelectedItem.ToString();
            if (g == Form1.lang.getString("aqua"))
                return "LightBlue";
            else if (g == Form1.lang.getString("yellow"))
                return "Yellow";
            else if (g == Form1.lang.getString("green"))
                return "Green";
            else if (g == Form1.lang.getString("red"))
                return "Red";
            else if (g == Form1.lang.getString("orange"))
                return "Orange";
            else if (g == Form1.lang.getString("pink"))
                return "Pink";
            else if (g == Form1.lang.getString("blue"))
                return "Blue";
            else if (g == Form1.lang.getString("purple"))
                return "Purple";
            else
                return "Blue";
        }

        public string GetPics()
        {
            string r = "";
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                r += Path.GetFileName(listView1.Items[i].Tag.ToString()) + ",";
            }
            if (r == "")
                return "";
            else
                return r.Substring(0, r.Length - 1);
        }

        public string GetDeletedPic()
        {
            if (deletePic == "")
                return "";
            else
                return deletePic.Substring(0, deletePic.Length - 1);
        }

        public string GetCopyPic()
        {
            if (copyPic == "")
                return "";
            else
                return copyPic.Substring(0, copyPic.Length - 1);
        }

        private void MarkerEdit_Load(object sender, EventArgs e)
        {
            if (pic != "")
            {
                string[] pics = pic.Split(',');
                for (int i = 0; i < pics.Length; i++)
                {
                    Bitmap bitmap = new Bitmap(Form1.path + "\\Markers\\" + date + "\\" + pics[i]);
                    imageList1.Images.Add(pics[i], bitmap);
                    listView1.Items.Add("");
                    listView1.Items[i].Tag = pics[i];
                    listView1.Items[i].ImageKey = pics[i];
                    bitmap.Dispose();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int g = listView1.Items.Count;
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    string from = openFileDialog1.FileNames[i];
                    string fileName = Path.GetFileName(openFileDialog1.FileNames[i]);
                    string to = Form1.path + "\\Markers\\" + date + "\\" + fileName;

                    if (!File.Exists(to))
                    {
                        copyPic += from + ",";
                        Bitmap bitmap = new Bitmap(from);
                        imageList1.Images.Add(fileName, bitmap);
                        listView1.Items.Add("");
                        listView1.Items[g + i].Tag = from;
                        listView1.Items[g + i].ImageKey = fileName;
                        bitmap.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(Form1.lang.getString("file_name_exists"), Form1.lang.getString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string deleteFile = Form1.path + "\\Markers\\" + date + "\\" + listView1.SelectedItems[0].Tag;
                if (File.Exists(deleteFile))
                    deletePic += deleteFile + ",";

                if (copyPic.Contains(listView1.SelectedItems[0].Tag.ToString()))
                    copyPic = copyPic.Replace(listView1.SelectedItems[0].Tag.ToString() + ",", "");

                imageList1.Images.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.SelectedItems[0].Remove();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                string fileInProject = Form1.path + "\\Markers\\" + date + "\\" + listView1.SelectedItems[0].Tag;
                string fileOutProject = listView1.SelectedItems[0].Tag.ToString();

                if (File.Exists(fileInProject))
                    Process.Start(fileInProject);
                else if (File.Exists(fileOutProject))
                    Process.Start(fileOutProject);
            }
        }
    }
}
