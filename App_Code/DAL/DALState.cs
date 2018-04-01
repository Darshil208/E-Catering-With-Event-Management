using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



//add in all dal
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALState
/// </summary>
public class DALState
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALState()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertState(BALState obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertState";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@statename", obj.StateName);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void updateState(BALState obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateState";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@stateid",obj.StateID);
        cmd.Parameters.AddWithValue("@statename",obj.StateName);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteState(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteState";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@stateid", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();


    }
    public DataSet selectState()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectState";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;

    }
    public DataSet selectStateByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectStateByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@stateid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;


    }
}
