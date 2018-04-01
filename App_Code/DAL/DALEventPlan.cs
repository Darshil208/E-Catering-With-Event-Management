using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALEventplan
/// </summary>
public class DALEventplan
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALEventplan()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertEventPlan(BALEventPlan obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertEventPlan";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventtypeid", obj.EventTypeID);
        cmd.Parameters.AddWithValue("@eventstartdate", obj.EventStartDate);
        cmd.Parameters.AddWithValue("@totaldays", obj.TotalDays);
        cmd.Parameters.AddWithValue("@budgetamount", obj.BudgetAmount);
        cmd.Parameters.AddWithValue("@aboutplan", obj.AboutPlan);
        cmd.Parameters.AddWithValue("@customerid", obj.CustomerID);
        cmd.Parameters.AddWithValue("@createdate", obj.CreateDate);
        cmd.Parameters.AddWithValue("@planstatus", obj.PlanStatus);


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateEventPlan(BALEventPlan obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateEventPlan";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid",obj.EventPlanID);
        cmd.Parameters.AddWithValue("@eventtypeid",obj.EventTypeID);
        cmd.Parameters.AddWithValue("@eventstartdate",obj.EventStartDate);
        cmd.Parameters.AddWithValue("@totaldays",obj.TotalDays);
        cmd.Parameters.AddWithValue("@budgetamount",obj.BudgetAmount);
        cmd.Parameters.AddWithValue("@aboutplan",obj.AboutPlan);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteEventPlan(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteEventPlan";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectEventPlan()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventPlan";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectEventPlanByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventPlanByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectCurrentPendingEventPlanByCustomerID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCurrentPendingEventPlanByCustomerID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectPendingEventPlanByCustomerID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectPendingEventPlanByCustomerID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectConfirmEventPlanByCustomerID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectConfirmEventPlanByCustomerID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }



    public DataSet SelectPendingEventPlanByServiceProviderID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectPendingEventPlanByServiceProviderID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet SelectConfirmEventPlanByServiceProviderID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectConfirmEventPlanByServiceProviderID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public void updateEventStatus(BALEventPlan obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateEventStatus";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", obj.EventPlanID);
        cmd.Parameters.AddWithValue("@planstatus", obj.PlanStatus);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet gettotaleventplan()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotaleventplan";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet selectMyEventDateByEventPlanID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectMyEventDateByEventPlanID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
}
