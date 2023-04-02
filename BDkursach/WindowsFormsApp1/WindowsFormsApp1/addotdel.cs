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

namespace WindowsFormsApp1
{
    public partial class addotdel : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");

        public addotdel()
        {
            InitializeComponent();
        }

        private void addotdel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = $"INSERT otdelenie VALUES  (" + textBox5.Text + "," + "'"
                    + textBox1.Text + "'" + "," + "'" + textBox2.Text + "'"  + ")";
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
