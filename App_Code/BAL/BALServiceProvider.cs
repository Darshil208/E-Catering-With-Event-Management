using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALServiceProvider
/// </summary>
public class BALServiceProvider
{
    public int ServiceProviderID { get; set; }
    public string ServiceProviderName { get; set; }
    public string Address { get; set; }
    public int CityID { get; set; }
    public string Pincode { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string AboutServiceProvider { get; set; }
    public string ServiceProviderImage { get; set; }
    public int ServiceProviderTypeID { get; set; }
    public int LoginID { get; set; }
    public string ServiceDetailFile { get; set; }
	public BALServiceProvider()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}