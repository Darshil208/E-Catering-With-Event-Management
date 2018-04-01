using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALLogin
/// </summary>
public class DALLogin
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALLogin()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertLogin(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertLogin";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@username", obj.UserName);
        cmd.Parameters.AddWithValue("@password", obj.Password);
        cmd.Parameters.AddWithValue("@securityquestion", obj.SecurityQuestion);
        cmd.Parameters.AddWithValue("@secureanswer", obj.SecureAnswer);
        cmd.Parameters.AddWithValue("@userrole", obj.UserRole);
        cmd.Parameters.AddWithValue("@createdate", obj.CreateDate);
        cmd.Parameters.AddWithValue("@accountstatus", obj.AccountStatus);


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateLogin(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateLogin";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid",obj.LoginID);
        cmd.Parameters.AddWithValue("@username",obj.UserName);
        //cmd.Parameters.AddWithValue("@password",obj.Password);
        cmd.Parameters.AddWithValue("@securityquestion",obj.SecurityQuestion);
        cmd.Parameters.AddWithValue("@secureanswer",obj.SecureAnswer);
        //cmd.Parameters.AddWithValue("@userrole",obj.UserRole);
        //cmd.Parameters.AddWithValue("@createdate",obj.CreateDate);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateLoginWithPassword(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateLoginWithPassword";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid", obj.LoginID);
        cmd.Parameters.AddWithValue("@username", obj.UserName);
        cmd.Parameters.AddWithValue("@password",obj.Password);
        cmd.Parameters.AddWithValue("@securityquestion", obj.SecurityQuestion);
        cmd.Parameters.AddWithValue("@secureanswer", obj.SecureAnswer);
        cmd.Parameters.AddWithValue("@userrole",obj.UserRole);
        cmd.Parameters.AddWithValue("@createdate",obj.CreateDate);
        cmd.Parameters.AddWithValue("@accountstatus", obj.AccountStatus);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateLoginWithoutPassword(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateLoginWithoutPassword";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid", obj.LoginID);
        cmd.Parameters.AddWithValue("@username", obj.UserName);
        cmd.Parameters.AddWithValue("@securityquestion", obj.SecurityQuestion);
        cmd.Parameters.AddWithValue("@secureanswer", obj.SecureAnswer);
        cmd.Parameters.AddWithValue("@userrole", obj.UserRole);
        cmd.Parameters.AddWithValue("@createdate", obj.CreateDate);
        cmd.Parameters.AddWithValue("@accountstatus", obj.AccountStatus);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateAccountStatusByLoginID(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateAccountStatusByLoginID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid", obj.LoginID);
        cmd.Parameters.AddWithValue("@accountstatus",obj.AccountStatus);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateAccountStatusByCustomerID(int id,string status)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateAccountStatusByCustomerID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", id);
        cmd.Parameters.AddWithValue("@accountstatus", status);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateAccountStatusByServiceProviderID(int id, string status)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateAccountStatusByServiceProviderID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);
        cmd.Parameters.AddWithValue("@accountstatus", status);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
        public void changePassword(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spChangePassword";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@username",obj.UserName);
        cmd.Parameters.AddWithValue("@password",obj.Password);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteLogin(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteLogin";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid",id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectLogin()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectLogin";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectLoginByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectLoginByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }

    public DataSet validateLogin(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "validateLogin";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@username", obj.UserName);
        cmd.Parameters.AddWithValue("@password", obj.Password);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet getMaxLoginID()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spGetMaxLoginID";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet  selectLoginByUserRole(string role)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectLoginByUserRole";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@userrole", role);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectUserLogin()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectUserLogin";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet getSecurityByUserName(string username)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spGetSecurityByUserName";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@username", username);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet retrievePassword(BALLogin obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spRetrievePassword";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@username", obj.UserName);
        cmd.Parameters.AddWithValue("@securityquestion", obj.SecurityQuestion);
        cmd.Parameters.AddWithValue("@secureanswer", obj.SecureAnswer);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}