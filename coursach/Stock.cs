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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM retail where quantity>0", db.getConnection());
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
            label6.Text = dataGridView1[0, row].Value.ToString();
            label7.Text = dataGridView1[1, row].Value.ToString();
            label9.Text = dataGridView1[3, row].Value.ToString();
            label10.Text = dataGridView1[4, row].Value.ToString();
            label8.Text = dataGridView1[2, row].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ПРОДАЖА. Для того чтобы выполнить продажу, кликните на нужный товар в таблице, затем введите количество товара и нажмите кнопку ПРОДАТЬ." +
                "\n\nСОРТИРОВКА. Для того чтобы отсортировать информацию в таблице и выберите параметр для сортировки (по умолчанию ID)." +
                "\n Для того чтобы изменить порядок сортировки - нажмите на кнопку рядом со списком. В - возрастание | У - убывание.",
                "Помощь",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (label7.Text == "" || label8.Text == "" || label9.Text == "" || label10.Text == "")
            {
                MessageBox.Show(
                    "Выберите товар для продажи",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                if ((Convert.ToInt32(label10.Text) - Convert.ToInt32(numericUpDown1.Value) < 0))
                {
                    MessageBox.Show(
                        "Недостаточно товара для продажи введенного количества",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else
                {
                    DB db = new DB();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    MySqlCommand command = new MySqlCommand("UPDATE `retail` SET `quantity` = @Quantity WHERE `id` = @ID", db.getConnection());



                    command.Parameters.Add("@ID", MySqlDbType.Int32).Value = label6.Text;
                    command.Parameters.AddWithValue("@Quantity", Convert.ToInt32(label10.Text) - Convert.ToInt32(numericUpDown1.Value));
                    db.openConnection();
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show(
                           "Сумма: " + numericUpDown1.Value * Convert.ToInt32(label9.Text) + ".",
                           "Подытог",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                           );
                        MessageBox.Show(
                            "Успешно продано.",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                            );
                        numericUpDown1.Value = 0;
                        button8.PerformClick();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Ошибка продажи",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    }
                    LoadData();
                    db.closeConnection();
                }
            }
        }



        



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (button6.Text.Trim() == "В")
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

  

        private void button8_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            textBox3.Clear();
            comboBox2.SelectedIndex = 0;
            LoadData();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != "")
            {
                DB db = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM retail WHERE `name` LIKE '%@Name%' ", db.getConnection());
                command.CommandText = "SELECT* FROM retail WHERE `name` LIKE '%" + textBox3.Text.Trim() + "%';";
                //command.Parameters.AddWithValue("@Name", textBox3.Text.Trim());
                db.openConnection();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                db.closeConnection();
            }
            else
            {
                LoadData();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
