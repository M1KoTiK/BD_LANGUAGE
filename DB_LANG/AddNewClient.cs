using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_LANG
{
    public partial class AddNewClient : Form
    {
        public AddNewClient()
        {
            InitializeComponent();
        }

        private void AddNewClient_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("");
        }
    }
}
