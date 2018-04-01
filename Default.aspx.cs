using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////are required fields filled in:
        //if (textboxRecipient.Text == "")
        //{
        //    textboxError.Text += "Recipient(s) field must not be empty!\n";
        //    textboxError.Visible = true;
        //    return;
        //}

        //we creating the necessary URL string:
        string ozSURL = "http://127.0.0.1"; //where Ozeki NG SMS Gateway is running
        string ozSPort = "9501"; //port number where Ozeki NG SMS Gateway is listening
        string ozUser = HttpUtility.UrlEncode("admin"); //username for successful login
        string ozPassw = HttpUtility.UrlEncode("abc123"); //user's password
        string ozMessageType = "SMS:TEXT"; //type of message
        string ozRecipients = HttpUtility.UrlEncode("+919998633114"); //who will get the message
        string ozMessageData = HttpUtility.UrlEncode("Test Message"); //body of message

        string createdURL = ozSURL + ":" + ozSPort + "/httpapi" +
            "?action=sendMessage" +
            "&username=" + ozUser +
            "&password=" + ozPassw +
            "&messageType=" + ozMessageType +
            "&recipient=" + ozRecipients +
            "&messageData=" + ozMessageData;

        try
        {
            //Create the request and send data to Ozeki NG SMS Gateway Server by HTTP connection
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(createdURL);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();

            //inform the user
            //textboxError.Text = responseString;
            //textboxError.Visible = true;
        }
        catch (Exception)
        {
            //if sending request or getting response is not successful Ozeki NG SMS Gateway Server may do not run
            //textboxError.Text = "Ozeki NG SMS Gateway Server is not running!";
            //textboxError.Visible = true;
        }
    }
}