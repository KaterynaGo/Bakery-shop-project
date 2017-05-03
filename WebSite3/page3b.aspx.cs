using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;



public partial class page3b : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.Text;
        comm.CommandText = "select  product_id, productname, price, product_description, category from product";

        DataTable table;
        try
        {
            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            reader.Close();

        }
        catch
        {
            throw;
        }

        finally
        {
            comm.Connection.Close();
        }
        GridView1.DataSource = table;
        GridView1.DataBind();


    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = GridView1.Rows[index];

            // Add code here to add the item to the shopping cart.
            if (!IsPostBack)
            {
                SqlConnection conn = null;
                SqlDataReader rdr = null;

                // typically obtained from user

                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    // create and open a connection object
                    conn = new
                        SqlConnection(connectionString);

                    // 1. create a command object identifying
                    // the stored procedure
                    SqlCommand cmd = new SqlCommand(
                        "addItemsToCard", conn);

                    // 2. set the command object so it knows
                    // to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which
                    // will be passed to the stored procedure
                    cmd.Parameters.AddWithValue("@Product_id", row.Cells[1]);

                    // execute the command
                    rdr = cmd.ExecuteReader();

                    // iterate through results, printing each to console

                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //OracleConnection conn = new OracleConnection();
        //conn.ConnectionString = connectionString;
        //OracleCommand comm = conn.CreateCommand();
        //comm.CommandText = "NEW_SALES_PRICE_FUNCTION";
        //comm.CommandType = CommandType.StoredProcedure;
        //comm.Parameters.Add("p_itemName", OracleDbType.Int16, ParameterDirection.Input).Value = Convert.ToInt32(txtItemPrice.Text);
        //comm.Parameters.Add("new_discount_price", OracleDbType.Int32).Direction = ParameterDirection.Output;
        //try
        //{
        //    conn.Open();
        //    comm.ExecuteNonQuery();
        //    OracleDataReader dr = comm.ExecuteReader();
        //    lblNewPrice.Text = 
        //}
        //catch (Exception ex)
        //{
        //    lblNewPrice.Text = ex.ToString();
        //}

        //conn.Close();
        try
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //string conString = "User Id=hr;Password=hr;Data Source=localhost:1521/pdborcl;Pooling=false;";
            OracleConnection cn = new OracleConnection();
            cn.ConnectionString = conString;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "new_sales_price_function";

            //cmd.BindByName = true;



            cmd.Parameters.Add("sales_persent", OracleDbType.Int16,
                ParameterDirection.ReturnValue);


            cmd.Parameters.Add("price", OracleDbType.Int16, ParameterDirection.Input).Value = Convert.ToInt16(txtItemPrice.Text);
            
            cn.Open();
            using (var dr = cmd.ExecuteReader())
            {
                // do some work here
                lblNewPrice.Text = cmd.Parameters["sales_persent"].Value.ToString() +"$" + "<br>";
            }
            cn.Close();
        }
        catch (Exception ex)
        {

            lblNewPrice.Text = "Error bro in method buttonClick()." + "<br>";
            lblNewPrice.Text += ex.Message + "<br>" + ex.StackTrace;
        }
    }

}


    
    
        

