using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Inquiry : System.Web.UI.Page
{
    BALInquiry objinquirybal = new BALInquiry();
    DALInquiry objinquirydal = new DALInquiry();


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objinquirybal.CustomerID = Convert.ToInt32(Session["customerid"].ToString());
        objinquirybal.InquiryContent = txtinquirycontent.Text;
        objinquirybal.InquiryDate = System.DateTime.Now;
        objinquirydal.insertInquiry(objinquirybal);
        Response.Write("<script>alert('Your inquiry placed successful.');</script>");
        resetcontrol();
    }
    public void resetcontrol()
    {
        txtinquirycontent.Text = "";
    }
}