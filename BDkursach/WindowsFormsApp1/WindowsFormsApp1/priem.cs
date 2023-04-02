using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class priem : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");

        public priem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ds= dateTimePicker1.Value.ToString("yyyy-MM-dd");
                connection.Open();
                string query = $"INSERT priem VALUES  (" + textBox5.Text + "," + "'"
                    + textBox1.Text + "'" + "," + "'" + ds + "'" + "," + "'" +
                    textBox3.Text + "'" + "," + "'" + textBox4.Text + "'" +
                    ")";
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
                "Пациент был записан!",
                "Сообщение",
                MessageBoxButtons.OK
                );
        }
    }
}
