using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "NAME";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection stormconn = new SqlConnection("Server=tcp:emp1.database.windows.net,1433;Initial Catalog=emp;Persist Security Info=False;User ID=girish;Password=9980159827omgA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"))
            {
                using (SqlCommand insertCommand = new SqlCommand("Exec dbo.INSERTFNAME @FNAME", stormconn))
                {
                    insertCommand.Parameters.AddWithValue("@FNAME", TextBox1.Text);

                    stormconn.Open();
                    insertCommand.ExecuteNonQuery();
                    stormconn.Close();

                    if (Page.IsPostBack)
                    {
                        TextBox1.Text = "";
                    }
                }
            }
        }
    }
}
