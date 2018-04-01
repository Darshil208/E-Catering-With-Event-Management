using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALFeedback
/// </summary>
public class DALFeedback
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALFeedback()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertFeedback(BALFeedback obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertFeedback";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@feedbackcontent", obj.FeedbackContent);
        cmd.Parameters.AddWithValue("@customerid", obj.CustomerID);
        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceProviderId);
        cmd.Parameters.AddWithValue("@feedbackdate", obj.FeedbackDate);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateFeedback(BALFeedback obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateFeedback";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@feedbackid",obj.FeedbackID);
        cmd.Parameters.AddWithValue("@feedbackcontent",obj.FeedbackContent);
        cmd.Parameters.AddWithValue("@customerid",obj.CustomerID);
        cmd.Parameters.AddWithValue("@serviceproviderid",obj.ServiceProviderId);
        cmd.Parameters.AddWithValue("@feedbackdate",obj.FeedbackDate);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteFeedback(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteFeedback";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@feedbackid", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectFeedback()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectFeedback";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectFeedbackByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectFeedbackByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@feedbackid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectFeedbackByServiceProviderID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectFeedbackByServiceProviderID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet gettotalfeedback()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotalfeedback";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}
