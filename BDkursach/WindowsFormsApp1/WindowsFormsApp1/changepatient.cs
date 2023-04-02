using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class changepatient : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");

        public changepatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dss= dateTimePicker1.Value.ToString("yyyy-MM-dd");
                connection.Open();
                string query = $"UPDATE patient SET   FIO = " + "'"
                    + textBox1.Text + "'" + ",address = " + "'" + textBox2.Text + "'" + ",tel=" + "'" +
                    textBox3.Text + "'" + ",birth_date  =" + "'" + dss + "'" +
                    ", number_uchastka = " + "'" + textBox5.Text + "'" +
                    ", invalidnost = " + "'" + textBox6.Text + "'" +
                    ", hron_zabolevanie = " + "'" + textBox7.Text + "'" +
                    ", mesto_rab_uchebi = " + "'" + textBox8.Text + "'" + "where cart_number = " + textBox9.Text + "";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }


            MessageBox.Show(
                "Запись была успешно изменена!",
                "Сообщение",
                MessageBoxButtons.OK
                );
        }
    }
}
