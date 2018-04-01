<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="ConfirmEventPlanList.aspx.cs" Inherits="Customer_ConfirmEventPlanList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title1">Confirm Event Plan List</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridtable">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="eventplanid"/>
            <asp:BoundField HeaderText="Event Type" DataField="eventtypename"/>
            <asp:BoundField HeaderText="Start Date" DataField="eventstartdate"/>
            <asp:BoundField HeaderText="Total Days" DataField="totaldays"/>
            <asp:BoundField HeaderText="Budget Amount" DataField="budgetamount" ItemStyle-HorizontalAlign="right"/>
            <asp:BoundField HeaderText="Create Date" DataField="createdate"/>
            <asp:HyperLinkField HeaderText="Detail" Text="View" DataNavigateUrlFields="eventplanid" DataNavigateUrlFormatString="EventPlan.aspx?epid={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>

