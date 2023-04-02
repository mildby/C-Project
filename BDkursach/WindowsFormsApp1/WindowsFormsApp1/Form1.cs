using System;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server = localhost; userid = root; password = root; database = pol");
       
        
        int m = 0;
        string currentvalue;
        
        public MainForm()
        {

            InitializeComponent();
            
            
        }

        
        private void врачиToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            m = 1;
            try
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM doctors", connection);
                DataTable DATA = new DataTable();
                SDA.Fill(DATA);
                dataGridView1.DataSource = DATA;
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
        }

        private void пациентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m = 2;
            try
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM patient", connection);
                DataTable DATA = new DataTable();
                SDA.Fill(DATA);
                dataGridView1.DataSource = DATA;
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
        }

        private void приемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m = 3;
            try
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM priem", connection);
                DataTable DATA = new DataTable();
                SDA.Fill(DATA);
                dataGridView1.DataSource = DATA;
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
        }

       

        private void отделенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m = 4;
            try
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM otdelenie", connection);
                DataTable DATA = new DataTable();
                SDA.Fill(DATA);
                dataGridView1.DataSource = DATA;
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
        }



        public void Chooseid()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int Column = 0;
                int currentRow = dataGridView1.SelectedCells[0].RowIndex;
                currentvalue = dataGridView1[Column, currentRow].Value.ToString();
            }
            else MessageBox.Show("Выберите запись для удаления!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                try
                {
                    connection.Open();
                    Chooseid();
                    string query = $"Delete FROM doctors where id_doctor = {currentvalue};";
                    MessageBox.Show("Из базы был удален врач с id = ",currentvalue);
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
            }
            if (m == 2)
            {
                try
                {
                    connection.Open();
                    Chooseid();
                    string query = $"Delete FROM patient where cart_number = {currentvalue};";
                    MessageBox.Show("Из базы был удален пациент с номером карты = ",currentvalue);
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
            }
            if(m == 3)
            {
                try
                {
                    connection.Open();
                    Chooseid();
                    string query = $"Delete FROM priem where nomer_priema = {currentvalue};";
                    MessageBox.Show("Из базы была удалена запись о приеме номер ",currentvalue);
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("select fio ,pn, vt,sr,cht,pt,sb from raspisanie,doctors where doctors.id_doctor=raspisanie.id_doctor order by fio ", connection);
                    DataTable DATA = new DataTable();
                    SDA.Fill(DATA);
                    dataGridView1.DataSource = DATA;
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                adddoctor adddoctor = new adddoctor();
                adddoctor.Show();
            }
            if (m == 2)
            {
                addpatient addpatient = new addpatient();  
                addpatient.Show();
            }
            if (m == 4)
            {
                addotdel addotdel = new addotdel();
                addotdel.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                changedoctors changedoctors = new changedoctors();
                changedoctors.Show();
            }
            if(m == 2)
            {
                changepatient changepatient = new changepatient(); 
                changepatient.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            priem priem = new priem();
            priem.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text =  $"Текущая дата и время :     " +
                $"\n{DateTime.Now}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (m == 1)
            {
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM doctors", connection);
                    DataTable DATA = new DataTable();
                    SDA.Fill(DATA);
                    dataGridView1.DataSource = DATA;
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
            }
            if(m == 2)
            {
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM patient", connection);
                    DataTable DATA = new DataTable();
                    SDA.Fill(DATA);
                    dataGridView1.DataSource = DATA;
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
            }   
            if (m == 3)
            {
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM priem", connection);
                    DataTable DATA = new DataTable();
                    SDA.Fill(DATA);
                    dataGridView1.DataSource = DATA;
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
            }
            if (m == 4)
            {
                m = 4;
                try
                {
                    connection.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter SDA = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM otdelenie", connection);
                    DataTable DATA = new DataTable();
                    SDA.Fill(DATA);
                    dataGridView1.DataSource = DATA;
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
            }
         }
    }
}
