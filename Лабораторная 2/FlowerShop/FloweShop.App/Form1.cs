using FloweShop.App.Models;
using Microsoft.EntityFrameworkCore;
using FloweShop.App.Data;
namespace FloweShop.App
{
    public partial class Form1 : Form
    {
        private AppDbContext _context;
        public Form1()
        {
            _context = new AppDbContext();
            InitializeComponent();
            LoadFlowersData();
            LoadCompositionData();
            LoadCompositionFlowerData();
            LoadUserData();
            LoadOrderData();
        }

        // Constructor for tests
        public Form1(AppDbContext context)
        {
            _context = context;
        }

        private void LoadUserData()
        {
            dataGridView5.Rows.Clear();
            var users = _context.Users.AsNoTracking().ToList();
            foreach (var user in users)
            {
                dataGridView5.Rows.Add(
                    user.Id,
                    user.Login,
                    user.Password);
            }
        }
        private void LoadOrderData()
        {
            dataGridView4.Rows.Clear();
            var orders = _context.Orders.AsNoTracking().ToList();
            foreach (var order in orders)
            {
                dataGridView4.Rows.Add(
                    order.Id,
                    order.DateOfCompletion,
                    order.CompositionId,
                    order.Quantity,
                    order.UserId,
                    order.TotalPrice);
            }
        }
        private void LoadCompositionData()
        {
            dataGridView2.Rows.Clear();
            var compositions = _context.Compositions.AsNoTracking().ToList();
            foreach (var composition in compositions)
            {
                dataGridView2.Rows.Add(composition.Id,
                    composition.Name,
                    composition.Price);
            }
            LoadCompositionFlowerData();
        }
        public void LoadFlowersData()
        {
            dataGridView1.Rows.Clear();
            var flowers = _context.Flowers.AsNoTracking().ToList();
            foreach (var flower in flowers)
            {
                dataGridView1.Rows.Add(flower.Id, flower.Name, flower.Sort, flower.PricePerFlower);
            }
        }
        private void LoadCompositionFlowerData()
        {
            dataGridView3.Rows.Clear();
            var data = _context.CompositionFlowers.AsNoTracking().ToList();
            foreach (var item in data)
            {
                dataGridView3.Rows.Add(item.FlowerId, item.CompositionId, item.Quantity);
            }
        }
        private void button_add_flower(object sender, EventArgs e)
        {
            string name = textBox_fl_add_name.Text;
            string sort = textBox_fl_add_sort.Text;
            decimal pricePerFlower;

            if (!decimal.TryParse(textBox_fl_add_pricePerFlower.Text, out pricePerFlower))
            {
                MessageBox.Show("Цена за штуку должна быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flower = new Flower
            {
                Name = name,
                Sort = sort,
                PricePerFlower = pricePerFlower
            };

            _context.Flowers.Add(flower);
            _context.SaveChanges();

            textBox_fl_add_name.Clear();
            textBox_fl_add_sort.Clear();
            textBox_fl_add_pricePerFlower.Clear();
            LoadFlowersData();
            MessageBox.Show("Цветок успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button_del_flower(object sender, EventArgs e)
        {
            int flowerId;

            if (!int.TryParse(textBox_fl_del_id.Text, out flowerId))
            {
                MessageBox.Show("ID цветка должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flowerToDelete = _context.Flowers.Include(f => f.CompositionFlowers)
                                                 .ThenInclude(cf => cf.Composition)
                                                 .FirstOrDefault(f => f.Id == flowerId);
            if (flowerToDelete == null)
            {
                MessageBox.Show("Цветок с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var cf in flowerToDelete.CompositionFlowers.ToList())
            {
                _context.CompositionFlowers.Remove(cf);
            }

            _context.Flowers.Remove(flowerToDelete);
            _context.SaveChanges();

            textBox_fl_del_id.Clear();
            LoadFlowersData();
            LoadCompositionData();
            LoadCompositionFlowerData();
            MessageBox.Show("Цветок успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button_update_flower(object sender, EventArgs e)
        {
            int flowerId;
            string name = textBox_fl_update_name.Text;
            string sort = textBox_fl_update_sort.Text;
            decimal pricePerFlower;

            if (!int.TryParse(textBox_fl_update_id.Text, out flowerId))
            {
                MessageBox.Show("ID цветка должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBox_fl_update_pricePerFlower.Text, out pricePerFlower))
            {
                MessageBox.Show("Цена за штуку должна быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flowerToUpdate = _context.Flowers.Include(f => f.CompositionFlowers)
                                                 .ThenInclude(cf => cf.Composition)
                                                 .FirstOrDefault(f => f.Id == flowerId);
            if (flowerToUpdate == null)
            {
                MessageBox.Show("Цветок с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal oldPrice = flowerToUpdate.PricePerFlower;

            flowerToUpdate.Name = name;
            flowerToUpdate.Sort = sort;
            flowerToUpdate.PricePerFlower = pricePerFlower;

            _context.SaveChanges();

            foreach (var cf in flowerToUpdate.CompositionFlowers)
            {
                cf.Composition.Price -= (oldPrice * cf.Quantity);
                cf.Composition.Price += (pricePerFlower * cf.Quantity);
            }

            _context.SaveChanges();

            LoadFlowersData();
            LoadCompositionData();
            LoadCompositionFlowerData();
            MessageBox.Show("Цветок успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_fl_update_id.Clear();
            textBox_fl_update_name.Clear();
            textBox_fl_update_sort.Clear();
            textBox_fl_update_pricePerFlower.Clear();
        }
        private void button_add_composition(object sender, EventArgs e)
        {
            string name = textBox_add_name.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя композиции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_add_ids.Text))
            {
                MessageBox.Show("Пожалуйста, введите id цветов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] flowerIdStrings = textBox_add_ids.Text.Split(' ');
            List<int> flowerIds = flowerIdStrings.Select(id => int.Parse(id)).ToList();

            List<Flower> flowers = _context.Flowers
                .Where(f => flowerIds.Contains(f.Id))
                .ToList();

            if (flowers.Count != flowerIds.Count)
            {
                MessageBox.Show("Один или несколько цветов не найдены в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var composition = new Composition
            {
                Name = name,
                Price = flowers.Sum(f => f.PricePerFlower),
                CompositionFlowers = flowers.Select(f => new CompositionFlower
                {
                    FlowerId = f.Id,
                    Quantity = 1
                }).ToList()
            };

            _context.Compositions.Add(composition);
            _context.SaveChanges();
            LoadCompositionData();
            MessageBox.Show("Композиция успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_add_name.Clear();
            textBox_add_ids.Clear();
        }
        private void button_del_composition(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_delete_id.Text))
            {
                MessageBox.Show("Пожалуйста, введите ID композиции для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_delete_id.Text, out int compositionId))
            {
                MessageBox.Show("Пожалуйста, введите валидный ID композиции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var composition = _context.Compositions
                                      .Include(c => c.CompositionFlowers)
                                      .FirstOrDefault(c => c.Id == compositionId);

            if (composition == null)
            {
                MessageBox.Show("Композиция с указанным ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _context.Compositions.Remove(composition);
            _context.SaveChanges();
            LoadCompositionData();
            MessageBox.Show("Композиция успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox_delete_id.Clear();
        }
        private void button_update_composition(object sender, EventArgs e)
        {
            if (ValidateInputs(out int compositionId, out string compositionName, out List<int> flowerIds))
            {
                var compositionToUpdate = _context.Compositions
                    .Include(c => c.CompositionFlowers)
                    .FirstOrDefault(c => c.Id == compositionId);

                if (compositionToUpdate == null)
                {
                    MessageBox.Show("Композиция с указанным ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var flowers = _context.Flowers
                    .Where(f => flowerIds.Contains(f.Id))
                    .ToList();

                if (flowers.Count != flowerIds.Count)
                {
                    MessageBox.Show("Один или несколько цветов не найдены в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                compositionToUpdate.Name = compositionName;

                _context.CompositionFlowers.RemoveRange(compositionToUpdate.CompositionFlowers);
                compositionToUpdate.CompositionFlowers = flowers.Select(f => new CompositionFlower
                {
                    CompositionId = compositionToUpdate.Id,
                    FlowerId = f.Id,
                    Quantity = 1
                }).ToList();

                compositionToUpdate.Price = flowers.Sum(f => f.PricePerFlower);

                _context.SaveChanges();

                LoadCompositionData();

                UpdateOrdersWithComposition(compositionToUpdate.Id);

                MessageBox.Show("Композиция успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_update_fl_ids.Clear();
                textBox_update_id.Clear();
                textBox_update_name.Clear();
            }
        }
        private void UpdateOrdersWithComposition(int compositionId)
        {
            var ordersToUpdate = _context.Orders
                .Where(o => o.CompositionId == compositionId)
                .ToList();

            foreach (var order in ordersToUpdate)
            {
                var composition = _context.Compositions
                    .Include(c => c.CompositionFlowers)
                    .FirstOrDefault(c => c.Id == order.CompositionId);

                if (composition != null)
                {
                    order.TotalPrice = order.Quantity * composition.Price;
                }
            }

            _context.SaveChanges();
        }
        private bool ValidateInputs(out int compositionId, out string compositionName, out List<int> flowerIds)
        {
            compositionId = 0;
            compositionName = textBox_update_name.Text;
            flowerIds = new List<int>();

            if (string.IsNullOrWhiteSpace(compositionName))
            {
                MessageBox.Show("Имя композиции не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(textBox_update_id.Text, out compositionId))
            {
                MessageBox.Show("ID композиции должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string[] flowerIdStrings = textBox_update_fl_ids.Text.Split(' ');
            foreach (var idString in flowerIdStrings)
            {
                if (int.TryParse(idString, out int id))
                {
                    flowerIds.Add(id);
                }
                else
                {
                    MessageBox.Show($"ID цветка '{idString}' должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        private void button_add_flowerComposition(object sender, EventArgs e)
        {
            int flowerId, compositionId, quantity;

            if (!int.TryParse(textBox_compfl_add_id_fl.Text, out flowerId))
            {
                MessageBox.Show("ID цветка должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_compfl_add_id_comp.Text, out compositionId))
            {
                MessageBox.Show("ID композиции должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_compfl_add_kol.Text, out quantity))
            {
                MessageBox.Show("Количество должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Количество должно быть положительным числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flower = _context.Flowers.Find(flowerId);
            if (flower == null)
            {
                MessageBox.Show("Цветок с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var composition = _context.Compositions.Find(compositionId);
            if (composition == null)
            {
                MessageBox.Show("Композиция с таким ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingCompositionFlower = _context.CompositionFlowers
                .FirstOrDefault(cf => cf.CompositionId == compositionId && cf.FlowerId == flowerId);

            if (existingCompositionFlower != null)
            {
                existingCompositionFlower.Quantity += quantity;
                composition.Price += flower.PricePerFlower * quantity;
            }
            else
            {
                var compositionFlower = new CompositionFlower
                {
                    FlowerId = flowerId,
                    CompositionId = compositionId,
                    Quantity = quantity
                };

                _context.CompositionFlowers.Add(compositionFlower);
                composition.Price += flower.PricePerFlower * quantity;
            }

            _context.SaveChanges();

            textBox_compfl_add_id_fl.Clear();
            textBox_compfl_add_id_comp.Clear();
            textBox_compfl_add_kol.Clear();
            LoadCompositionData();
            LoadCompositionFlowerData();
            MessageBox.Show("Цветок успешно добавлен в композицию.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button_del_flowerComposition(object sender, EventArgs e)
        {
            int flowerId, compositionId;

            if (!int.TryParse(textBox_compfl_del_id_fl.Text, out flowerId))
            {
                MessageBox.Show("ID цветка должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_compfl_del_id_comp.Text, out compositionId))
            {
                MessageBox.Show("ID композиции должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flower = _context.Flowers.Find(flowerId);
            if (flower == null)
            {
                MessageBox.Show("Цветок с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var composition = _context.Compositions.Find(compositionId);
            if (composition == null)
            {
                MessageBox.Show("Композиция с таким ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingCompositionFlower = _context.CompositionFlowers
                .FirstOrDefault(cf => cf.CompositionId == compositionId && cf.FlowerId == flowerId);

            if (existingCompositionFlower == null)
            {
                MessageBox.Show("Цветок не найден в указанной композиции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            composition.Price -= flower.PricePerFlower * existingCompositionFlower.Quantity;
            _context.CompositionFlowers.Remove(existingCompositionFlower);
            _context.SaveChanges();

            textBox_compfl_del_id_fl.Clear();
            textBox_compfl_del_id_comp.Clear();
            LoadCompositionData();
            LoadCompositionFlowerData();
            MessageBox.Show("Цветок успешно удален из композиции.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button_update_flowerComposition(object sender, EventArgs e)
        {
            int flowerId, compositionId, quantity;

            if (!int.TryParse(textBox_compfl_update_id_fl.Text, out flowerId))
            {
                MessageBox.Show("ID цветка должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_compfl_update_id_comp.Text, out compositionId))
            {
                MessageBox.Show("ID композиции должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_compfl_update_kol.Text, out quantity))
            {
                MessageBox.Show("Количество цветков должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var flower = _context.Flowers.Find(flowerId);
            if (flower == null)
            {
                MessageBox.Show("Цветок с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var composition = _context.Compositions.Find(compositionId);
            if (composition == null)
            {
                MessageBox.Show("Композиция с таким ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingCompositionFlower = _context.CompositionFlowers
                .FirstOrDefault(cf => cf.CompositionId == compositionId && cf.FlowerId == flowerId);

            if (existingCompositionFlower == null)
            {
                MessageBox.Show("Цветок не найден в указанной композиции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal oldTotalPrice = existingCompositionFlower.Quantity * flower.PricePerFlower;
            existingCompositionFlower.Quantity = quantity;
            decimal newTotalPrice = existingCompositionFlower.Quantity * flower.PricePerFlower;

            composition.Price += (newTotalPrice - oldTotalPrice);

            _context.SaveChanges();

            textBox_compfl_update_id_fl.Clear();
            textBox_compfl_update_id_comp.Clear();
            textBox_compfl_update_kol.Clear();
            LoadCompositionFlowerData();
            LoadCompositionData();
            MessageBox.Show("Количество цветков в композиции успешно обновлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public bool ValidatePassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            if (!password.All(c => char.IsLetterOrDigit(c) && c < 128)) // Проверка на английские буквы и цифры
                return false;

            return true;
        }
        private void button_log_reg(object sender, EventArgs e)
        {
            string login = textBox_add_login.Text;
            string password = textBox_add_password.Text;

            if (!ValidatePassword(password))
            {
                MessageBox.Show("Пароль должен содержать не менее 8 символов, включая заглавную букву и цифру, и должен состоять только из английских букв.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Login == login);
            if (existingUser != null)
            {
                if (existingUser.Password == password)
                {
                    MessageBox.Show("Вы успешно вошли.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Неверный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            var newUser = new User
            {
                Login = login,
                Password = password
            };

            textBox_add_login.Clear();
            textBox_add_password.Clear();
            _context.Users.Add(newUser);
            _context.SaveChanges();
            LoadUserData();
            MessageBox.Show("Вы успешно зарегистрировались.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button_del_user(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(textBox_user_del_id.Text, out userId))
            {
                MessageBox.Show("ID пользователя должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var _context = new AppDbContext())
            {
                var user = _context.Users.Include(u => u.Orders).FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ordersToDelete = _context.Orders.Where(o => o.UserId == userId).ToList();
                _context.Orders.RemoveRange(ordersToDelete);
                _context.Users.Remove(user);

                try
                {
                    _context.SaveChanges();
                    MessageBox.Show("Пользователь и его заказы успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при удалении пользователя: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBox_user_del_id.Clear();
                LoadUserData();
                LoadOrderData();
            }
        }
        private void button_update_user(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(textBox_user_update_id.Text, out userId))
            {
                MessageBox.Show("ID пользователя должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newLogin = textBox_user_update_login.Text;
            string newPassword = textBox_user_update_password.Text;

            if (string.IsNullOrWhiteSpace(newLogin))
            {
                MessageBox.Show("Логин не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePassword(newPassword))
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов, содержать заглавные буквы и цифры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = _context.Users.Find(userId);
            if (user == null)
            {
                MessageBox.Show("Пользователь с таким ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.Login = newLogin;
            user.Password = newPassword;

            _context.SaveChanges();
            textBox_user_update_id.Clear();
            textBox_user_update_login.Clear();
            textBox_user_update_password.Clear();
            LoadUserData();
            MessageBox.Show("Данные пользователя успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void button_order_add(object sender, EventArgs e)
        {
            DateTime dateOfCompletion;
            int compositionId, userId, quantity;

            if (!DateTime.TryParse(textBox_order_add_date.Text, out dateOfCompletion))
            {
                MessageBox.Show("Некорректная дата выполнения заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dateOfCompletion = DateTime.SpecifyKind(dateOfCompletion, DateTimeKind.Utc);

            if (!int.TryParse(textBox_order_add_id_comp.Text, out compositionId))
            {
                MessageBox.Show("ID композиции должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_order_add_id_user.Text, out userId))
            {
                MessageBox.Show("ID пользователя должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox_order_add_kol.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Количество композиций должно быть положительным числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var composition = _context.Compositions.Find(compositionId);
            var user = _context.Users.Find(userId);
            if (composition == null)
            {
                MessageBox.Show("Композиция с указанным ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user == null)
            {
                MessageBox.Show("Пользователь с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalPrice = quantity * composition.Price;
            var order = new Order
            {
                DateOfCompletion = dateOfCompletion,
                CompositionId = compositionId,
                UserId = userId,
                Quantity = quantity,
                TotalPrice = totalPrice
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            textBox_order_add_date.Clear();
            textBox_order_add_id_comp.Clear();
            textBox_order_add_id_user.Clear();
            textBox_order_add_kol.Clear();
            MessageBox.Show("Заказ успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadOrderData();
        }
        private void button_order_update(object sender, EventArgs e)
        {
            if (ValidateOrderInputs(out int orderId, out DateTime dateOfCompletion, out int compositionId, out int userId, out int quantity))
            {
                var orderToUpdate = _context.Orders
                    .Include(o => o.User)
                    .FirstOrDefault(o => o.Id == orderId);

                if (orderToUpdate == null)
                {
                    MessageBox.Show("Заказ с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                orderToUpdate.DateOfCompletion = DateTime.SpecifyKind(dateOfCompletion, DateTimeKind.Utc);
                orderToUpdate.CompositionId = compositionId;
                orderToUpdate.UserId = userId;
                orderToUpdate.Quantity = quantity;

                var composition = _context.Compositions.Find(compositionId);
                if (composition != null)
                {
                    orderToUpdate.TotalPrice = quantity * composition.Price;
                }

                _context.SaveChanges();
                LoadOrderData();

                MessageBox.Show("Заказ успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_order_update_id.Clear();
                textBox_order_update_date.Clear();
                textBox_order_update_id_comp.Clear();
                textBox_order_update_id_user.Clear();
                textBox_order_update_kol.Clear();
            }
        }
        private bool ValidateOrderInputs(out int orderId, out DateTime dateOfCompletion, out int compositionId, out int userId, out int quantity)
        {
            if (!int.TryParse(textBox_order_update_id.Text, out orderId))
            {
                MessageBox.Show("ID заказа должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateOfCompletion = default;
                compositionId = default;
                userId = default;
                quantity = default;
                return false;
            }

            if (!DateTime.TryParse(textBox_order_update_date.Text, out dateOfCompletion))
            {
                MessageBox.Show("Некорректная дата выполнения заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                compositionId = default;
                userId = default;
                quantity = default;
                return false;
            }

            if (!int.TryParse(textBox_order_update_id_comp.Text, out compositionId))
            {
                MessageBox.Show("ID композиции должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userId = default;
                quantity = default;
                return false;
            }

            if (!int.TryParse(textBox_order_update_id_user.Text, out userId))
            {
                MessageBox.Show("ID пользователя должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity = default;
                return false;
            }

            if (!int.TryParse(textBox_order_update_kol.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Количество композиций должно быть положительным числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void button_order_del(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_order_del_id.Text, out int orderId))
            {
                var orderToDelete = _context.Orders
                    .Include(o => o.User)
                    .FirstOrDefault(o => o.Id == orderId);

                if (orderToDelete == null)
                {
                    MessageBox.Show("Заказ с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (orderToDelete.User != null)
                {
                    orderToDelete.User.Orders.Remove(orderToDelete);
                }

                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
                LoadOrderData();

                MessageBox.Show("Заказ успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_order_del_id.Clear();
            }
            else
            {
                MessageBox.Show("Некорректный формат ID заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
