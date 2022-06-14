using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_LANG
{

    public partial class Delete : Form
    {
        public string getpass()
        {
            return "";
        }
        public void SearchBy(string name)
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "SELECT[ID],[FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email] ,[Phone],G.[Name],[PhotoPath] " +
                "FROM[Client] as C " +
                "JOIN Gender as G ON G.Code = C.GenderCode " +
                "WHERE FirstName LIKE '%" + name + "%'  or LastName LIKE '%" + name + "%' or Patronymic LIKE '%" + name + "%' or Email LIKE '%" + name + "%'  ";

                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }
        }
        public void DeleteBy(string name)
        {
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
            {

                Con.Open();
                string query = "DELETE FROM [Client]  " +
                "WHERE FirstName LIKE '%" + name + "%'  or LastName LIKE '%" + name + "%' or Patronymic LIKE '%" + name + "%' or Email LIKE '%" + name + "%'  ";

                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                Table1.DataSource = dt;
                Table1.Update();
            }
        }

        public Delete()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchBy(textBox1.Text);
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void Table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteBy(textBox1.Text);
        }
    }
}
