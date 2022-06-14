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
    public partial class AddNewClient : Form
    {
        public string getpass()
        {
            return "Flaiw12356";
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
                gender.DataSource = dt;
                gender.Update();
                gender.ValueMember = "Code";
                gender.DisplayMember = "Name";
            }
        }
      
     
       
       
        
        public AddNewClient()
        {
            InitializeComponent();
        }

        private void AddNewClient_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AddClient(Fname.Text, Lname.Text, Mname.Text, gender.SelectedValue, phone.Text, Email.Text, dateB.Value);
            int sex = gender.SelectedIndex + 1;
            using (SqlConnection Con = new SqlConnection($@"Data source= 10.111.105.2,1433\SQLEXPRESS;Initial Catalog=language2;User ID=20.101-10;Password={getpass()}"))
                {

                    Con.Open();              
                    string query = "INSERT INTO[Client] " +
                "([FirstName],[LastName],[Patronymic],[Birthday],[RegistrationDate],[Email],[Phone],[GenderCode]) " +
                "VALUES('"+Fname.Text +"', '"+Lname.Text+"', '"+Mname.Text+"', '"+dateB.Value+"', '"+DateTime.Now+"', '"+Email.Text+"', '"+phone.Text+"', "+gender.SelectedValue+")";
                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();

                }              
            
            
        }
    }
}
