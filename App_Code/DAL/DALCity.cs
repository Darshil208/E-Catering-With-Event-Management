
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//add in all dal
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALCity
/// </summary>
public class DALCity
{
    //add in all dal
    string constring;
    SqlConnection con;

	public DALCity()
	{
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
	}

    public void insertCity(BALCity obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertCity";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cityname", obj.CityName);
        cmd.Parameters.AddWithValue("@stateid", obj.StateID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void updateCity(BALCity obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spUpdateCity";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cityid",obj.CityID);
        cmd.Parameters.AddWithValue("@cityname",obj.CityName);
        cmd.Parameters.AddWithValue("@stateid",obj.StateID);


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

    }
    public void deleteCity(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteCity";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cityid",id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataSet selectCity()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCity";
        cmd.CommandType = CommandType.StoredProcedure;


        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectCityByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCityByID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@cityid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
    public DataSet selectCityByStateID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectCityByStateID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@stateid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}
