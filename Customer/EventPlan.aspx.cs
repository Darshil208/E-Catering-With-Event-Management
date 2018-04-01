using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
public partial class Customer_EventPlan : System.Web.UI.Page
{
    BALEventPlan objeventplanbal = new BALEventPlan();
    DALEventplan objeventplandal = new DALEventplan();

    BALServiceProviderType objserviceprovidertypebal = new BALServiceProviderType();
    DALServiceProviderType objserviceprovidertypedal = new DALServiceProviderType();

    BALEventService objeventservicebal = new BALEventService();
    DALEventService objeventservicedal = new DALEventService();

    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    public void bindserviceprovidertype()
    {
        DataList2.DataSource = objserviceprovidertypedal.selectServiceProviderType();
        DataList2.DataBind();
    }

    public void bindcurrentconfirmevent()
    {
        DataSet ds = new DataSet();

        if (Request.QueryString["epid"] != null)
        {
            ds = objeventplandal.selectEventPlanByID(Convert.ToInt32(Request.QueryString["epid"].ToString()));
            Session["eventplanid"] = ds.Tables[0].Rows[0]["eventplanid"].ToString();
        }
        else if(Session["eventplanid"]!=null)
        {
            ds = objeventplandal.selectEventPlanByID(Convert.ToInt32(Session["eventplanid"].ToString()));
        }
        else
        {
            ds = objeventplandal.selectCurrentPendingEventPlanByCustomerID(Convert.ToInt32(Session["customerid"].ToString()));
            Session["eventplanid"] = ds.Tables[0].Rows[0]["eventplanid"].ToString();
        }
        DataList1.DataSource = ds;
        DataList1.DataBind();

        if(ds.Tables [0].Rows[0]["PlanStatus"].ToString () == "Pending")
        {
            confirmdisplay.Style.Add("display", "block");
        }
        else
        {
            confirmdisplay.Style.Add("display", "none");
        }

        ViewState["eventbudget"] = ds.Tables[0].Rows[0]["budgetamount"].ToString();
    }
    public void bindeventservice()
    {
        int total = 0;
        int budgetamount = 0;
        DataSet dseventservice = new DataSet();
        dseventservice = objeventservicedal.selectEventServiceByEventPlanID(Convert.ToInt32(Session["eventplanid"]));

        lteventservice.Text = "";
        ltservicepackagetotal.Text = "";
        
        if(dseventservice.Tables[0].Rows.Count > 0 )
        {
            lteventservice.Text = "<h2 class='title2'>Event Service Package</h2>";
        
            GridView1.DataSource = dseventservice;
            GridView1.DataBind();
            
            budgetamount = Convert.ToInt32(ViewState["eventbudget"].ToString());

            for(int i=0;i<dseventservice.Tables[0].Rows.Count ;i++)
            {
                total += Convert.ToInt32(dseventservice.Tables[0].Rows[i]["servicepackagetotalamount"]);
            }

            if (budgetamount < total)
            {
                ltservicepackagetotal.Text += "<table style='color:red;' class='datatable'>";
            }
            else
            {
                ltservicepackagetotal.Text += "<table style='color:green;' class='datatable'>";
            }
            ltservicepackagetotal.Text += "<tr>";
            ltservicepackagetotal.Text += "<td><p style='font-size:18px;'>Budget Amount: </p></td>";
            ltservicepackagetotal.Text += "<td style='font-size:18px; text-align:right; width:20%;'>" + budgetamount.ToString() + "/- Rs.</td>";
            ltservicepackagetotal.Text += "</tr>";
            ltservicepackagetotal.Text += "<tr>";
            ltservicepackagetotal.Text += "<td><p style='font-size:18px;'>Package Amount:</p></td>";
            ltservicepackagetotal.Text += "<td style='font-size:18px; text-align:right; width:20%;'>" + total.ToString() + "/- Rs.</td>";
            ltservicepackagetotal.Text += "</tr>";
            ltservicepackagetotal.Text += "</table>";
            
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["eventbudget"] = 0;
            bindcurrentconfirmevent();
            bindserviceprovidertype();
            bindeventservice();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[2].Text);
        objeventservicedal.deleteEventService(id);
        bindeventservice();
        Response.Write("<script>alert('You have delete one service from event plan.');</script>");
    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        objeventplanbal.EventPlanID = Convert.ToInt32(Session["eventplanid"].ToString ());
        objeventplanbal.PlanStatus = "Confirm";
        objeventplandal.updateEventStatus(objeventplanbal);
        bindcurrentconfirmevent();
        bindeventservice();

        DataSet dsevent = new DataSet();
        dsevent = objeventplandal.selectEventPlanByID(Convert.ToInt32(Session["eventplanid"].ToString()));

        DataSet dseventservice = new DataSet();
        dseventservice = objeventservicedal.selectEventServiceByEventPlanID(Convert.ToInt32(Session["eventplanid"]));

        int total = 0;

        if (dseventservice.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dseventservice.Tables[0].Rows.Count; i++)
            {
                total += Convert.ToInt32(dseventservice.Tables[0].Rows[i]["servicepackagetotalamount"]);
            }
        }


        try
        {
            string smtpAddress = "smtp.mail.yahoo.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "page1event@yahoo.com";
            string password = "Page1234";
            string emailTo = Session["email"].ToString ();
            string subject = "E-Catering Event: Event confirmation";
            string body = "You have created and confirmed one event with E-Categring Event Management System";
            body += "<br/>";
            body += "<b>Plan Detail</b>";
            body += "<br/>";
            body += dsevent.Tables[0].Rows[0]["eventstartdate"].ToString ();
            body += "<br/>";
            body += dsevent.Tables[0].Rows[0]["totaldays"].ToString();
            body += "<br/>";
            body += dsevent.Tables[0].Rows[0]["aboutplan"].ToString();
            body += "<br/>";
            body += dsevent.Tables[0].Rows[0]["createdate"].ToString();
            body += "<br/>";
            body += dsevent.Tables[0].Rows[0]["eventtypename"].ToString();
            body += "<br/>";
            body += "<b>Plan Service Detail</b>";
            body += "<br/>";
            if (dseventservice.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dseventservice.Tables[0].Rows.Count; i++)
                {
                    body += "<table>";

                    body += "<tr>";
                    body += "<td>";
                    body += dseventservice.Tables[0].Rows[0]["servicepackagename"].ToString();
                    body += "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<td>";
                    body += dseventservice.Tables[0].Rows[0]["servicepackagedetail"].ToString();
                    body += "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<td>";
                    body += dseventservice.Tables[0].Rows[0]["servicepackageamount"].ToString();
                    body += "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<td>";
                    body += dseventservice.Tables[0].Rows[0]["servicepackagequantity"].ToString();
                    body += "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<td>";
                    body += dseventservice.Tables[0].Rows[0]["servicepackageamount"].ToString();
                    body += "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<td>";
                    body += dseventservice.Tables[0].Rows[0]["servicepackagetotalamount"].ToString();
                    body += "</td>";
                    body += "</tr>";
                    
                    body += "</table>";
                }
            }
            body += "<b>Amount Detail</b>";
            body += dsevent.Tables[0].Rows[0]["budgetamount"].ToString();
            body += "Total Amont:"+total;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

        if (dseventservice.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dseventservice.Tables[0].Rows.Count; i++)
            {
                try
                {
                    string smtpAddress = "smtp.mail.yahoo.com";
                    int portNumber = 587;
                    bool enableSSL = true;

                    string emailFrom = "page1event@yahoo.com";
                    string password = "Page1234";
                    string emailTo = dseventservice.Tables[0].Rows[0]["email"].ToString ();
                    string subject = "E-Catering Event: Your booking";
                    string body = "You have booked by a customer for an event.<br/>Please check your account for further detail.";
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = false;
                        // Can set to false, if you are sending pure text.

                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindeventservice();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        TextBox txtqty = new TextBox();
        txtqty = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");

        objeventservicebal.EventServiceID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[2].Text);
        objeventservicebal.ServicePackageQuantity = Convert.ToInt32 (txtqty.Text);
        objeventservicebal.ServicePackageAmount = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[6].Text);
        objeventservicebal.ServicePackageTotalAmount = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[6].Text) * Convert.ToInt32(txtqty.Text);

        objeventservicedal.updateEventServiceQuantity(objeventservicebal);

        GridView1.EditIndex = -1;
        bindeventservice();
        Response.Write("<script>alert('Package Quantity Updated');</script>");
        Response.Write(txtqty.Text);
        Response.Write(objeventservicebal.EventServiceID.ToString () + ":");
        Response.Write(objeventservicebal.ServicePackageAmount.ToString () + ":");
        Response.Write(objeventservicebal.ServicePackageTotalAmount.ToString ());
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindeventservice();
    }
}