using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;

namespace CustomerBillApp
{
    public partial class Customerform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);
            using (SqlCommand cmd = new SqlCommand("select Existing_balance from customer.dbo.Customer_info where Customer_name='" + txtName.Text + "' ", con))
            {
                con.Open();
                txtExbl.Text = cmd.ExecuteScalar().ToString();

                using (SqlCommand cmdd = new SqlCommand("select Activation_date1 from customer.dbo.Customer_info where Customer_name='" + txtName.Text + "' ", con))
                {
                    txtaccdate.Text = cmdd.ExecuteScalar().ToString();

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime rechargedate = Convert.ToDateTime(txtrcrgdate.Text);
            DateTime acctivationdate = Convert.ToDateTime(txtaccdate.Text);
            int datediff = Convert.ToInt32(((rechargedate - acctivationdate).TotalDays));
            //int count = Convert.ToInt32(txtrcrgdate.Text) - Convert.ToInt32(txtaccdate.Text);
            if (datediff == 0)
            {
                txtcomission.Text = ("5");
                int rechargeammount = Convert.ToInt32(txtRcrhamount.Text);
                txttotbl.Text = (rechargeammount + Convert.ToInt32(txtExbl.Text) + rechargeammount * 5 / 100).ToString();

                string cs = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

                SqlConnection con = new SqlConnection(cs);
                using (SqlCommand cmd = new SqlCommand("Update customer.dbo.Customer_info set Existing_balance = '" + txttotbl.Text + "'  where Customer_name='" + txtName.Text + "' ", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            else
            {
                txtcomission.Text = ((datediff + 1) * 5).ToString();
                int rechargeammount1 = Convert.ToInt32(txtRcrhamount.Text);
                txttotbl.Text = (rechargeammount1 + Convert.ToInt32(txtExbl.Text) + ((rechargeammount1 * ((datediff + 1) * 5)) / 100)).ToString(); //Convert.ToInt32(txtExbl.Text)
                string cs = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                using (SqlCommand cmd = new SqlCommand("Update customer.dbo.Customer_info set Existing_balance = '" + txttotbl.Text + "'  where Customer_name='" + txtName.Text + "' ", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void txtrcrgdate_TextChanged(object sender, EventArgs e)
        {
            DateTime rechargedate = Convert.ToDateTime(txtrcrgdate.Text);
            DateTime acctivationdate = Convert.ToDateTime(txtaccdate.Text);
            int datediff = Convert.ToInt32(((rechargedate - acctivationdate).TotalDays));
            //int count = Convert.ToInt32(txtrcrgdate.Text) - Convert.ToInt32(txtaccdate.Text);
            if (datediff == 0)  //txtrcrgdate.Text == txtaccdate.Text
            {
                txtcomission.Text = ("5");
                int rechargeammount = Convert.ToInt32(txtRcrhamount.Text);
                txttotbl.Text = (rechargeammount + Convert.ToInt32(txtExbl.Text) + rechargeammount * 5 / 100).ToString();

                

            }
            else
            {
                txtcomission.Text = ((datediff + 1) * 5).ToString();
                int rechargeammount1 = Convert.ToInt32(txtRcrhamount.Text);
                txttotbl.Text = (rechargeammount1 + Convert.ToInt32(txtExbl.Text) + ((rechargeammount1 * ((datediff + 1) * 5)) / 100)).ToString(); //Convert.ToInt32(txtExbl.Text)
                
            }
        }
    }
}