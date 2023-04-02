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
    public partial class adddoctor : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");

        public adddoctor()
        {
            InitializeComponent();
        }

        private void adddoctor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dss = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string dss1 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                connection.Open();
                string query = $"INSERT doctors VALUES  (" + textBox9.Text + "," + "'"
                    + textBox1.Text+ "'" + "," + "'" + dss1 + "'" + "," + "'" +
                     dss+ "'" + "," + "'" + textBox4.Text + "'" +
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
