<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ServiceProvider_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2>Change Password</h2>
    <table>
        <tr>
            <td>Old Password:</td>
            <td><asp:TextBox ID="txtopassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password:</td>
            <td><asp:TextBox ID="txtnpassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
                <tr>
            <td>Confirm Password:</td>
            <td><asp:TextBox ID="txtcpassword" TextMode="Password" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  /></td>
        </tr>
    </table>
</asp:Content>

