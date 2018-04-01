using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALServiceProvider
/// </summary>
public class DALServiceProvider
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALServiceProvider()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertServiceProvider(BALServiceProvider obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertServiceProvider";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceprovidername", obj.ServiceProviderName);
        cmd.Parameters.AddWithValue("@address", obj.Address);
        cmd.Parameters.AddWithValue("@cityid", obj.CityID);
        cmd.Parameters.AddWithValue("@pincode", obj.Pincode);
        cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
        cmd.Parameters.AddWithValue("@email", obj.Email);
        cmd.Parameters.AddWithValue("@website", obj.Email);
        cmd.Parameters.AddWithValue("@aboutserviceprovider", obj.AboutServiceProvider);
        cmd.Parameters.AddWithValue("@serviceproviderimage", obj.ServiceProviderImage);
        cmd.Parameters.AddWithValue("@servicefiledetail", obj.ServiceDetailFile);
        cmd.Parameters.AddWithValue("@serviceprovidertypeid", obj.ServiceProviderTypeID);
        cmd.Parameters.AddWithValue("@loginid", obj.LoginID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateServiceProvider(BALServiceProvider obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateServiceProvider";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid",obj.ServiceProviderID);
        cmd.Parameters.AddWithValue("@serviceprovidername",obj.ServiceProviderName);
        cmd.Parameters.AddWithValue("@address",obj.Address);
        cmd.Parameters.AddWithValue("@cityid",obj.CityID);
        cmd.Parameters.AddWithValue("@pincode",obj.Pincode);
        cmd.Parameters.AddWithValue("@mobile",obj.Mobile);
        cmd.Parameters.AddWithValue("@email",obj.Email);
        cmd.Parameters.AddWithValue("@website",obj.Email);
        cmd.Parameters.AddWithValue("@aboutserviceprovider",obj.AboutServiceProvider);
        cmd.Parameters.AddWithValue("@serviceproviderimage",obj.ServiceProviderImage);
        cmd.Parameters.AddWithValue("@serviceprovidertypeid",obj.ServiceProviderTypeID);
        cmd.Parameters.AddWithValue("@loginid",obj.LoginID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }

    public void updateServiceProviderImage(BALServiceProvider obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateServiceProviderImage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceProviderID);
        cmd.Parameters.AddWithValue("@serviceproviderimage", obj.ServiceProviderImage);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }

    
    public void updateServiceProviderWithoutImage(BALServiceProvider obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateServiceProviderWithoutImage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceProviderID);
        cmd.Parameters.AddWithValue("@serviceprovidername", obj.ServiceProviderName);
        cmd.Parameters.AddWithValue("@address", obj.Address);
        cmd.Parameters.AddWithValue("@cityid", obj.CityID);
        cmd.Parameters.AddWithValue("@pincode", obj.Pincode);
        cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
        cmd.Parameters.AddWithValue("@email", obj.Email);
        cmd.Parameters.AddWithValue("@website", obj.Email);
        cmd.Parameters.AddWithValue("@aboutserviceprovider", obj.AboutServiceProvider);
        cmd.Parameters.AddWithValue("@serviceprovidertypeid", obj.ServiceProviderTypeID);
        cmd.Parameters.AddWithValue("@loginid", obj.LoginID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateServiceDetailFile(BALServiceProvider obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateServiceDetailFile";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceProviderID);
        cmd.Parameters.AddWithValue("@servicedetailfile", obj.ServiceDetailFile);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteServiceProvider(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteServiceProvider";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid",id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectServiceProvider()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServiceProvider";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectServiceProviderByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServiceProviderByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectServiceProviderByLoginID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServiceProviderByLoginID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectServiceProviderByServiceProviderTypeID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServiceProviderByServiceProviderTypeID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceprovidertypeid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet gettotalserviceprovider()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotalserviceprovider";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet CheckServiceProviderAvailability(int eid, int spid)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spCheckServiceProviderAvailability";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", eid);
        cmd.Parameters.AddWithValue("@servicepackageid", spid);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}