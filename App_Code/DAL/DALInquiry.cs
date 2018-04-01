using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALInquiry
/// </summary>
public class DALInquiry
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALInquiry()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertInquiry(BALInquiry obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertInquiry";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@customerid", obj.CustomerID);
        cmd.Parameters.AddWithValue("@inquirycontent", obj.InquiryContent);
        cmd.Parameters.AddWithValue("@inquirydate", obj.InquiryDate);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateInquiry(BALInquiry obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateInquiry";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@inquiryid",obj.inquiryID);
        cmd.Parameters.AddWithValue("@customerid",obj.CustomerID);
        cmd.Parameters.AddWithValue("@inquirycontent",obj.InquiryContent);
        cmd.Parameters.AddWithValue("@inquirydate",obj.InquiryDate);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteInquiry(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteInquiry";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@inquiryid",id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectInquiry()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectInquiry";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectInquiryID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectInquiryID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@inquiryid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }

    public DataSet gettotalinquiry()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotalinquiry";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}