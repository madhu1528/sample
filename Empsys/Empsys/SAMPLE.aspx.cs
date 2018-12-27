using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Empsys
{
    public partial class SAMPLE : System.Web.UI.Page
    {
        static string connectionString = "Data Source=MADHUBABU-PC;Initial Catalog=msdemodb;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
        //for git commit
            if (IsPostBack == false)
            {
                gedata();
            }
            Label1.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
               connection.Open();
               HiddenField1.Value = "Insert";
               SqlCommand com = new SqlCommand("EmpEntry", connection);  //Stored Procedure name //creating  SqlCommand  object
               com.CommandType = CommandType.StoredProcedure;            //here we declaring command type as stored Procedure
               // /* adding paramerters to  SqlCommand below *\
               com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();//for ing hidden value to preform insert operation
               com.Parameters.AddWithValue("@EName",txtName.Text.ToString());        //Employee Name
               com.Parameters.AddWithValue("@DOB ", txtDOB.Text.ToString());         //Employee Dob
               com.Parameters.AddWithValue("@Location ",txtLocation.Text.ToString());//Employee Location
               com.ExecuteNonQuery();                     //executing the sqlcommand
               connection.Close();
               Label1.Visible = true;
               Label1.Text = "Records are Submitted Successfully";
               gedata();
        }

        public void gedata()
        {
            connection.Open();
            HiddenField1.Value = "Select";
            SqlCommand com = new SqlCommand("EmpEntry", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            connection.Close();

        }
        protected void edit(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gedata();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gedata();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            connection.Open();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            HiddenField1.Value = "Update";
            SqlCommand com = new SqlCommand("EmpEntry", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
            com.Parameters.AddWithValue("@EName", ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString());
            com.Parameters.AddWithValue("@DOB ", ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString());
            com.Parameters.AddWithValue("@Location ", ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString());
            com.Parameters.AddWithValue("@EmpId", SqlDbType.Int).Value = id;
            com.ExecuteNonQuery();
            connection.Close();
            GridView1.EditIndex = -1;
            gedata();

        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            connection.Open();
            int EmpId = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            HiddenField1.Value = "delete";
            SqlCommand com = new SqlCommand("EmpEntry", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();
            com.Parameters.AddWithValue("EmpId", SqlDbType.Int).Value = EmpId;
            com.ExecuteNonQuery();
            connection.Close();
            gedata();
        }
     }
}
