using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace weather
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropDownList1_OnSelectedIndexChanged(null, null);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("api.ashx?method=" + this.ddl_MethodType1.SelectedValue + "&type=location&value=" +
                              this.txt_Latitude.Text.Trim() + "," + this.txt_Longitude.Text.Trim());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("api.ashx?method=" + this.ddl_MethodType2.SelectedValue + "&type=city&value=" +this.txt_City.Text.Trim());
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("api.ashx?method=" + this.ddl_MethodType3.SelectedValue + "&type=id&value=" + this.txt_ID.Text.Trim());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("api.ashx?type=getid&value=" + this.txt_City.Text.Trim());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("api.ashx?type=getname&value=" + this.txt_ID.Text.Trim());
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("api.ashx?method="+this.DropDownList1.SelectedValue+"&type=html&value=" + this.TextBox1.Text.Trim());
        }

        protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownList1.SelectedValue.Equals("3") ||
                this.DropDownList1.SelectedValue.Equals("4") ||
                this.DropDownList1.SelectedValue.Equals("9") ||
                this.DropDownList1.SelectedValue.Equals("10") ||
                this.DropDownList1.SelectedValue.Equals("11"))
            {
                this.Label2.Text = "是";

                this.Label1.Text = "api.ashx?method=" + this.DropDownList1.SelectedValue + "&type=html&value=" +
                                   this.TextBox1.Text.Trim();
            }
            else
            {
                this.Label2.Text = "否";

                this.Label1.Text = "api.ashx?method=" + this.DropDownList1.SelectedValue + "&type=html";
            }
        }
    }
}