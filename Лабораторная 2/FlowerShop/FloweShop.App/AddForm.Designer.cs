namespace FloweShop.App
{
    partial class AddForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox_name = new TextBox();
            textBox_sort = new TextBox();
            textBox_price = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(13, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 32);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(13, 61);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 32);
            label2.TabIndex = 1;
            label2.Text = "Сорт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(13, 104);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(150, 32);
            label3.TabIndex = 2;
            label3.Text = "Цена за 1 шт.";
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(179, 15);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(150, 37);
            textBox_name.TabIndex = 3;
            // 
            // textBox_sort
            // 
            textBox_sort.Location = new Point(179, 61);
            textBox_sort.Name = "textBox_sort";
            textBox_sort.Size = new Size(150, 37);
            textBox_sort.TabIndex = 4;
            // 
            // textBox_price
            // 
            textBox_price.Location = new Point(179, 104);
            textBox_price.Name = "textBox_price";
            textBox_price.Size = new Size(150, 37);
            textBox_price.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(292, 241);
            button1.Name = "button1";
            button1.Size = new Size(191, 56);
            button1.TabIndex = 6;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 309);
            Controls.Add(button1);
            Controls.Add(textBox_price);
            Controls.Add(textBox_sort);
            Controls.Add(textBox_name);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "AddForm";
            Text = "Добавить цветок";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox_name;
        private TextBox textBox_sort;
        private TextBox textBox_price;
        private Button button1;
    }
}