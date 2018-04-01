using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BALLogin
/// </summary>
public class BALLogin
{
    public int LoginID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string SecurityQuestion { get; set; }
    public string SecureAnswer { get; set; }
    public string UserRole { get; set; }
    public DateTime CreateDate { get; set; }
    public string AccountStatus { get; set; }
	public BALLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}