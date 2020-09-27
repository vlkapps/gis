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
            Location_groupBox.Text = Form1.lang.getString("location");
            Lat_label.Text = Form1.lang.getString("lat");
            Lng_label.Text = Form1.lang.getString("lng");
            Lat_comboBox.Items.AddRange(new string[] { Form1.lang.getString("north"), Form1.lang.getString("south") });
            Lng_comboBox.Items.AddRange(new string[] { Form1.lang.getString("west"), Form1.lang.getString("east") });
            Name_label.Text = Form1.lang.getString("name");
            Desc_label.Text = Form1.lang.getString("desc");
            Images_label.Text = Form1.lang.getString("images");
            Add_Images_button.Text = Form1.lang.getString("add");
            OK_button.Text = Form1.lang.getString("ok");
            Cancel_button.Text = Form1.lang.getString("cancel");

            Color_label.Text = Form1.lang.getString("color");
            Color_comboBox.Items.AddRange(new string[] { Form1.lang.getString("aqua"), Form1.lang.getString("yellow"), Form1.lang.getString("green"), Form1.lang.getString("red"), Form1.lang.getString("orange"), Form1.lang.getString("pink"), Form1.lang.getString("blue"), Form1.lang.getString("purple") });

            DeleteToolStripMenuItem.Text = Form1.lang.getString("delete");

            Lat_textBox.Text = lat;
            Lng_textBox.Text = lng;
            Name_textBox.Text = name;
            Desc_textBox.Text = desc;
            this.date = date;

            if (Convert.ToDouble(lat) < 0)
                Lat_comboBox.SelectedIndex = 1;
            else
                Lat_comboBox.SelectedIndex = 0;

            if (Convert.ToDouble(lng) < 0)
                Lng_comboBox.SelectedIndex = 0;
            else
                Lng_comboBox.SelectedIndex = 1;

            this.pic = pic;

            switch (color)
            {
                case "LightBlue":
                    Color_comboBox.SelectedItem = Form1.lang.getString("aqua");
                    break;
                case "Yellow":
                    Color_comboBox.SelectedItem = Form1.lang.getString("yellow");
                    break;
                case "Green":
                    Color_comboBox.SelectedItem = Form1.lang.getString("green");
                    break;
                case "Red":
                    Color_comboBox.SelectedItem = Form1.lang.getString("red");
                    break;
                case "Orange":
                    Color_comboBox.SelectedItem = Form1.lang.getString("orange");
                    break;
                case "Pink":
                    Color_comboBox.SelectedItem = Form1.lang.getString("pink");
                    break;
                case "Blue":
                    Color_comboBox.SelectedItem = Form1.lang.getString("blue");
                    break;
                case "Purple":
                    Color_comboBox.SelectedItem = Form1.lang.getString("purple");
                    break;
                case "":
                    Color_comboBox.SelectedItem = Form1.lang.getString("blue");
                    break;
            }
        }

        public string GetLat()
        {
            if (Lat_comboBox.SelectedIndex == 1)
                return "-" + Lat_textBox.Text;
            else
                return Lat_textBox.Text;
        }

        public string GetLng()
        {
            if (Lng_comboBox.SelectedIndex == 0)
                return "-" + Lng_textBox.Text;
            else
                return Lng_textBox.Text;
        }

        public string GetName()
        {
            return Name_textBox.Text.ToString();
        }

        public string GetDesc()
        {
            return Desc_textBox.Text;
        }

        public string GetColor()
        {
            string g = Color_comboBox.SelectedItem.ToString();
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
            for (int i = 0; i < Images_listView.Items.Count; i++)
            {
                r += Path.GetFileName(Images_listView.Items[i].Tag.ToString()) + ",";
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
                    Images_listView.Items.Add("");
                    Images_listView.Items[i].Tag = pics[i];
                    Images_listView.Items[i].ImageKey = pics[i];
                    bitmap.Dispose();
                }
            }
        }

        private void Add_Images_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int g = Images_listView.Items.Count;
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
                        Images_listView.Items.Add("");
                        Images_listView.Items[g + i].Tag = from;
                        Images_listView.Items[g + i].ImageKey = fileName;
                        bitmap.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(Form1.lang.getString("file_name_exists"), Form1.lang.getString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Images_listView.SelectedItems.Count == 1)
            {
                string deleteFile = Form1.path + "\\Markers\\" + date + "\\" + Images_listView.SelectedItems[0].Tag;
                if (File.Exists(deleteFile))
                    deletePic += deleteFile + ",";

                if (copyPic.Contains(Images_listView.SelectedItems[0].Tag.ToString()))
                    copyPic = copyPic.Replace(Images_listView.SelectedItems[0].Tag.ToString() + ",", "");

                imageList1.Images.RemoveAt(Images_listView.SelectedItems[0].Index);
                Images_listView.SelectedItems[0].Remove();
            }
        }

        private void Images_listView_DoubleClick(object sender, EventArgs e)
        {
            if (Images_listView.SelectedItems.Count == 1)
            {
                string fileInProject = Form1.path + "\\Markers\\" + date + "\\" + Images_listView.SelectedItems[0].Tag;
                string fileOutProject = Images_listView.SelectedItems[0].Tag.ToString();

                if (File.Exists(fileInProject))
                    Process.Start(fileInProject);
                else if (File.Exists(fileOutProject))
                    Process.Start(fileOutProject);
            }
        }
    }
}
