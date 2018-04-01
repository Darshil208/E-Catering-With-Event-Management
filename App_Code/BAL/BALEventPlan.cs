using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALEventPlan
/// </summary>
/// 


public class BALEventPlan
{
    public int EventPlanID { get; set; }
    public int EventTypeID { get; set; }
    public DateTime EventStartDate { get; set; }
    public int TotalDays { get; set; }
    public int BudgetAmount { get; set; }
    public string AboutPlan { get; set; }
    public DateTime CreateDate { get; set;}
    public int CustomerID { get; set; }

    public string PlanStatus { get; set; }

	public BALEventPlan()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}