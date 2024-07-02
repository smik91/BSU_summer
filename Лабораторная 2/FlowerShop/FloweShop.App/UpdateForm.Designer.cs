namespace FloweShop.App
{
    partial class UpdateForm
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
            textBox_price = new TextBox();
            textBox_sort = new TextBox();
            textBox_name = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox_id = new TextBox();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox_price
            // 
            textBox_price.Location = new Point(215, 161);
            textBox_price.Margin = new Padding(4);
            textBox_price.Name = "textBox_price";
            textBox_price.Size = new Size(179, 37);
            textBox_price.TabIndex = 11;
            // 
            // textBox_sort
            // 
            textBox_sort.Location = new Point(215, 109);
            textBox_sort.Margin = new Padding(4);
            textBox_sort.Name = "textBox_sort";
            textBox_sort.Size = new Size(179, 37);
            textBox_sort.TabIndex = 10;
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(215, 54);
            textBox_name.Margin = new Padding(4);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(179, 37);
            textBox_name.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(16, 161);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(150, 32);
            label3.TabIndex = 8;
            label3.Text = "Цена за 1 шт.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(16, 109);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 32);
            label2.TabIndex = 7;
            label2.Text = "Сорт";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(16, 58);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 32);
            label1.TabIndex = 6;
            label1.Text = "Имя";
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(215, 6);
            textBox_id.Margin = new Padding(4);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(179, 37);
            textBox_id.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(16, 11);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(34, 32);
            label4.TabIndex = 12;
            label4.Text = "Id";
            // 
            // button1
            // 
            button1.Location = new Point(360, 302);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(161, 74);
            button1.TabIndex = 14;
            button1.Text = "Обновить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 389);
            Controls.Add(button1);
            Controls.Add(textBox_id);
            Controls.Add(label4);
            Controls.Add(textBox_price);
            Controls.Add(textBox_sort);
            Controls.Add(textBox_name);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "UpdateForm";
            Text = "UpdateForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_price;
        private TextBox textBox_sort;
        private TextBox textBox_name;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox_id;
        private Label label4;
        private Button button1;
    }
}