namespace FloweShop.App
{
    public partial class DeleteForm : Form
    {
        private AppDbContext _context;
        public int FlowerId { get; private set; }
        public DeleteForm()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                int id;
                int.TryParse(textBox1.Text, out id);
                FlowerId = id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            int id;
            if (!int.TryParse(textBox1.Text, out id))
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
