//using Oracle.DataAccess;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class page2b : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandText = "SEARCHITEMNew";
        comm.CommandType = CommandType.StoredProcedure;
        userRecipeName.Text = "";
       // categoryList.Text = "Cake";
        comm.Parameters.Add("p_itemName", OracleDbType.Varchar2, ParameterDirection.Input).Value = userRecipeName.Text;
        comm.Parameters.Add("p_category", OracleDbType.Varchar2, ParameterDirection.Input).Value = categoryList.Text;

        comm.Parameters.Add("ITEMDETAILS", OracleDbType.RefCursor, ParameterDirection.Output);

        //comm.Parameters.Add("category", OracleDbType.RefCursor, ParameterDirection.Output);
        //comm.Parameters.Add("product_description", OracleDbType.RefCursor, ParameterDirection.Output);
        //comm.Parameters.Add("price", OracleDbType.RefCursor, ParameterDirection.Output);

        /* comm.Parameters.Add("@ProductName", System.Data.SqlDbType.NVarChar);
         comm.Parameters["@ProductName"].Value = string.Format("%{0}%", userRecipeName.Text);

         comm.Parameters.Add("@Category", System.Data.SqlDbType.NVarChar);
         comm.Parameters["@Category"].Value = string.Format("%{0}%", categoryList.SelectedItem.Text);*/

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
}