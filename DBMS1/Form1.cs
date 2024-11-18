
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DBMS1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void connect()
        {
            string server = @".\sqlexpress";
            string db = "Minimart";
            string stcCon = string.Format(@"Data Source={0};Initial Catalog={1};" + "Integrated Security=True;Encrypt=False", server, db);

            conn = new SqlConnection(stcCon);
            conn.Open();
        }
        private void disconnect()
        {
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            string sql = "select*from Products";
            //da = new SqlDataAdapter(sql, conn);
            // DataSet ds = new DataSet();
            // da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];

        }
        private void showData(string sql)
        {
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void พนักงาน(object sender, EventArgs e)
        {
            showData("select EmployeeID,Title+FirstName+''+LastName EmpName,Position\r\nfrom Employees");
        }

        private void ประเภทสินค้า(object sender, EventArgs e)
        {
            showData("select * from Categories");
        }

        private void รายชื่อค้า(object sender, EventArgs e)
        {
            showData("select * from Products");
        }
    }
} 

