<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Customer_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Customer Profile</h2>
    <table>
        <tr>
            <td>First Name:</td>
            <td><asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name:</td>
            <td><asp:TextBox ID="txtlastname"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Address:</td>
            <td><asp:TextBox ID="txtaddress" Rows="4" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>State:</td>
            <td>
                <asp:DropDownList ID="drpstate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpstate_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>City:</td>
            <td>
                <asp:DropDownList ID="drpcity" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Pincode:</td>
            <td><asp:TextBox ID="txtpincode"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Mobile:</td>
            <td><asp:TextBox ID="txtmobile"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="txtemail"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Gender:</td>
            <td>
                <asp:DropDownList ID="drpgender" runat="server">
                    <asp:ListItem>-Select Gender-</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Date of Birth:</td>
            <td><asp:TextBox ID="txtdob" TextMode="Date"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>User Name:</td>
            <td><asp:TextBox ID="txtusername" runat="server" ReadOnly="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Security Question:</td>
            <td><asp:TextBox ID="txtsecurityquestion" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Secure Answer:</td>
            <td><asp:TextBox ID="txtsecureanswer" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

