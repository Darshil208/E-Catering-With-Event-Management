using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add in all pages
using System.Data;

public partial class Admin_City : System.Web.UI.Page
{
    //create dal and bal object of page
    BALCity objcitybal = new BALCity();
    DALCity objcitydal = new DALCity();

    BALState objstatebal = new BALState();
    DALState objstatedal = new DALState();

    public void bindstate()
    {
        drpstateid.DataSource = objstatedal.selectState();
        drpstateid.DataTextField = "statename";
        drpstateid.DataValueField = "stateid";
        drpstateid.DataBind();
        drpstateid.Items.Insert(0, "-Select State-");
    }
    public void resetconrol()
    {
        txtcityname.Text = "";
        drpstateid.SelectedIndex = 0;
        btnsubmit.Text = "Submit";
    }
    public void bindgrid()
    {
        GridView1.DataSource = objcitydal.selectCity();
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userrole"] == null || Session["userrole"].ToString() !="Admin" || Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!IsPostBack)
        {
            bindgrid();
            bindstate();
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
                objcitydal.deleteCity(id);
                flag = true;
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
        objcitybal.CityName = txtcityname.Text;
        objcitybal.StateID = Convert.ToInt32(drpstateid.SelectedValue);

        if (btnsubmit.Text == "Submit")
        {
            objcitydal.insertCity(objcitybal);
            Response.Write("<script>alert('Record inseted');</script>");
        }
        else
        {
            objcitybal.CityID = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
            objcitydal.updateCity(objcitybal);
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
        ds = objcitydal.selectCityByID(id);

        if(ds.Tables [0].Rows.Count > 0 )
        {
            txtcityname.Text = ds.Tables [0].Rows[0]["cityname"].ToString();

            for (int i = 0; i < drpstateid.Items.Count; i++)
            {
                if (drpstateid.Items[i].Text == ds.Tables[0].Rows[0]["statename"].ToString())
                {
                    drpstateid.SelectedIndex = i;
                }
            }

                btnsubmit.Text = "Update";
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[3].Text);
        objcitydal.deleteCity(id);
        bindgrid();
        Response.Write("<script>alert('Record deleted');</script>");
    }
}