namespace OOP_Laba6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.squareButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.sectionButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuBlackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuRedColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuGreenColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuBlueColor = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.squareButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.circleButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.triangleButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.sectionButton, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(117, 422);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // squareButton
            // 
            this.squareButton.BackgroundImage = global::OOP_Laba6.Properties.Resources.square;
            this.squareButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.squareButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.squareButton.Location = new System.Drawing.Point(6, 6);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(105, 95);
            this.squareButton.TabIndex = 5;
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.squareButton_MouseClick);
            // 
            // circleButton
            // 
            this.circleButton.BackgroundImage = global::OOP_Laba6.Properties.Resources.circle;
            this.circleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.circleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleButton.Location = new System.Drawing.Point(6, 110);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(105, 95);
            this.circleButton.TabIndex = 6;
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.circleButton_MouseClick);
            // 
            // triangleButton
            // 
            this.triangleButton.BackgroundImage = global::OOP_Laba6.Properties.Resources.triangle;
            this.triangleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.triangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleButton.Location = new System.Drawing.Point(6, 214);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(105, 95);
            this.triangleButton.TabIndex = 7;
            this.triangleButton.UseVisualStyleBackColor = true;
            this.triangleButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.triangleButton_MouseClick);
            // 
            // sectionButton
            // 
            this.sectionButton.BackgroundImage = global::OOP_Laba6.Properties.Resources.section;
            this.sectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectionButton.Location = new System.Drawing.Point(6, 318);
            this.sectionButton.Name = "sectionButton";
            this.sectionButton.Size = new System.Drawing.Size(105, 98);
            this.sectionButton.TabIndex = 8;
            this.sectionButton.UseVisualStyleBackColor = true;
            this.sectionButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sectionButton_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCursor,
            this.toolStripMenuBlackColor,
            this.toolStripMenuRedColor,
            this.toolStripMenuGreenColor,
            this.toolStripMenuBlueColor});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuCursor
            // 
            this.toolStripMenuCursor.AutoSize = false;
            this.toolStripMenuCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuCursor.Image = global::OOP_Laba6.Properties.Resources.cursor;
            this.toolStripMenuCursor.Name = "toolStripMenuCursor";
            this.toolStripMenuCursor.Size = new System.Drawing.Size(24, 24);
            this.toolStripMenuCursor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem1_MouseDown);
            // 
            // toolStripMenuBlackColor
            // 
            this.toolStripMenuBlackColor.AutoSize = false;
            this.toolStripMenuBlackColor.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuBlackColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripMenuBlackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuBlackColor.Image = global::OOP_Laba6.Properties.Resources.blackColor;
            this.toolStripMenuBlackColor.Name = "toolStripMenuBlackColor";
            this.toolStripMenuBlackColor.Size = new System.Drawing.Size(24, 24);
            this.toolStripMenuBlackColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuBlackColor_MouseDown);
            // 
            // toolStripMenuRedColor
            // 
            this.toolStripMenuRedColor.AutoSize = false;
            this.toolStripMenuRedColor.Image = global::OOP_Laba6.Properties.Resources.redColor;
            this.toolStripMenuRedColor.Name = "toolStripMenuRedColor";
            this.toolStripMenuRedColor.Size = new System.Drawing.Size(24, 24);
            this.toolStripMenuRedColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuRedColor_MouseDown);
            // 
            // toolStripMenuGreenColor
            // 
            this.toolStripMenuGreenColor.AutoSize = false;
            this.toolStripMenuGreenColor.Image = global::OOP_Laba6.Properties.Resources.greenColor;
            this.toolStripMenuGreenColor.Name = "toolStripMenuGreenColor";
            this.toolStripMenuGreenColor.Size = new System.Drawing.Size(24, 24);
            this.toolStripMenuGreenColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuGreenColor_MouseDown);
            // 
            // toolStripMenuBlueColor
            // 
            this.toolStripMenuBlueColor.AutoSize = false;
            this.toolStripMenuBlueColor.Image = global::OOP_Laba6.Properties.Resources.blueColor;
            this.toolStripMenuBlueColor.Name = "toolStripMenuBlueColor";
            this.toolStripMenuBlueColor.Size = new System.Drawing.Size(24, 24);
            this.toolStripMenuBlueColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuBlueColor_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(117, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 422);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.Button sectionButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCursor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuBlackColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRedColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGreenColor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuBlueColor;
    }
}

