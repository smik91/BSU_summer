using FloweShop.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FloweShop.App
{
    public partial class UpdateForm : Form
    {
        public Flower FlowerToUpdate { get; private set; }
        AppDbContext _context;
        public int FlowerId { get; set; }
        public UpdateForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                try
                {
                    FlowerToUpdate = new Flower
                    {
                        Name = textBox_name.Text,
                        Sort = textBox_sort.Text,
                        PricePerFlower = decimal.Parse(textBox_price.Text)
                    };
                    int id;
                    int.TryParse(textBox_id.Text, out id);
                    FlowerId = id;
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

            int id;
            if (!int.TryParse(textBox_id.Text, out id))
            {
                MessageBox.Show("ID должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (_context.Flowers.Find(id) == null)
            {
                MessageBox.Show("Цветка с таким ID нет в БД.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
