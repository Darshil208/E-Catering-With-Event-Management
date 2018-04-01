using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DALEventService
/// </summary>
public class DALEventService
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALEventService()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertEventService(BALEventService obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertEventService";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", obj.EventPlanID);
        cmd.Parameters.AddWithValue("@servicepackageid", obj.ServicePackageID);
        cmd.Parameters.AddWithValue("@servicepackagequantity", obj.ServicePackageQuantity);
        cmd.Parameters.AddWithValue("@servicepackageamount", obj.ServicePackageAmount);
        cmd.Parameters.AddWithValue("@servicepackagetotalamount", obj.ServicePackageTotalAmount);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateEventService(BALEventService obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateEventService";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventserviceid",obj.ServicePackageID);
        cmd.Parameters.AddWithValue("@eventplanid",obj.EventPlanID);
        cmd.Parameters.AddWithValue("@servicepackageid",obj.ServicePackageID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateEventServiceQuantity(BALEventService obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateEventServiceQuantity";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventserviceid", obj.EventServiceID);
        cmd.Parameters.AddWithValue("@servicepackagequantity", obj.ServicePackageQuantity);
        cmd.Parameters.AddWithValue("@servicepackageamount", obj.ServicePackageAmount);
        cmd.Parameters.AddWithValue("@servicepackagetotalamount", obj.ServicePackageTotalAmount);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void deleteEventService(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteEventService";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventserviceid", id);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectEventService()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventService";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectEventServiceByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventServiceByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventserviceid", id);


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectEventServiceByEventPlanID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventServiceByEventPlanID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", id);


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet gettotaleventservice()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotaleventservice";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}
