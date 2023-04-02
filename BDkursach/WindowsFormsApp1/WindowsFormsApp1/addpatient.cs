using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class addpatient : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");

        public addpatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dss = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                connection.Open();
                string query = $"INSERT patient VALUES  (" + textBox9.Text + "," + "'"
                    + textBox1.Text + "'" + "," + "'" + textBox2.Text + "'" + "," + "'" +
                    textBox3.Text + "'" + "," + "'" +dss + "'" +
                    "," + "'" + textBox5.Text + "'" +
                    "," + "'" + textBox6.Text + "'" +
                    "," + "'" + textBox7.Text + "'" +
                    "," + "'" + textBox8.Text + "'" + ")";
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
                "Запись была успешно добавлена!",
                "Сообщение",
                MessageBoxButtons.OK
                );

        }
    }
    
}
