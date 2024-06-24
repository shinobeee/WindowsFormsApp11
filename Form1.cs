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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"data source=LAB1-MAY19\\MISASME2022;initial Catalog=quanlythongtin;Integrated Security=True;Encrypt=False");
        private void opencon()
        {
            if (con.State ==ConnectionState.Closed)
            {
            con.Open(); 
            }
        }
        private void closedcon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check= false;
                throw;
            }
            closedcon();
            return check;
        }
        private DataTable red (string cmd)
        {
            opencon();
            DataTable dt=new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda=new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            closedcon();
            return dt;
        }
        private void load ()
        {
            DataTable dt = red("SELECT*FROM quanlythongtin");
            if (dt != null)
            {
dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
