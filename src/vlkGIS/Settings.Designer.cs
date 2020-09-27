namespace vlkGIS
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cancel_button = new System.Windows.Forms.Button();
            this.OK_button = new System.Windows.Forms.Button();
            this.Port_label = new System.Windows.Forms.Label();
            this.Port_comboBox = new System.Windows.Forms.ComboBox();
            this.Speed_label = new System.Windows.Forms.Label();
            this.Speed_comboBox = new System.Windows.Forms.ComboBox();
            this.Satellite_groupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Accuracy_label = new System.Windows.Forms.Label();
            this.Accuracy_comboBox = new System.Windows.Forms.ComboBox();
            this.Interval_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Test_button = new System.Windows.Forms.Button();
            this.Map_label = new System.Windows.Forms.Label();
            this.Map_comboBox = new System.Windows.Forms.ComboBox();
            this.Maps_groupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.Scheme_radioButton = new System.Windows.Forms.RadioButton();
            this.Satellite_radioButton = new System.Windows.Forms.RadioButton();
            this.Hybrid_radioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.Route_groupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.Width_label = new System.Windows.Forms.Label();
            this.Width_num = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Smooth_label = new System.Windows.Forms.Label();
            this.Smooth_comboBox = new System.Windows.Forms.ComboBox();
            this.UI_groupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Language_label = new System.Windows.Forms.Label();
            this.Language_comboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.Satellite_groupBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Maps_groupBox.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.Route_groupBox.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Width_num)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.UI_groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel_button
            // 
            this.Cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_button.ForeColor = System.Drawing.Color.Black;
            this.Cancel_button.Location = new System.Drawing.Point(373, 14);
            this.Cancel_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(87, 28);
            this.Cancel_button.TabIndex = 0;
            this.Cancel_button.Text = "cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            // 
            // OK_button
            // 
            this.OK_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OK_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_button.ForeColor = System.Drawing.Color.Black;
            this.OK_button.Location = new System.Drawing.Point(280, 14);
            this.OK_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(87, 28);
            this.OK_button.TabIndex = 1;
            this.OK_button.Text = "ok";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Port_label
            // 
            this.Port_label.AutoSize = true;
            this.Port_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Port_label.Location = new System.Drawing.Point(3, 0);
            this.Port_label.Name = "Port_label";
            this.Port_label.Size = new System.Drawing.Size(30, 34);
            this.Port_label.TabIndex = 3;
            this.Port_label.Text = "port";
            this.Port_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Port_comboBox
            // 
            this.Port_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Port_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Port_comboBox.FormattingEnabled = true;
            this.Port_comboBox.Location = new System.Drawing.Point(39, 4);
            this.Port_comboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Port_comboBox.Name = "Port_comboBox";
            this.Port_comboBox.Size = new System.Drawing.Size(100, 24);
            this.Port_comboBox.TabIndex = 4;
            this.Port_comboBox.SelectedIndexChanged += new System.EventHandler(this.Port_ComboBox_SelectedIndexChanged);
            this.Port_comboBox.TextUpdate += new System.EventHandler(this.Port_ComboBox_TextUpdate);
            // 
            // Speed_label
            // 
            this.Speed_label.AutoSize = true;
            this.Speed_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Speed_label.Location = new System.Drawing.Point(145, 0);
            this.Speed_label.Name = "Speed_label";
            this.Speed_label.Size = new System.Drawing.Size(43, 34);
            this.Speed_label.TabIndex = 5;
            this.Speed_label.Text = "speed";
            this.Speed_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Speed_comboBox
            // 
            this.Speed_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Speed_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Speed_comboBox.FormattingEnabled = true;
            this.Speed_comboBox.Location = new System.Drawing.Point(194, 4);
            this.Speed_comboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Speed_comboBox.Name = "Speed_comboBox";
            this.Speed_comboBox.Size = new System.Drawing.Size(100, 24);
            this.Speed_comboBox.TabIndex = 6;
            // 
            // Satellite_groupBox
            // 
            this.Satellite_groupBox.AutoSize = true;
            this.Satellite_groupBox.Controls.Add(this.tableLayoutPanel4);
            this.Satellite_groupBox.Controls.Add(this.tableLayoutPanel3);
            this.Satellite_groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Satellite_groupBox.Location = new System.Drawing.Point(15, 100);
            this.Satellite_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Satellite_groupBox.Name = "Satellite_groupBox";
            this.Satellite_groupBox.Padding = new System.Windows.Forms.Padding(15);
            this.Satellite_groupBox.Size = new System.Drawing.Size(463, 131);
            this.Satellite_groupBox.TabIndex = 8;
            this.Satellite_groupBox.TabStop = false;
            this.Satellite_groupBox.Text = "satellite";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.Accuracy_label, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Accuracy_comboBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Interval_label, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(15, 74);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(433, 42);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // Accuracy_label
            // 
            this.Accuracy_label.AutoSize = true;
            this.Accuracy_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Accuracy_label.Location = new System.Drawing.Point(3, 0);
            this.Accuracy_label.Name = "Accuracy_label";
            this.Accuracy_label.Size = new System.Drawing.Size(29, 32);
            this.Accuracy_label.TabIndex = 8;
            this.Accuracy_label.Text = "acc";
            this.Accuracy_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Accuracy_comboBox
            // 
            this.Accuracy_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Accuracy_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Accuracy_comboBox.FormattingEnabled = true;
            this.Accuracy_comboBox.Location = new System.Drawing.Point(38, 4);
            this.Accuracy_comboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Accuracy_comboBox.Name = "Accuracy_comboBox";
            this.Accuracy_comboBox.Size = new System.Drawing.Size(140, 24);
            this.Accuracy_comboBox.TabIndex = 9;
            this.Accuracy_comboBox.SelectedIndexChanged += new System.EventHandler(this.Accuracy_comboBox_SelectedIndexChanged);
            // 
            // Interval_label
            // 
            this.Interval_label.AutoSize = true;
            this.Interval_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Interval_label.Location = new System.Drawing.Point(184, 0);
            this.Interval_label.Name = "Interval_label";
            this.Interval_label.Size = new System.Drawing.Size(246, 32);
            this.Interval_label.TabIndex = 10;
            this.Interval_label.Text = "rec";
            this.Interval_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.Port_label, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Port_comboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Speed_label, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.Speed_comboBox, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.Test_button, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(433, 44);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // Test_button
            // 
            this.Test_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Test_button.Enabled = false;
            this.Test_button.ForeColor = System.Drawing.Color.Black;
            this.Test_button.Location = new System.Drawing.Point(300, 4);
            this.Test_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Test_button.Name = "Test_button";
            this.Test_button.Size = new System.Drawing.Size(130, 26);
            this.Test_button.TabIndex = 7;
            this.Test_button.Text = "test";
            this.Test_button.UseVisualStyleBackColor = true;
            // 
            // Map_label
            // 
            this.Map_label.AutoSize = true;
            this.Map_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map_label.Location = new System.Drawing.Point(3, 0);
            this.Map_label.Name = "Map_label";
            this.Map_label.Size = new System.Drawing.Size(33, 32);
            this.Map_label.TabIndex = 9;
            this.Map_label.Text = "map";
            this.Map_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Map_comboBox
            // 
            this.Map_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Map_comboBox.FormattingEnabled = true;
            this.Map_comboBox.Location = new System.Drawing.Point(42, 4);
            this.Map_comboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Map_comboBox.Name = "Map_comboBox";
            this.Map_comboBox.Size = new System.Drawing.Size(180, 24);
            this.Map_comboBox.TabIndex = 10;
            this.Map_comboBox.SelectedIndexChanged += new System.EventHandler(this.Map_comboBox_SelectedIndexChanged);
            // 
            // Maps_groupBox
            // 
            this.Maps_groupBox.AutoSize = true;
            this.Maps_groupBox.Controls.Add(this.tableLayoutPanel8);
            this.Maps_groupBox.Controls.Add(this.tableLayoutPanel7);
            this.Maps_groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Maps_groupBox.Location = new System.Drawing.Point(15, 356);
            this.Maps_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Maps_groupBox.Name = "Maps_groupBox";
            this.Maps_groupBox.Padding = new System.Windows.Forms.Padding(15);
            this.Maps_groupBox.Size = new System.Drawing.Size(463, 125);
            this.Maps_groupBox.TabIndex = 12;
            this.Maps_groupBox.TabStop = false;
            this.Maps_groupBox.Text = "maps";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.Scheme_radioButton, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.Satellite_radioButton, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.Hybrid_radioButton, 2, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(15, 72);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(433, 38);
            this.tableLayoutPanel8.TabIndex = 15;
            // 
            // Scheme_radioButton
            // 
            this.Scheme_radioButton.AutoSize = true;
            this.Scheme_radioButton.Checked = true;
            this.Scheme_radioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scheme_radioButton.Location = new System.Drawing.Point(3, 4);
            this.Scheme_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Scheme_radioButton.Name = "Scheme_radioButton";
            this.Scheme_radioButton.Size = new System.Drawing.Size(72, 20);
            this.Scheme_radioButton.TabIndex = 11;
            this.Scheme_radioButton.TabStop = true;
            this.Scheme_radioButton.Text = "scheme";
            this.Scheme_radioButton.UseVisualStyleBackColor = true;
            // 
            // Satellite_radioButton
            // 
            this.Satellite_radioButton.AutoSize = true;
            this.Satellite_radioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Satellite_radioButton.Location = new System.Drawing.Point(81, 4);
            this.Satellite_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Satellite_radioButton.Name = "Satellite_radioButton";
            this.Satellite_radioButton.Size = new System.Drawing.Size(71, 20);
            this.Satellite_radioButton.TabIndex = 12;
            this.Satellite_radioButton.Text = "satellite";
            this.Satellite_radioButton.UseVisualStyleBackColor = true;
            // 
            // Hybrid_radioButton
            // 
            this.Hybrid_radioButton.AutoSize = true;
            this.Hybrid_radioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hybrid_radioButton.Location = new System.Drawing.Point(158, 4);
            this.Hybrid_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Hybrid_radioButton.Name = "Hybrid_radioButton";
            this.Hybrid_radioButton.Size = new System.Drawing.Size(272, 20);
            this.Hybrid_radioButton.TabIndex = 13;
            this.Hybrid_radioButton.Text = "hybrid";
            this.Hybrid_radioButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.Map_label, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.Map_comboBox, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(433, 42);
            this.tableLayoutPanel7.TabIndex = 14;
            // 
            // Route_groupBox
            // 
            this.Route_groupBox.AutoSize = true;
            this.Route_groupBox.Controls.Add(this.tableLayoutPanel6);
            this.Route_groupBox.Controls.Add(this.tableLayoutPanel5);
            this.Route_groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Route_groupBox.Location = new System.Drawing.Point(15, 231);
            this.Route_groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Route_groupBox.Name = "Route_groupBox";
            this.Route_groupBox.Padding = new System.Windows.Forms.Padding(15);
            this.Route_groupBox.Size = new System.Drawing.Size(463, 125);
            this.Route_groupBox.TabIndex = 15;
            this.Route_groupBox.TabStop = false;
            this.Route_groupBox.Text = "route";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.Width_label, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.Width_num, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(15, 72);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(433, 38);
            this.tableLayoutPanel6.TabIndex = 25;
            // 
            // Width_label
            // 
            this.Width_label.AutoSize = true;
            this.Width_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Width_label.Location = new System.Drawing.Point(3, 0);
            this.Width_label.Name = "Width_label";
            this.Width_label.Size = new System.Drawing.Size(38, 28);
            this.Width_label.TabIndex = 22;
            this.Width_label.Text = "width";
            this.Width_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Width_num
            // 
            this.Width_num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Width_num.Location = new System.Drawing.Point(47, 3);
            this.Width_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Width_num.Name = "Width_num";
            this.Width_num.Size = new System.Drawing.Size(100, 22);
            this.Width_num.TabIndex = 23;
            this.Width_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.Smooth_label, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.Smooth_comboBox, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(433, 42);
            this.tableLayoutPanel5.TabIndex = 24;
            // 
            // Smooth_label
            // 
            this.Smooth_label.AutoSize = true;
            this.Smooth_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Smooth_label.Location = new System.Drawing.Point(3, 0);
            this.Smooth_label.Name = "Smooth_label";
            this.Smooth_label.Size = new System.Drawing.Size(51, 32);
            this.Smooth_label.TabIndex = 20;
            this.Smooth_label.Text = "smooth";
            this.Smooth_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Smooth_comboBox
            // 
            this.Smooth_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Smooth_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Smooth_comboBox.FormattingEnabled = true;
            this.Smooth_comboBox.Location = new System.Drawing.Point(60, 4);
            this.Smooth_comboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Smooth_comboBox.Name = "Smooth_comboBox";
            this.Smooth_comboBox.Size = new System.Drawing.Size(180, 24);
            this.Smooth_comboBox.TabIndex = 21;
            // 
            // UI_groupBox
            // 
            this.UI_groupBox.AutoSize = true;
            this.UI_groupBox.Controls.Add(this.tableLayoutPanel1);
            this.UI_groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.UI_groupBox.Location = new System.Drawing.Point(15, 15);
            this.UI_groupBox.Name = "UI_groupBox";
            this.UI_groupBox.Padding = new System.Windows.Forms.Padding(15);
            this.UI_groupBox.Size = new System.Drawing.Size(463, 85);
            this.UI_groupBox.TabIndex = 16;
            this.UI_groupBox.TabStop = false;
            this.UI_groupBox.Text = "ui";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.Controls.Add(this.Language_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Language_comboBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(433, 40);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // Language_label
            // 
            this.Language_label.AutoSize = true;
            this.Language_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Language_label.Location = new System.Drawing.Point(3, 0);
            this.Language_label.Name = "Language_label";
            this.Language_label.Size = new System.Drawing.Size(60, 30);
            this.Language_label.TabIndex = 4;
            this.Language_label.Text = "language";
            this.Language_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Language_comboBox
            // 
            this.Language_comboBox.FormattingEnabled = true;
            this.Language_comboBox.Items.AddRange(new object[] {
            "English",
            "Русский"});
            this.Language_comboBox.Location = new System.Drawing.Point(69, 3);
            this.Language_comboBox.Name = "Language_comboBox";
            this.Language_comboBox.Size = new System.Drawing.Size(180, 24);
            this.Language_comboBox.TabIndex = 5;
            this.Language_comboBox.SelectedIndexChanged += new System.EventHandler(this.Language_comboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.OK_button, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.Cancel_button, 2, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(15, 481);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(463, 46);
            this.tableLayoutPanel9.TabIndex = 17;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 534);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Controls.Add(this.Maps_groupBox);
            this.Controls.Add(this.Route_groupBox);
            this.Controls.Add(this.Satellite_groupBox);
            this.Controls.Add(this.UI_groupBox);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Satellite_groupBox.ResumeLayout(false);
            this.Satellite_groupBox.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.Maps_groupBox.ResumeLayout(false);
            this.Maps_groupBox.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.Route_groupBox.ResumeLayout(false);
            this.Route_groupBox.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Width_num)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.UI_groupBox.ResumeLayout(false);
            this.UI_groupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.Label Port_label;
        private System.Windows.Forms.ComboBox Port_comboBox;
        private System.Windows.Forms.Label Speed_label;
        private System.Windows.Forms.ComboBox Speed_comboBox;
        private System.Windows.Forms.GroupBox Satellite_groupBox;
        private System.Windows.Forms.Label Map_label;
        private System.Windows.Forms.ComboBox Map_comboBox;
        private System.Windows.Forms.GroupBox Maps_groupBox;
        private System.Windows.Forms.RadioButton Satellite_radioButton;
        private System.Windows.Forms.RadioButton Scheme_radioButton;
        private System.Windows.Forms.RadioButton Hybrid_radioButton;
        private System.Windows.Forms.ComboBox Accuracy_comboBox;
        private System.Windows.Forms.Label Accuracy_label;
        private System.Windows.Forms.Label Interval_label;
        private System.Windows.Forms.Button Test_button;
        private System.Windows.Forms.GroupBox Route_groupBox;
        private System.Windows.Forms.ComboBox Smooth_comboBox;
        private System.Windows.Forms.Label Smooth_label;
        private System.Windows.Forms.NumericUpDown Width_num;
        private System.Windows.Forms.Label Width_label;
        private System.Windows.Forms.GroupBox UI_groupBox;
        private System.Windows.Forms.ComboBox Language_comboBox;
        private System.Windows.Forms.Label Language_label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
    }
}