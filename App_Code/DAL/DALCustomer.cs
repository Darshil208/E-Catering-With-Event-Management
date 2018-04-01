using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALCustomer
/// </summary>
public class DALCustomer
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALCustomer()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertCustomer(BALCustomer obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertCustomer";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@firstname", obj.FirstName);
        cmd.Parameters.AddWithValue("@lastname", obj.LastName);
        cmd.Parameters.AddWithValue("@address", obj.Address);
        cmd.Parameters.AddWithValue("@cityid", obj.CityID);
        cmd.Parameters.AddWithValue("@pincode", obj.Pincode);
        cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
        cmd.Parameters.AddWithValue("@email", obj.Email);
        cmd.Parameters.AddWithValue("@gender", obj.Gender);
        cmd.Parameters.AddWithValue("@dob", obj.Dob);
        cmd.Parameters.AddWithValue("@loginid", obj.LoginID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateCustomer(BALCustomer obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateCustomer";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid",obj.CustomerID);
        cmd.Parameters.AddWithValue("@firstname",obj.FirstName);
        cmd.Parameters.AddWithValue("@lastname",obj.LastName);
        cmd.Parameters.AddWithValue("@address",obj.Address);
        cmd.Parameters.AddWithValue("@cityid",obj.CityID);
        cmd.Parameters.AddWithValue("@pincode",obj.Pincode);
        cmd.Parameters.AddWithValue("@mobile",obj.Mobile);
        cmd.Parameters.AddWithValue("@email",obj.Email);
        cmd.Parameters.AddWithValue("@gender",obj.Gender);
        cmd.Parameters.AddWithValue("@dob",obj.Dob);
        cmd.Parameters.AddWithValue("@loginid",obj.LoginID);


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void deleteCustomer(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteCustomer";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataSet selectCustomer()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCustomer";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectCustomerByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCustomerByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet selectCustomerByLoginID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCustomerByLoginID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@loginid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet selectCustomerByEventPlanID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCustomerByEventPlanID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventplanid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }

    public DataSet gettotalcustomer()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotalcustomer";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}
