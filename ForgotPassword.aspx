<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Forgot password</h2>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table>
                <tr>
                    <td>User Name:</td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnnext" runat="server" Text="Next" OnClick="btnnext_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>

                <tr>
                    <td>Security Question:</td>
                    <td>
                        <asp:TextBox ID="txtsecurityquestion" ReadOnly="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Answer:</td>
                    <td>
                        <asp:TextBox ID="txtsecureanswer" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>

</asp:Content>

