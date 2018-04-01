<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Customer_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Feedback</h2>
    <table>
        <tr>
            <td>Service Provider</td>
            <td>
                <asp:Literal ID="ltserviceprovidername" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>Service Email</td>
            <td>
                <asp:Literal ID="ltemail" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>Service Mobile</td>
            <td>
                <asp:Literal ID="ltmobile" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td>Feedback Content</td>
            <td>
                <asp:TextBox ID="txtfeedbackcontent" TextMode="MultiLine" Rows="10" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

