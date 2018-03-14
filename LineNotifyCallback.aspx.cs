using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LineNotifyCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //callback頁面取回code
            string code = Request.QueryString["code"].ToString();
            if (!string.IsNullOrEmpty(code) && string.IsNullOrEmpty(this.TextBox1.Text))
            {
                //用code換Token
                var ret = isRock.LineNotify.Utility.GetToeknFromCode(
                    code, "uDxoIBod0LePU0UHI82MqR", //ClientID一定要100%對
                    "9meXMWULRIzVa7TWYJbG2FQHEHXlqQnxNxEW0Rcx06E", //ClientSecret 一定要100%對
                    "https://lineage0314.herokuapp.com/LineNotifyCallback.aspx" //Callback url一定要100%對
                    );
                this.TextBox1.Text = ret.access_token;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //發送訊息
            isRock.LineNotify.Utility.SendNotify(this.TextBox1.Text, "test" + DateTime.Now.ToString());
        }
    }
}
