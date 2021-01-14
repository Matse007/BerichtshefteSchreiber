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
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnConfirmSelection = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUndoSelection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelselectionresult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNextMenu = new System.Windows.Forms.Button();
            this.btnPreviousMenu = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblComboBox1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(197, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Visible = false;
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
            this.dateTimePicker2.Location = new System.Drawing.Point(11, 90);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.Visible = false;
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
            this.panel1.Size = new System.Drawing.Size(186, 531);
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
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.dateTimePicker2);
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
            this.button2.Location = new System.Drawing.Point(914, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.ForeColor = System.Drawing.Color.White;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(742, 379);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(164, 40);
            this.listBox2.TabIndex = 13;
            this.listBox2.Visible = false;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
            this.listBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
            // 
            // btnConfirmSelection
            // 
            this.btnConfirmSelection.BackColor = System.Drawing.Color.White;
            this.btnConfirmSelection.FlatAppearance.BorderSize = 0;
            this.btnConfirmSelection.Location = new System.Drawing.Point(831, 438);
            this.btnConfirmSelection.Name = "btnConfirmSelection";
            this.btnConfirmSelection.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmSelection.TabIndex = 11;
            this.btnConfirmSelection.Text = "Bestätigen";
            this.btnConfirmSelection.UseVisualStyleBackColor = false;
            this.btnConfirmSelection.Visible = false;
            this.btnConfirmSelection.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(320, 379);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(273, 140);
            this.listBox1.TabIndex = 10;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(321, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 20;
            // 
            // btnUndoSelection
            // 
            this.btnUndoSelection.BackColor = System.Drawing.Color.White;
            this.btnUndoSelection.Location = new System.Drawing.Point(742, 438);
            this.btnUndoSelection.Name = "btnUndoSelection";
            this.btnUndoSelection.Size = new System.Drawing.Size(75, 23);
            this.btnUndoSelection.TabIndex = 21;
            this.btnUndoSelection.Text = "Rückgangig";
            this.btnUndoSelection.UseVisualStyleBackColor = false;
            this.btnUndoSelection.Click += new System.EventHandler(this.button3_Click_1);
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
            this.label3.Location = new System.Drawing.Point(238, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Lesezeichen:";
            this.label3.Visible = false;
            // 
            // labelselectionresult
            // 
            this.labelselectionresult.AutoSize = true;
            this.labelselectionresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelselectionresult.ForeColor = System.Drawing.Color.White;
            this.labelselectionresult.Location = new System.Drawing.Point(711, 473);
            this.labelselectionresult.Name = "labelselectionresult";
            this.labelselectionresult.Size = new System.Drawing.Size(207, 20);
            this.labelselectionresult.TabIndex = 24;
            this.labelselectionresult.Text = "Selection will be shown here";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(318, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Lesezeichen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(741, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Ausgewähltes Lesezeichen";
            // 
            // btnNextMenu
            // 
            this.btnNextMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnNextMenu.BackColor = System.Drawing.Color.White;
            this.btnNextMenu.Enabled = false;
            this.btnNextMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNextMenu.Location = new System.Drawing.Point(580, 504);
            this.btnNextMenu.Name = "btnNextMenu";
            this.btnNextMenu.Size = new System.Drawing.Size(75, 23);
            this.btnNextMenu.TabIndex = 27;
            this.btnNextMenu.Text = "Weiter";
            this.btnNextMenu.UseVisualStyleBackColor = false;
            this.btnNextMenu.Click += new System.EventHandler(this.btnNextMenu_Click);
            // 
            // btnPreviousMenu
            // 
            this.btnPreviousMenu.BackColor = System.Drawing.Color.White;
            this.btnPreviousMenu.Enabled = false;
            this.btnPreviousMenu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPreviousMenu.Location = new System.Drawing.Point(440, 504);
            this.btnPreviousMenu.Name = "btnPreviousMenu";
            this.btnPreviousMenu.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousMenu.TabIndex = 28;
            this.btnPreviousMenu.Text = "Zurück";
            this.btnPreviousMenu.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(410, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // lblComboBox1
            // 
            this.lblComboBox1.AutoSize = true;
            this.lblComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboBox1.ForeColor = System.Drawing.Color.White;
            this.lblComboBox1.Location = new System.Drawing.Point(239, 121);
            this.lblComboBox1.Name = "lblComboBox1";
            this.lblComboBox1.Size = new System.Drawing.Size(96, 16);
            this.lblComboBox1.TabIndex = 30;
            this.lblComboBox1.Text = "lblComboBox1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(239, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "label6";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(410, 147);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(239, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "label7";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(410, 174);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 531);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lblComboBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnPreviousMenu);
            this.Controls.Add(this.btnNextMenu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelselectionresult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnUndoSelection);
            this.Controls.Add(this.btnConfirmSelection);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_Keypress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private ListBox listBox2;
        private Button btnConfirmSelection;
        private ListBox listBox1;
        private TextBox textBox9;
        private Button btnStep1;
        private Panel PnlNav;
        private Button btnStep4;
        private Button btnStep3;
        private Button btnStep2;
        private Label label1;
        private Button btnUndoSelection;
        private Label label2;
        private Label label3;
        private Button btnStep5;
        private Label labelselectionresult;
        private Label label4;
        private Label label5;
        private Button btnNextMenu;
        private Button btnPreviousMenu;
        private Panel panel2;
        private ComboBox comboBox1;
        private Label lblComboBox1;
        private Label label6;
        private ComboBox comboBox2;
        private Label label7;
        private ComboBox comboBox3;
    }
}

