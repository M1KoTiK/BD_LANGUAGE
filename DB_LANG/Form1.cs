using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_LANG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string getpass()
        {
            return "";
        }
        public void GetAllClient()
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT[ID],[FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email],[Phone], G.[Name],[PhotoPath] " +
                "FROM[Client] as C " +
                "JOIN Gender as G ON G.Code = C.GenderCode ";





                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }


        }
        public void SearchByFIO(string name)
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT[ID],[FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email] ,[Phone],G.[Name],[PhotoPath] "+
                "FROM[Client] as C "+
                "JOIN Gender as G ON G.Code = C.GenderCode "+
                "WHERE FirstName LIKE '%"+name+"%'  or LastName LIKE '%"+name+"%' or Patronymic LIKE '%"+name+"%' "; 

                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }
        }

        public void SearchByEmail(string name)
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT[ID],[FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email] ,[Phone],G.[Name],[PhotoPath] " +
                "FROM[Client] as C " +
                "JOIN Gender as G ON G.Code = C.GenderCode " +
                "WHERE Email LIKE '%" + name + "%'";

                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }
        }
        public void SortByGender(int name)
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT[ID],[FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email] ,[Phone],G.[Name],[PhotoPath] " +
                "FROM[Client] as C " +
                "JOIN Gender as G ON G.Code = C.GenderCode " +
                "WHERE c.GenderCode = '" + name + "'";

                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }
        }
        public void SearchByPhone(string name)
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT[ID],[FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email] ,[Phone],G.[Name],[PhotoPath] " +
                "FROM[Client] as C " +
                "JOIN Gender as G ON G.Code = C.GenderCode " +
                "WHERE Phone LIKE '%" + name + "%'";

                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }
        }

        public void FillComboBox()
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT Code,[Name] FROM Gender";
                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                comboBox1.DataSource = dt;
                comboBox1.Update();
                comboBox1.ValueMember = "Code";
                comboBox1.DisplayMember = "Name";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllClient();
            comboBox1.Items.Insert(0, "ALL");
            FillComboBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            SearchByFIO(name);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            SearchByEmail(name);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            SearchByPhone(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewClient newform = new AddNewClient();
            newform.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete newform = new Delete();
            newform.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SortByGender(comboBox1.SelectedIndex + 1);
        }
    }
}
