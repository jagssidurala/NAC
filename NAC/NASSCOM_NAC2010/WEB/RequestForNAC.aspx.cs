using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NASSCOM_NAC.Web
{
    public partial class RequestForNAC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl li = new System.Web.UI.HtmlControls.HtmlGenericControl();
            li = (System.Web.UI.HtmlControls.HtmlGenericControl)this.Nac_headermenu1.FindControl("requestnac");
            li.Attributes.Add("class", "active");
        }
    }
}