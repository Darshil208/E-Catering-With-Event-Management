using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Admin_eventtype : System.Web.UI.Page
{
    BALEventType objeventtypebal = new BALEventType();
    DALEventType objeventtypedal = new DALEventType();
    public void resetconrol()
    {
        btnsubmit.Text = "Submit";
    }
    public void bindgrid()
    {
        GridView1.DataSource = objeventtypedal.selectEventType
();
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
                objeventtypedal.deleteEventType(id);
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
        objeventtypebal.EventTypeName = txteventtypename.Text;
        if (btnsubmit.Text == "Submit")
        {
            objeventtypedal.insertEventType(objeventtypebal);
            Response.Write("<script>alert('Record inseted');</script>");
        }
        else
        {
            objeventtypebal.EventTypeID = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
            objeventtypedal.updateEventType(objeventtypebal);
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
        ds = objeventtypedal.selectEventTypeByID(id);

        if (ds.Tables[0].Rows.Count > 0)
        {
      
      txteventtypename.Text = ds.Tables[0].Rows[0]["eventtypename"].ToString();
        
            btnsubmit.Text = "Update";
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[3].Text);
        objeventtypedal.deleteEventType(id);
        bindgrid();
        Response.Write("<script>alert('Record deleted');</script>");
    }
}