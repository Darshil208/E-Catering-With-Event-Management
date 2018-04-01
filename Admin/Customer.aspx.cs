using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
public partial class Admin_Customer : System.Web.UI.Page
{
    BALCustomer objcubsomerbal = new BALCustomer();
    DALCustomer objcustomerdal = new DALCustomer();

    BALCity objcitybal = new BALCity();
    DALCity objcitydal = new DALCity();

    BALState objstatebal = new BALState();
    DALState objstatedal = new DALState();

    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();
    public void resetconrol()
    {
        btnsubmit.Text = "Submit";
    }
    public void bindstate()
    {
        drpstate.DataSource = objstatedal.selectState();
        drpstate.DataTextField = "statename";
        drpstate.DataValueField = "stateid";
        drpstate.DataBind();
        drpstate.Items.Insert(0, "-Select State-");
    }
    public void bindcity(int id)
    {
        drpcity.DataSource = objcitydal.selectCityByStateID(id);
        drpcity.DataTextField = "cityname";
        drpcity.DataValueField = "cityid";
        drpcity.DataBind();
        drpcity.Items.Insert(0, "-Select City-");
    }
    public void bindlogin()
    {
        drploginid.DataSource = objlogindal.selectLogin();
        drploginid.DataTextField = "username";
        drploginid.DataValueField = "loginid";
        drploginid.DataBind();
        drploginid.Items.Insert(0, "-Select UserName-");
    }
    public void bindgrid()
    {
        GridView1.DataSource = objcustomerdal.selectCustomer();
        GridView1.DataBind();
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
            bindstate();
            bindlogin();
            drpcity.Items.Insert(0, "-Select City-");
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
                objcustomerdal.deleteCustomer(id);
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
        objcubsomerbal.FirstName = txtfirstname.Text;
        objcubsomerbal.LastName = txtlastname.Text;
        objcubsomerbal.Address = txtaddress.Text;
        objcubsomerbal.CityID = Convert.ToInt32(drpcity.SelectedValue);
        objcubsomerbal.Pincode = txtpincode.Text;
        objcubsomerbal.Mobile = txtmobile.Text;
        objcubsomerbal.Email = txtemail.Text;
        objcubsomerbal.Gender = drpgender.SelectedValue;
        objcubsomerbal.Dob = Convert.ToDateTime(txtdob.Text);
        objcubsomerbal.LoginID = Convert.ToInt32(drploginid.SelectedValue);

        if (btnsubmit.Text == "Submit")
        {
            objcustomerdal.insertCustomer(objcubsomerbal);
            Response.Write("<script>alert('Record inseted');</script>");
        }
        else
        {
            objcubsomerbal.CustomerID = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
            objcustomerdal.updateCustomer(objcubsomerbal);
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
        ds =objcustomerdal.selectCustomerByID(id);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtaddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            txtfirstname.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
            txtlastname.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
            txtdob.Text = Convert.ToDateTime( ds.Tables[0].Rows[0]["dob"].ToString()).ToString ("yyyy-MM-dd");
            txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtpincode.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();

            for (int i = 0; i < drpstate.Items.Count; i++)
            {
                if (drpstate.Items[i].Text == ds.Tables[0].Rows[0]["statename"].ToString())
                {
                    drpstate.SelectedIndex = i;
                }
            }

            bindcity(Convert.ToInt32(drpstate.SelectedValue));

            for (int i = 0; i < drpcity.Items.Count; i++)
            {
                if (drpcity.Items[i].Text == ds.Tables[0].Rows[0]["cityname"].ToString())
                {
                    drpcity.SelectedIndex = i;
                }
            }

            for (int i = 0; i < drpgender.Items.Count; i++)
            {
                if (drpgender.Items[i].Text == ds.Tables[0].Rows[0]["gender"].ToString())
                {
                    drpgender.SelectedIndex = i;
                }
            }
            for (int i = 0; i < drploginid.Items.Count; i++)
            {
                if (drploginid.Items[i].Text == ds.Tables[0].Rows[0]["username"].ToString())
                {
                    drploginid.SelectedIndex = i;
                }
            }


                btnsubmit.Text = "Update";
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[3].Text);
        objcustomerdal.deleteCustomer(id);
        bindgrid();
        Response.Write("<script>alert('Record deleted');</script>");
    }
    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(drpstate.SelectedValue));
    }
}