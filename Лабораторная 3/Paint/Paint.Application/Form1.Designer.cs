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
            BtnMove = new Button();
            BtnConnector = new Button();
            BtnSave = new Button();
            BtnClear = new Button();
            BtnTriangle = new Button();
            BtnRectangle = new Button();
            BtnEllipse = new Button();
            Pic = new PictureBox();
            BtnLoad = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pic).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 224, 192);
            panel1.Controls.Add(BtnLoad);
            panel1.Controls.Add(BtnMove);
            panel1.Controls.Add(BtnConnector);
            panel1.Controls.Add(BtnSave);
            panel1.Controls.Add(BtnClear);
            panel1.Controls.Add(BtnTriangle);
            panel1.Controls.Add(BtnRectangle);
            panel1.Controls.Add(BtnEllipse);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 96);
            panel1.TabIndex = 0;
            // 
            // BtnMove
            // 
            BtnMove.BackColor = Color.White;
            BtnMove.Cursor = Cursors.Hand;
            BtnMove.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnMove.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnMove.FlatStyle = FlatStyle.Flat;
            BtnMove.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnMove.ForeColor = Color.Black;
            BtnMove.Location = new Point(4, 44);
            BtnMove.Margin = new Padding(2);
            BtnMove.Name = "BtnMove";
            BtnMove.Size = new Size(145, 34);
            BtnMove.TabIndex = 12;
            BtnMove.Text = "Двигать";
            BtnMove.UseVisualStyleBackColor = false;
            BtnMove.Click += BtnMove_Click;
            // 
            // BtnConnector
            // 
            BtnConnector.BackColor = Color.White;
            BtnConnector.Cursor = Cursors.Hand;
            BtnConnector.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnConnector.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnConnector.FlatStyle = FlatStyle.Flat;
            BtnConnector.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnConnector.ForeColor = Color.Black;
            BtnConnector.Location = new Point(4, 7);
            BtnConnector.Margin = new Padding(2);
            BtnConnector.Name = "BtnConnector";
            BtnConnector.Size = new Size(145, 34);
            BtnConnector.TabIndex = 11;
            BtnConnector.Text = "Коннектор";
            BtnConnector.UseVisualStyleBackColor = false;
            BtnConnector.Click += BtnConnector_Click;
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
            BtnSave.Location = new Point(592, 11);
            BtnSave.Margin = new Padding(2);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(145, 34);
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
            BtnClear.Location = new Point(820, 44);
            BtnClear.Margin = new Padding(2);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(145, 34);
            BtnClear.TabIndex = 7;
            BtnClear.Text = "Clear";
            BtnClear.UseVisualStyleBackColor = false;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnTriangle
            // 
            BtnTriangle.BackColor = Color.White;
            BtnTriangle.BackgroundImage = Properties.Resources.triangle;
            BtnTriangle.BackgroundImageLayout = ImageLayout.Zoom;
            BtnTriangle.Cursor = Cursors.Hand;
            BtnTriangle.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnTriangle.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnTriangle.FlatStyle = FlatStyle.Flat;
            BtnTriangle.ForeColor = Color.White;
            BtnTriangle.Location = new Point(403, 7);
            BtnTriangle.Margin = new Padding(2);
            BtnTriangle.Name = "BtnTriangle";
            BtnTriangle.Size = new Size(121, 83);
            BtnTriangle.TabIndex = 6;
            BtnTriangle.UseVisualStyleBackColor = false;
            BtnTriangle.Click += BtnTriangle_Click;
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
            BtnRectangle.Location = new Point(278, 7);
            BtnRectangle.Margin = new Padding(2);
            BtnRectangle.Name = "BtnRectangle";
            BtnRectangle.Size = new Size(121, 83);
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
            BtnEllipse.Location = new Point(153, 7);
            BtnEllipse.Margin = new Padding(2);
            BtnEllipse.Name = "BtnEllipse";
            BtnEllipse.Size = new Size(121, 83);
            BtnEllipse.TabIndex = 4;
            BtnEllipse.UseVisualStyleBackColor = false;
            BtnEllipse.Click += BtnEllipse_Click;
            // 
            // Pic
            // 
            Pic.Dock = DockStyle.Fill;
            Pic.Location = new Point(0, 96);
            Pic.Margin = new Padding(2);
            Pic.Name = "Pic";
            Pic.Size = new Size(1176, 493);
            Pic.TabIndex = 1;
            Pic.TabStop = false;
            Pic.Paint += Pic_Paint;
            Pic.MouseDown += Pic_MouseDown;
            Pic.MouseMove += Pic_MouseMove;
            Pic.MouseUp += Pic_MouseUp;
            // 
            // BtnLoad
            // 
            BtnLoad.BackColor = Color.White;
            BtnLoad.Cursor = Cursors.Hand;
            BtnLoad.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            BtnLoad.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            BtnLoad.FlatStyle = FlatStyle.Flat;
            BtnLoad.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            BtnLoad.ForeColor = Color.Black;
            BtnLoad.Location = new Point(592, 49);
            BtnLoad.Margin = new Padding(2);
            BtnLoad.Name = "BtnLoad";
            BtnLoad.Size = new Size(145, 34);
            BtnLoad.TabIndex = 13;
            BtnLoad.Text = "Load";
            BtnLoad.UseVisualStyleBackColor = false;
            BtnLoad.Click += BtnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 589);
            Controls.Add(Pic);
            Controls.Add(panel1);
            Margin = new Padding(2);
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
        private Button BtnTriangle;
        private Button BtnRectangle;
        private Button BtnEllipse;
        private PictureBox Pic;
        private Button BtnMove;
        private Button BtnConnector;
        private Button BtnLoad;
    }
}
