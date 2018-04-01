<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="CreatePlan.aspx.cs" Inherits="Customer_CreatePlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Create Event Plan</h2>
    <table>
        <tr>
            <td>Event Type</td>
            <td>
                <asp:DropDownList ID="drpeventtype" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Event Start Date</td>
            <td>
                <asp:TextBox ID="txteventstartdate" TextMode="Date" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Total Days</td>
            <td>
                <asp:TextBox ID="txttotaldays" TextMode="Number" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Budget Amount</td>
            <td>
                <asp:TextBox ID="txtbudgetamount"  runat="server"></asp:TextBox>/-&nbsp;Rs.
            </td>
        </tr>
        <tr>
            <td>About Plan</td>
            <td>
                <asp:TextBox ID="txtaboutplan" TextMode="MultiLine" Rows="10" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

