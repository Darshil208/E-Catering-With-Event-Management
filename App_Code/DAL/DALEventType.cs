using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALEventType
/// </summary>
public class DALEventType
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALEventType()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertEventType(BALEventType obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertEventType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventtypename", obj.EventTypeName);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateEventType(BALEventType obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateEventType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventtypeid",obj.EventTypeID);
        cmd.Parameters.AddWithValue("@eventtypename",obj.EventTypeName);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteEventType(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteEventType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventtypeid", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public DataSet selectEventType()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventType";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectEventTypeByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectEventTypeByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@eventtypeid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet gettotaleventtype()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spgettotaleventtype";
        cmd.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}
