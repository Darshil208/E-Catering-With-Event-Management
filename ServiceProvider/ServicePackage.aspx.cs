using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add in all pages
using System.Data;

public partial class ServiceProvider_ServicePackage : System.Web.UI.Page
{
    BALServicePackage objservicepackagebal = new BALServicePackage();
    DALServicepackage objservicepackagedal = new DALServicepackage();

    public void resetconrol()
    {
        txtservicepackageamount.Text = "";
        CKEditor1.Text = "";
        //txtservicepackagedetail.Text = "";
        txtservicepackagename.Text = "";
        btnsubmit.Text = "Submit";
    }
    public void bindgrid()
    {
        GridView1.DataSource = objservicepackagedal.selectServicePackageByProviderID(Convert.ToInt32(Session["serviceproviderid"].ToString()));
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userrole"] == null || Session["userrole"].ToString() != "ServiceProvider")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        CheckBox cb = new CheckBox();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

            if (!cb.Checked)
            {
                cb.Checked = true;
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        CheckBox cb = new CheckBox();
        bool flag = false;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

            if (cb.Checked)
            {
                int id = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                objservicepackagedal.deleteServicepackage(id);
                flag = false;
            }
        }
        if (flag)
        {
            bindgrid();
            Response.Write("<script>alert('Record deleted');</script>");
        }
        else
        {
            Response.Write("<script>alert('Please select record to delete');</script>");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string filename;
        string filepath;

        objservicepackagebal.ServicePackageName = txtservicepackagename.Text;
        objservicepackagebal.ServicePackageDetail = CKEditor1.Text;
        objservicepackagebal.ServicePackageAmount = Convert.ToInt32 (txtservicepackageamount.Text);
        objservicepackagebal.ServiceParoviderID = Convert.ToInt32(Session["serviceproviderid"].ToString());

        if (btnsubmit.Text == "Submit")
        {
            if (fuservicepackageimage.HasFile)
            {
                filename = fuservicepackageimage.FileName;
                filepath = Server.MapPath("../images/ServicePackage/");

                fuservicepackageimage.SaveAs(filepath + filename);

                objservicepackagebal.ServicePackageImage = filename;
                objservicepackagedal.insertServicePackage(objservicepackagebal);
                Response.Write("<script>alert('Record inseted');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please select image');</script>");
            }
        }
        else
        {
            objservicepackagebal.ServicePackageID= Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
            if (fuservicepackageimage.HasFile)
            {
                filename = fuservicepackageimage.FileName;
                filepath = Server.MapPath("../images/ServicePackage/");

                fuservicepackageimage.SaveAs(filepath + filename);

                objservicepackagebal.ServicePackageImage = filename;
                objservicepackagedal.updateServicePackage(objservicepackagebal);
                Response.Write("<script>alert('Record updated');</script>");
            }
            else
            {
                objservicepackagedal.updateServicePackageWithoutImage(objservicepackagebal);
                Response.Write("<script>alert('Record updated');</script>");
            }

        }
        bindgrid();
        resetconrol();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        resetconrol();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        resetconrol();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);

        DataSet ds = new DataSet();
        ds = objservicepackagedal.selectServicePackageByID(id);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtservicepackageamount.Text = ds.Tables[0].Rows[0]["servicepackageamount"].ToString();
            CKEditor1.Text = ds.Tables[0].Rows[0]["servicepackagedetail"].ToString();
            txtservicepackagename.Text = ds.Tables[0].Rows[0]["servicepackagename"].ToString();

            btnsubmit.Text = "Update";
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[3].Text);
        objservicepackagedal.deleteServicepackage(id);
        bindgrid();
        Response.Write("<script>alert('Record deleted');</script>");
    }
}