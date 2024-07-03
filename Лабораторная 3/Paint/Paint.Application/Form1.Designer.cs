namespace Lab
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            BtnSave = new Button();
            BtnClear = new Button();
            BtnLine = new Button();
            BtnRectangle = new Button();
            BtnEllipse = new Button();
            BtnEraser = new Button();
            BtnPencil = new Button();
            BtnPaint = new Button();
            BtnColor = new Button();
            Pic = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 224, 192);
            panel1.Controls.Add(BtnSave);
            panel1.Controls.Add(BtnClear);
            panel1.Controls.Add(BtnLine);
            panel1.Controls.Add(BtnRectangle);
            panel1.Controls.Add(BtnEllipse);
            panel1.Controls.Add(BtnEraser);
            panel1.Controls.Add(BtnPencil);
            panel1.Controls.Add(BtnPaint);
            panel1.Controls.Add(BtnColor);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1680, 160);
            panel1.TabIndex = 0;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.White;
            BtnSave.Cursor = Cursors.Hand;
            BtnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnSave.ForeColor = Color.Black;
            BtnSave.Location = new Point(1471, 12);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(207, 56);
            BtnSave.TabIndex = 8;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnClear
            // 
            BtnClear.BackColor = Color.White;
            BtnClear.Cursor = Cursors.Hand;
            BtnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnClear.FlatStyle = FlatStyle.Flat;
            BtnClear.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnClear.ForeColor = Color.Black;
            BtnClear.Location = new Point(1471, 94);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(207, 56);
            BtnClear.TabIndex = 7;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnLine
            // 
            BtnLine.BackColor = Color.White;
            BtnLine.BackgroundImage = Properties.Resources.line;
            BtnLine.BackgroundImageLayout = ImageLayout.Zoom;
            BtnLine.Cursor = Cursors.Hand;
            BtnLine.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnLine.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnLine.FlatStyle = FlatStyle.Flat;
            BtnLine.ForeColor = Color.White;
            BtnLine.Location = new Point(1292, 12);
            BtnLine.Name = "BtnLine";
            BtnLine.Size = new Size(173, 138);
            BtnLine.TabIndex = 6;
            BtnLine.UseVisualStyleBackColor = false;
            BtnLine.Click += BtnLine_Click;
            // 
            // BtnRectangle
            // 
            BtnRectangle.BackColor = Color.White;
            BtnRectangle.BackgroundImage = Properties.Resources.rectangle;
            BtnRectangle.BackgroundImageLayout = ImageLayout.Zoom;
            BtnRectangle.Cursor = Cursors.Hand;
            BtnRectangle.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnRectangle.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnRectangle.FlatStyle = FlatStyle.Flat;
            BtnRectangle.ForeColor = Color.White;
            BtnRectangle.Location = new Point(1113, 12);
            BtnRectangle.Name = "BtnRectangle";
            BtnRectangle.Size = new Size(173, 138);
            BtnRectangle.TabIndex = 5;
            BtnRectangle.UseVisualStyleBackColor = false;
            BtnRectangle.Click += BtnRectangle_Click;
            // 
            // BtnEllipse
            // 
            BtnEllipse.BackColor = Color.White;
            BtnEllipse.BackgroundImage = Properties.Resources.circle;
            BtnEllipse.BackgroundImageLayout = ImageLayout.Zoom;
            BtnEllipse.Cursor = Cursors.Hand;
            BtnEllipse.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnEllipse.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnEllipse.FlatStyle = FlatStyle.Flat;
            BtnEllipse.ForeColor = Color.White;
            BtnEllipse.Location = new Point(934, 12);
            BtnEllipse.Name = "BtnEllipse";
            BtnEllipse.Size = new Size(173, 138);
            BtnEllipse.TabIndex = 4;
            BtnEllipse.UseVisualStyleBackColor = false;
            BtnEllipse.Click += BtnEllipse_Click;
            // 
            // BtnEraser
            // 
            BtnEraser.BackColor = Color.White;
            BtnEraser.BackgroundImage = Properties.Resources.eraser;
            BtnEraser.BackgroundImageLayout = ImageLayout.Zoom;
            BtnEraser.Cursor = Cursors.Hand;
            BtnEraser.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnEraser.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnEraser.FlatStyle = FlatStyle.Flat;
            BtnEraser.ForeColor = Color.White;
            BtnEraser.Location = new Point(755, 12);
            BtnEraser.Name = "BtnEraser";
            BtnEraser.Size = new Size(173, 138);
            BtnEraser.TabIndex = 3;
            BtnEraser.UseVisualStyleBackColor = false;
            BtnEraser.Click += BtnEraser_Click;
            // 
            // BtnPencil
            // 
            BtnPencil.BackColor = Color.White;
            BtnPencil.BackgroundImage = Properties.Resources.pencil;
            BtnPencil.BackgroundImageLayout = ImageLayout.Zoom;
            BtnPencil.Cursor = Cursors.Hand;
            BtnPencil.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnPencil.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnPencil.FlatStyle = FlatStyle.Flat;
            BtnPencil.ForeColor = Color.White;
            BtnPencil.Location = new Point(576, 12);
            BtnPencil.Name = "BtnPencil";
            BtnPencil.Size = new Size(173, 138);
            BtnPencil.TabIndex = 2;
            BtnPencil.UseVisualStyleBackColor = false;
            BtnPencil.Click += BtnPencil_Click;
            // 
            // BtnPaint
            // 
            BtnPaint.BackColor = Color.White;
            BtnPaint.BackgroundImage = Properties.Resources.paint;
            BtnPaint.BackgroundImageLayout = ImageLayout.Zoom;
            BtnPaint.Cursor = Cursors.Hand;
            BtnPaint.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnPaint.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnPaint.FlatStyle = FlatStyle.Flat;
            BtnPaint.ForeColor = Color.White;
            BtnPaint.Location = new Point(397, 12);
            BtnPaint.Name = "BtnPaint";
            BtnPaint.Size = new Size(173, 138);
            BtnPaint.TabIndex = 1;
            BtnPaint.UseVisualStyleBackColor = false;
            BtnPaint.Click += BtnPaint_Click;
            // 
            // BtnColor
            // 
            BtnColor.BackColor = Color.White;
            BtnColor.BackgroundImage = Properties.Resources.color_wheel;
            BtnColor.BackgroundImageLayout = ImageLayout.Zoom;
            BtnColor.Cursor = Cursors.Hand;
            BtnColor.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnColor.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnColor.FlatStyle = FlatStyle.Flat;
            BtnColor.ForeColor = Color.White;
            BtnColor.Location = new Point(218, 12);
            BtnColor.Name = "BtnColor";
            BtnColor.Size = new Size(173, 138);
            BtnColor.TabIndex = 0;
            BtnColor.UseVisualStyleBackColor = false;
            BtnColor.Click += BtnColor_Click;
            // 
            // Pic
            // 
            Pic.Dock = DockStyle.Fill;
            Pic.Location = new Point(0, 160);
            Pic.Name = "Pic";
            Pic.Size = new Size(1680, 822);
            Pic.TabIndex = 1;
            Pic.TabStop = false;
            Pic.Paint += Pic_Paint;
            Pic.MouseClick += Pic_MouseClick;
            Pic.MouseDown += Pic_MouseDown;
            Pic.MouseMove += Pic_MouseMove;
            Pic.MouseUp += Pic_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1680, 982);
            Controls.Add(Pic);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Paint";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Pic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BtnSave;
        private Button BtnClear;
        private Button BtnLine;
        private Button BtnRectangle;
        private Button BtnEllipse;
        private Button BtnEraser;
        private Button BtnPencil;
        private Button BtnPaint;
        private Button BtnColor;
        private PictureBox Pic;
    }
}
