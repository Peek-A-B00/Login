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

namespace justLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        /// string connection
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3QM4HVF;Initial Catalog=LoginDemo;Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = textBox1.Text;
            user_password = textBox2.Text;

            try
            {
                String querry = "Select *from LoginDemo where username = '" + textBox1.Text + "' And password = '" + textBox2.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(querry,conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;

                    /// Page that need to be loaded next

                    menu form2 = new menu();
                    form2.Show();
                    this.Hide();
                  }
                else
                {
                    MessageBox.Show("Invalid Login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();

                    // to focus  username
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Invalid User Name or Password");
            }
            finally
            {
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to Exit? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
