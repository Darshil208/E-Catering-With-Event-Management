using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALFeedback
/// </summary>
public class BALFeedback
{
    public int FeedbackID { get; set; }
    public string FeedbackContent { get; set; }
    public int CustomerID { get; set; }
    public int ServiceProviderId { get; set; }
    public DateTime FeedbackDate { get; set; }
   
	public BALFeedback()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}