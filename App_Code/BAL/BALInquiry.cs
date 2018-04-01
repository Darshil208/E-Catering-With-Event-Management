using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALInquiry
/// </summary>
public class BALInquiry
{
    public int inquiryID { get; set; }
    public int CustomerID { get; set; }
    public string InquiryContent { get; set; }
    public DateTime InquiryDate { get; set; }
	public BALInquiry()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}