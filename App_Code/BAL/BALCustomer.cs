using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALCustomer
/// </summary>
public class BALCustomer
{
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int CityID { get; set; }
    public string Pincode { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public DateTime Dob { get; set; }
    public int LoginID { get; set; }


	public BALCustomer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}