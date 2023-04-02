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
    public partial class changedoctors : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");

        public changedoctors()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string dss = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string dss1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string query = $"UPDATE doctors SET   FIO = " + "'"
                    + textBox1.Text + "'" + ",Birth_date = " + "'" + dss + "'" + ",Priem_na_raboty=" + "'" +
                    dss1 + "'" + ",Address  =" + "'" + textBox4.Text + "'" +
                    ", Passport = " + "'" + textBox5.Text + "'" +
                    ", specialnost = " + "'" + textBox6.Text + "'" +
                    ", number_uchastka = " + "'" + textBox7.Text + "'" +
                    ", number_otdelenia = " + "'" + textBox8.Text + "'" + "where id_doctor = "+textBox9.Text+"";
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
