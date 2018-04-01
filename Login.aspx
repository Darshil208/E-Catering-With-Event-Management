<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Login</h2>
    <table>
        <tr>
            <td>User Name:</td>
            <td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="User Name is required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><asp:TextBox ID="txtpassword" TextMode="Password" runat="server">
                </asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ForgotPassword.aspx">Forgot password</asp:HyperLink></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CustomerRegistration.aspx">New Customer registration</asp:HyperLink></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ServiceProviderRegistration.aspx">New Service Provider Registration</asp:HyperLink></td>
        </tr>
    </table>
</asp:Content>

