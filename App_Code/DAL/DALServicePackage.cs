using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALServicepackage
/// </summary>
public class DALServicepackage
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALServicepackage()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertServicePackage(BALServicePackage obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertServicePackage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@servicepackagename", obj.ServicePackageName);
        cmd.Parameters.AddWithValue("@servicepackagedetail", obj.ServicePackageDetail);
        cmd.Parameters.AddWithValue("@servicepackageamount", obj.ServicePackageAmount);
        cmd.Parameters.AddWithValue("@servicepackageimage", obj.ServicePackageImage);
        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceParoviderID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateServicePackage(BALServicePackage obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateServicePackage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@servicepackageid",obj.ServicePackageID);
        cmd.Parameters.AddWithValue("@servicepackagename",obj.ServicePackageName);
        cmd.Parameters.AddWithValue("@servicepackagedetail",obj.ServicePackageDetail);
        cmd.Parameters.AddWithValue("@servicepackageamount",obj.ServicePackageAmount);
        cmd.Parameters.AddWithValue("@servicepackageimage",obj.ServicePackageImage);
        cmd.Parameters.AddWithValue("@serviceproviderid",obj.ServiceParoviderID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateServicePackageWithoutImage(BALServicePackage obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateServicePackageWithoutImage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@servicepackageid", obj.ServicePackageID);
        cmd.Parameters.AddWithValue("@servicepackagename", obj.ServicePackageName);
        cmd.Parameters.AddWithValue("@servicepackagedetail", obj.ServicePackageDetail);
        cmd.Parameters.AddWithValue("@servicepackageamount", obj.ServicePackageAmount);
        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceParoviderID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteServicepackage(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteServicepackage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@servicepackageid",id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectServicepackage()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServicepackage";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;


    }
    public DataSet selectServicePackageByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServicePackageByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@servicepackageid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectServicePackageByProviderID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServicePackageByProviderID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }

    public DataSet selectServicePackageByProviderTypeID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectServicePackageByProviderTypeID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceprovidertypeid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet gettotalservicepackage()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotalservicepackage";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}