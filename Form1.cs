using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TiresShop
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DBContext.ConnectToDB();
            dataGridView1.DataSource = Product.GetProducts();
            dataGridView1.Columns[0].Visible = false;
        }

    }
}
