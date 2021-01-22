using System.Windows.Forms;

namespace Berichtsheft
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStep5 = new System.Windows.Forms.Button();
            this.btnStep4 = new System.Windows.Forms.Button();
            this.btnStep3 = new System.Windows.Forms.Button();
            this.btnStep2 = new System.Windows.Forms.Button();
            this.PnlNav = new System.Windows.Forms.Panel();
            this.btnStep1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblBHeftCombo = new System.Windows.Forms.Label();
            this.lblWocheStartCombo = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblWocheEndCombo = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lblAusbildJahrCombo = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.lblNameCombo = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.lblBerufCombo = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblNameText = new System.Windows.Forms.Label();
            this.lblBerufTextBox = new System.Windows.Forms.Label();
            this.lblAusbildungsstartDate = new System.Windows.Forms.Label();
            this.lblAusbildungsendeDate = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.dateTimePicker1.Location = new System.Drawing.Point(410, 367);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(65)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.button1.Location = new System.Drawing.Point(702, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Auswählen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(410, 393);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.Visible = false;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnStep5);
            this.panel1.Controls.Add(this.btnStep4);
            this.panel1.Controls.Add(this.btnStep3);
            this.panel1.Controls.Add(this.btnStep2);
            this.panel1.Controls.Add(this.PnlNav);
            this.panel1.Controls.Add(this.btnStep1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 558);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnStep5
            // 
            this.btnStep5.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStep5.FlatAppearance.BorderSize = 0;
            this.btnStep5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStep5.Location = new System.Drawing.Point(0, 407);
            this.btnStep5.Name = "btnStep5";
            this.btnStep5.Size = new System.Drawing.Size(186, 60);
            this.btnStep5.TabIndex = 6;
            this.btnStep5.Text = "Fertig";
            this.btnStep5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStep5.UseVisualStyleBackColor = true;
            // 
            // btnStep4
            // 
            this.btnStep4.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStep4.FlatAppearance.BorderSize = 0;
            this.btnStep4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStep4.Location = new System.Drawing.Point(0, 347);
            this.btnStep4.Name = "btnStep4";
            this.btnStep4.Size = new System.Drawing.Size(186, 60);
            this.btnStep4.TabIndex = 5;
            this.btnStep4.Text = "Alle Daten kontrollieren";
            this.btnStep4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStep4.UseVisualStyleBackColor = true;
            // 
            // btnStep3
            // 
            this.btnStep3.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStep3.FlatAppearance.BorderSize = 0;
            this.btnStep3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStep3.Location = new System.Drawing.Point(0, 287);
            this.btnStep3.Name = "btnStep3";
            this.btnStep3.Size = new System.Drawing.Size(186, 60);
            this.btnStep3.TabIndex = 4;
            this.btnStep3.Text = "Ausbildungszeitraum\r\nund sonstige Daten\r\n";
            this.btnStep3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStep3.UseVisualStyleBackColor = true;
            // 
            // btnStep2
            // 
            this.btnStep2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStep2.FlatAppearance.BorderSize = 0;
            this.btnStep2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStep2.Location = new System.Drawing.Point(0, 227);
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(186, 60);
            this.btnStep2.TabIndex = 3;
            this.btnStep2.Text = "Lesezeichen auswählen";
            this.btnStep2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStep2.UseVisualStyleBackColor = true;
            this.btnStep2.Click += new System.EventHandler(this.btnStep2_Click);
            // 
            // PnlNav
            // 
            this.PnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.PnlNav.Location = new System.Drawing.Point(0, 193);
            this.PnlNav.Name = "PnlNav";
            this.PnlNav.Size = new System.Drawing.Size(3, 100);
            this.PnlNav.TabIndex = 2;
            // 
            // btnStep1
            // 
            this.btnStep1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStep1.FlatAppearance.BorderSize = 0;
            this.btnStep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStep1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStep1.Location = new System.Drawing.Point(0, 167);
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(186, 60);
            this.btnStep1.TabIndex = 1;
            this.btnStep1.Text = "Word Dokument auswählen";
            this.btnStep1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStep1.UseVisualStyleBackColor = true;
            this.btnStep1.Click += new System.EventHandler(this.btnStep1_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 167);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(864, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.ForeColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(235, 61);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(461, 20);
            this.textBox9.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(232, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Dateipfad zum Dokument:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(238, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Lesezeichen:";
            this.label3.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(410, 121);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // lblBHeftCombo
            // 
            this.lblBHeftCombo.AutoSize = true;
            this.lblBHeftCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBHeftCombo.ForeColor = System.Drawing.Color.White;
            this.lblBHeftCombo.Location = new System.Drawing.Point(260, 121);
            this.lblBHeftCombo.Name = "lblBHeftCombo";
            this.lblBHeftCombo.Size = new System.Drawing.Size(125, 16);
            this.lblBHeftCombo.TabIndex = 30;
            this.lblBHeftCombo.Text = "Berichtsheftnummer";
            // 
            // lblWocheStartCombo
            // 
            this.lblWocheStartCombo.AutoSize = true;
            this.lblWocheStartCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWocheStartCombo.ForeColor = System.Drawing.Color.White;
            this.lblWocheStartCombo.Location = new System.Drawing.Point(266, 148);
            this.lblWocheStartCombo.Name = "lblWocheStartCombo";
            this.lblWocheStartCombo.Size = new System.Drawing.Size(119, 16);
            this.lblWocheStartCombo.TabIndex = 32;
            this.lblWocheStartCombo.Text = "Anfang der Woche";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(410, 148);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(215, 21);
            this.comboBox2.TabIndex = 31;
            this.comboBox2.DropDownClosed += new System.EventHandler(this.comboBox2_DropDownClosed);
            // 
            // lblWocheEndCombo
            // 
            this.lblWocheEndCombo.AutoSize = true;
            this.lblWocheEndCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWocheEndCombo.ForeColor = System.Drawing.Color.White;
            this.lblWocheEndCombo.Location = new System.Drawing.Point(276, 175);
            this.lblWocheEndCombo.Name = "lblWocheEndCombo";
            this.lblWocheEndCombo.Size = new System.Drawing.Size(109, 16);
            this.lblWocheEndCombo.TabIndex = 34;
            this.lblWocheEndCombo.Text = "Ende der Woche";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(410, 175);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(215, 21);
            this.comboBox3.TabIndex = 33;
            this.comboBox3.DropDownClosed += new System.EventHandler(this.comboBox3_DropDownClosed);
            // 
            // lblAusbildJahrCombo
            // 
            this.lblAusbildJahrCombo.AutoSize = true;
            this.lblAusbildJahrCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusbildJahrCombo.ForeColor = System.Drawing.Color.White;
            this.lblAusbildJahrCombo.Location = new System.Drawing.Point(281, 202);
            this.lblAusbildJahrCombo.Name = "lblAusbildJahrCombo";
            this.lblAusbildJahrCombo.Size = new System.Drawing.Size(104, 16);
            this.lblAusbildJahrCombo.TabIndex = 36;
            this.lblAusbildJahrCombo.Text = "Ausbildungsjahr";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(410, 202);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(215, 21);
            this.comboBox4.TabIndex = 35;
            this.comboBox4.DropDownClosed += new System.EventHandler(this.comboBox4_DropDownClosed);
            // 
            // lblNameCombo
            // 
            this.lblNameCombo.AutoSize = true;
            this.lblNameCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameCombo.ForeColor = System.Drawing.Color.White;
            this.lblNameCombo.Location = new System.Drawing.Point(281, 228);
            this.lblNameCombo.Name = "lblNameCombo";
            this.lblNameCombo.Size = new System.Drawing.Size(104, 16);
            this.lblNameCombo.TabIndex = 38;
            this.lblNameCombo.Text = "Name (optional)";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(410, 228);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(215, 21);
            this.comboBox5.TabIndex = 37;
            // 
            // lblBerufCombo
            // 
            this.lblBerufCombo.AutoSize = true;
            this.lblBerufCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerufCombo.ForeColor = System.Drawing.Color.White;
            this.lblBerufCombo.Location = new System.Drawing.Point(214, 256);
            this.lblBerufCombo.Name = "lblBerufCombo";
            this.lblBerufCombo.Size = new System.Drawing.Size(171, 16);
            this.lblBerufCombo.TabIndex = 40;
            this.lblBerufCombo.Text = "Ausbildungsberuf (optional)";
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(410, 255);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(215, 21);
            this.comboBox6.TabIndex = 39;
            this.comboBox6.DropDownClosed += new System.EventHandler(this.comboBox6_DropDownClosed);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 310);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 20);
            this.textBox1.TabIndex = 41;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gray;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(410, 336);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(215, 20);
            this.textBox2.TabIndex = 42;
            this.textBox2.Visible = false;
            // 
            // lblNameText
            // 
            this.lblNameText.AutoSize = true;
            this.lblNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameText.ForeColor = System.Drawing.Color.White;
            this.lblNameText.Location = new System.Drawing.Point(258, 314);
            this.lblNameText.Name = "lblNameText";
            this.lblNameText.Size = new System.Drawing.Size(127, 16);
            this.lblNameText.TabIndex = 43;
            this.lblNameText.Text = "Vollständiger Name";
            this.lblNameText.Visible = false;
            // 
            // lblBerufTextBox
            // 
            this.lblBerufTextBox.AutoSize = true;
            this.lblBerufTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerufTextBox.ForeColor = System.Drawing.Color.Gray;
            this.lblBerufTextBox.Location = new System.Drawing.Point(273, 340);
            this.lblBerufTextBox.Name = "lblBerufTextBox";
            this.lblBerufTextBox.Size = new System.Drawing.Size(112, 16);
            this.lblBerufTextBox.TabIndex = 44;
            this.lblBerufTextBox.Text = "Ausbildungsberuf";
            this.lblBerufTextBox.Visible = false;
            // 
            // lblAusbildungsstartDate
            // 
            this.lblAusbildungsstartDate.AutoSize = true;
            this.lblAusbildungsstartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusbildungsstartDate.ForeColor = System.Drawing.Color.White;
            this.lblAusbildungsstartDate.Location = new System.Drawing.Point(258, 371);
            this.lblAusbildungsstartDate.Name = "lblAusbildungsstartDate";
            this.lblAusbildungsstartDate.Size = new System.Drawing.Size(128, 16);
            this.lblAusbildungsstartDate.TabIndex = 45;
            this.lblAusbildungsstartDate.Text = "Start der Ausbildung";
            this.lblAusbildungsstartDate.Visible = false;
            // 
            // lblAusbildungsendeDate
            // 
            this.lblAusbildungsendeDate.AutoSize = true;
            this.lblAusbildungsendeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusbildungsendeDate.ForeColor = System.Drawing.Color.White;
            this.lblAusbildungsendeDate.Location = new System.Drawing.Point(258, 397);
            this.lblAusbildungsendeDate.Name = "lblAusbildungsendeDate";
            this.lblAusbildungsendeDate.Size = new System.Drawing.Size(133, 16);
            this.lblAusbildungsendeDate.TabIndex = 46;
            this.lblAusbildungsendeDate.Text = "Ende der Ausbildung";
            this.lblAusbildungsendeDate.Visible = false;
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(410, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(215, 23);
            this.button3.TabIndex = 47;
            this.button3.Text = "Speicherort auswählen und Starten";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(186, 535);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(715, 23);
            this.progressBar1.TabIndex = 48;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(186, 517);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(901, 558);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblAusbildungsendeDate);
            this.Controls.Add(this.lblAusbildungsstartDate);
            this.Controls.Add(this.lblBerufTextBox);
            this.Controls.Add(this.lblNameText);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.lblBerufCombo);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.lblNameCombo);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.lblAusbildJahrCombo);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.lblWocheEndCombo);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.lblWocheStartCombo);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lblBHeftCombo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_Keypress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private Button button2;
        private TextBox textBox9;
        private Button btnStep1;
        private Panel PnlNav;
        private Button btnStep4;
        private Button btnStep3;
        private Button btnStep2;
        private Label label2;
        private Label label3;
        private Button btnStep5;
        private Panel panel2;
        private ComboBox comboBox1;
        private Label lblBHeftCombo;
        private Label lblWocheStartCombo;
        private ComboBox comboBox2;
        private Label lblWocheEndCombo;
        private ComboBox comboBox3;
        private Label lblAusbildJahrCombo;
        private ComboBox comboBox4;
        private Label lblNameCombo;
        private ComboBox comboBox5;
        private Label lblBerufCombo;
        private ComboBox comboBox6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblNameText;
        private Label lblBerufTextBox;
        private Label lblAusbildungsstartDate;
        private Label lblAusbildungsendeDate;
        private Button button3;
        private ProgressBar progressBar1;
        private Label label1;
    }
}

