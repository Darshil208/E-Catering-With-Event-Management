<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="ServiceProvider_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2>Service Provider Profile</h2>
    <table>
        <tr>
            <td>Organizer Name:</td>
            <td><asp:TextBox ID="txtserviceprovidername" runat="server"></asp:TextBox></td>
        </tr>
<%--        <tr>
            <td>Contact Name:</td>
            <td><asp:TextBox ID="txtcontactname"  runat="server"></asp:TextBox></td>
        </tr>--%>
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
            <td>Website:</td>
            <td><asp:TextBox ID="txtwebsite"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>About Service Provider:</td>
            <td><asp:TextBox ID="txtaboutserviceprovider" Rows="10" TextMode="MultiLine" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Provider Type:</td>
            <td>
                <asp:DropDownList ID="drpserviceprovidertype" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>User Name:</td>
            <td><asp:TextBox ID="txtusername" ReadOnly="true" runat="server"></asp:TextBox></td>
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

