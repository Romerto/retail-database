using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coursach
{
    public partial class All : Form
    {
        public All()
        {   
            InitializeComponent();
        }

        private void All_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void All_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM retail", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString());
            textBox1.Text = dataGridView1[0, row].Value.ToString();
            textBox2.Text = dataGridView1[1, row].Value.ToString();
            textBox4.Text = dataGridView1[3, row].Value.ToString();
            textBox5.Text = dataGridView1[4, row].Value.ToString();
            comboBox1.Text = dataGridView1[2, row].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `retail` SET `name` = @Name, `type` = @Type, `price` = @Price, `quantity` = @Quantity WHERE `id` = @ID", db.getConnection());
            if (textBox2.Text == "" || comboBox1.SelectedIndex==-1 || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show(
                                   "Заполните все поля",
                                   "Ошибка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                   );
            }
            else
            { 
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = textBox1.Text;
                command.Parameters.AddWithValue("@Name", textBox2.Text.Trim());
                command.Parameters.AddWithValue("@Type", comboBox1.Text.Trim());
                command.Parameters.AddWithValue("@Price", textBox4.Text.Trim());
                command.Parameters.AddWithValue("@Quantity", textBox5.Text.Trim());
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(
                        "Запись обновлена успешно",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    LoadData();
                }
                else
                {
                    MessageBox.Show(
                        "Ошибка обновления записи",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ДОБАВЛЕНИЕ. Для того чтобы добавить информаицю о позиции, введите данные в соответствующие поля (КРОМЕ ПОЛЯ ID), затем нажмите кнопку ДОБАВИТЬ." +
                "\n\nРЕДАКТИРОВАНИЕ. Для того чтобы обновить информацию о позиции, нажмите на нее в таблице, затем введите новые данные в соответствующие поля и нажмите кнопку СОХРАНИТЬ. " +
                "\n\nУДАЛЕНИЕ. Для того чтобы удалить информацию о позиции, нажмите на нее в таблице, затем нажмите кнопку УДАЛИТЬ.",
                "Помощь",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM retail WHERE id = @ID", db.getConnection());
            if (textBox2.Text == "" || comboBox1.SelectedIndex==-1 || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show(
                                   "Заполните все поля",
                                   "Ошибка",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                   );
            }
            else
            {
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = textBox1.Text;
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MessageBox.Show
                    (
                    "Запись удалена успешно",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            
            LoadData();
            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `retail` (`name`, `type`, `price`, `quantity`) VALUES (@Name, @Type, @Price, @Quantity)", db.getConnection());

            if (textBox2.Text == "" || comboBox1.SelectedIndex==-1 || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show(
                    "Заполните все поля",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                command.Parameters.AddWithValue("@Name", textBox2.Text.Trim());
                command.Parameters.AddWithValue("@Type", comboBox1.Text.Trim());
                command.Parameters.AddWithValue("@Price", textBox4.Text.Trim());
                command.Parameters.AddWithValue("@Quantity", textBox5.Text.Trim());
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                MessageBox.Show(
                    "Запись добавлена успешно",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
            LoadData();
            db.closeConnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

    

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(button6.Text.Trim() == "В")
                dataGridView1.Sort(dataGridView1.Columns[comboBox2.SelectedIndex], ListSortDirection.Ascending);
            if (button6.Text.Trim() == "У")
                dataGridView1.Sort(dataGridView1.Columns[comboBox2.SelectedIndex], ListSortDirection.Descending);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Выберите колонку для сортировки",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                if (button6.Text.Trim() == "В")
                {
                    button6.Text = "У";
                    dataGridView1.Sort(dataGridView1.Columns[comboBox2.SelectedIndex], ListSortDirection.Descending);
                }
                else
                {
                    button6.Text = "В";
                    dataGridView1.Sort(dataGridView1.Columns[comboBox2.SelectedIndex], ListSortDirection.Ascending);
                }
            }
        }
    }
}
