using FloweShop.App.Models;
using System;
namespace FloweShop.App
{
    public partial class AddForm : Form
    {
        public Flower NewFlower { get; private set; }
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    NewFlower = new Flower
                    {
                        Name = textBox_name.Text,
                        Sort = textBox_sort.Text,
                        PricePerFlower = decimal.Parse(textBox_price.Text)
                    };
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Ошибка формата: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = !string.IsNullOrWhiteSpace(textBox_name.Text) &&
                           !string.IsNullOrWhiteSpace(textBox_sort.Text) &&
                           !string.IsNullOrWhiteSpace(textBox_price.Text);

            if (!isValid)
                return false;

            decimal price;
            if (!decimal.TryParse(textBox_price.Text, out price))
            {
                MessageBox.Show("Цена за 1 шт. должна быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
