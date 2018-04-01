using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALEventService
/// </summary>
public class BALEventService
{
    public int EventServiceID { get; set; }
    public int EventPlanID { get; set; }
    public int ServicePackageID { get; set; }
    public int ServicePackageQuantity { get; set; }
    public int ServicePackageAmount { get; set; }
    public int ServicePackageTotalAmount { get; set; }



	public BALEventService()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}