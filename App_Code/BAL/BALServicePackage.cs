using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALServicePackage
/// </summary>
public class BALServicePackage
{
    public int ServicePackageID { get; set; }
    public string ServicePackageName { get; set; }
    public string ServicePackageDetail { get; set; }
    public int ServicePackageAmount { get; set; }
    public string ServicePackageImage { get; set; }
    public int ServiceParoviderID { get; set; }
    
	public BALServicePackage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}