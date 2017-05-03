using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class customerOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        OracleDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandText = "addExclusiveOrder";
        comm.CommandType = CommandType.StoredProcedure;
        comm.Parameters.Add("p_customer_id", OracleDbType.Int32, ParameterDirection.Input).Value = 2;
        comm.Parameters.Add("p_privateOrder_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = userOrderName.Text;
        comm.Parameters.Add("p_privateOrder_category", OracleDbType.Varchar2, ParameterDirection.Input).Value = categoryList.Text;
        comm.Parameters.Add("p_privateOrder_description", OracleDbType.Varchar2, ParameterDirection.Input).Value = orderDescription.Text;
        DataTable table;
        try
        {
            comm.Connection.Open();
            reader = comm.ExecuteReader();
            table = new DataTable();
            table.Load(reader);

            reader.Close();

        }
        catch
        {
           lblError.Text = "The value was nor written into the text";
        }

        finally
        {
            comm.Connection.Close();
            userOrderName.Text = "";
            categoryList.Text = "";
            orderDescription.Text = "";

            lblError.Text = "Success!";
        }
        //GridView1.DataSource = table;
        //GridView1.DataBind();

    }
}