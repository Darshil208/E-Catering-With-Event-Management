
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
public class DALImageGallery
{
    //add in all dal
    string constring;
    SqlConnection con;

    public DALImageGallery()
    {
        //add in all dal
        constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbECateringEvent.mdf;Integrated Security=True";
        con = new SqlConnection(constring);
    }

    public void insertImage(BALImageGallery obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spInsertImage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@imagefilename", obj.ImageFileName);
        cmd.Parameters.AddWithValue("@serviceproviderid", obj.ServiceProviderID);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void deleteImage(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spDeleteImage";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@imageid", id);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataSet selectImageByServiceProviderID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "spSelectImageByServiceProviderID";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceproviderid", id);

        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(ds);
        return ds;
    }
}