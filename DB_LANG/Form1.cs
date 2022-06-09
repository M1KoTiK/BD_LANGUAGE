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


        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllClient();
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
    }
}
