using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Admin_servicepackage : System.Web.UI.Page
{
    BALServicePackage objservicepackagebal = new BALServicePackage();
    DALServicepackage objservicepackagedal = new DALServicepackage();

    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    BALServiceProviderType objserviceprovidertypebal = new BALServiceProviderType();
    DALServiceProviderType objserviceprovidertypedal = new DALServiceProviderType();

    public void bindserviceprovider()
    {
        drpserviceparoviderid.DataSource = objserviceproviderdal.selectServiceProvider();
        drpserviceparoviderid.DataTextField = "serviceprovidername";
        drpserviceparoviderid.DataValueField = "serviceproviderid";
        drpserviceparoviderid.DataBind();
        drpserviceparoviderid.Items.Insert(0, "-Select Service Provider-");
    }
    public void resetconrol()
    {
        btnsubmit.Text = "Submit";
    }
    public void bindgrid()
    {
        GridView1.DataSource = objservicepackagedal.selectServicepackage();
        GridView1.DataBind();
    }
    public void bindgridbyserviceprovider(int id)
    {
        GridView1.DataSource = objservicepackagedal.selectServicePackageByProviderID(id);
        GridView1.DataBind();
    }
    public void bindgridbyserviceprovidertype(int id)
    {
        GridView1.DataSource = objservicepackagedal.selectServicePackageByProviderTypeID(id);
        GridView1.DataBind();
    }
    public void bindfilterserviceprovidertype()
    {
        drpfilterserviceprovidertype.DataSource = objserviceprovidertypedal.selectServiceProviderType();
        drpfilterserviceprovidertype.DataTextField = "serviceprovidertype";
        drpfilterserviceprovidertype.DataValueField = "serviceprovidertypeid";
        drpfilterserviceprovidertype.DataBind();
        drpfilterserviceprovidertype.Items.Insert(0, "-Select Service Provider Type-");
    }
    public void bindfilterserviceprovider(int id)
    {
        drpfilterserviceprovider.DataSource = objserviceproviderdal.selectServiceProviderByServiceProviderTypeID(id);
        drpfilterserviceprovider.DataTextField = "serviceprovidername";
        drpfilterserviceprovider.DataValueField = "serviceproviderid";
        drpfilterserviceprovider.DataBind();
        drpfilterserviceprovider.Items.Insert(0, "-Select Service Provider-");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userrole"] == null || Session["userrole"].ToString() != "Admin" || Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!IsPostBack)
        {
            bindgrid();
            bindserviceprovider();
            bindfilterserviceprovidertype();
            drpfilterserviceprovider.Items.Insert(0, "-Select Service Provider-");
//            bindfilterserviceprovidertype();
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
        objservicepackagebal.ServicePackageName = txtservicepackagename.Text;
        objservicepackagebal.ServicePackageDetail = txtservicepackagedetail.Text;
        objservicepackagebal.ServicePackageAmount = Convert.ToInt32(txtservicepackageamount.Text);
        objservicepackagebal.ServiceParoviderID = Convert.ToInt32(drpserviceparoviderid.SelectedValue);

        string filename;
        string filepath;


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
            objservicepackagebal.ServicePackageID = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
            objservicepackagedal.updateServicePackage(objservicepackagebal);
            Response.Write("<script>alert('Record updated');</script>");
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
            txtservicepackagedetail.Text = ds.Tables[0].Rows[0]["servicepackagedetail"].ToString();
            txtservicepackagename.Text = ds.Tables[0].Rows[0]["servicepackagename"].ToString();

            for (int i = 0; i < drpserviceparoviderid.Items.Count; i++)
            {
                if (drpserviceparoviderid.Items[i].Text == ds.Tables[0].Rows[0]["serviceprovidername"].ToString())
                {
                    drpserviceparoviderid.SelectedIndex = i;
                }

            }


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
    protected void btnfilter_Click(object sender, EventArgs e)
    {
        if (drpfilterserviceprovider.SelectedIndex != 0)
        {
            bindgridbyserviceprovider(Convert.ToInt32(drpfilterserviceprovider.SelectedValue));
        }
        else if(drpfilterserviceprovidertype.SelectedIndex!=0)
        {
            bindgridbyserviceprovidertype(Convert.ToInt32(drpfilterserviceprovidertype.SelectedValue));
        }
        else
        {
            Response.Write("<script>alert('Select filter detail');</script>");
        }
    }
    protected void drpfilterserviceprovidertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindfilterserviceprovider(Convert.ToInt32(drpfilterserviceprovidertype.SelectedValue));
    }
}