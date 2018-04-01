<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="ConfirmEventPlan.aspx.cs" Inherits="ServiceProvider_ConfirmEventPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title1">Event Plan Order</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridtable">
        <Columns>
        <asp:BoundField HeaderText="ID" DataField="eventplanid"/>
            <asp:BoundField HeaderText="First Name" DataField="firstname" />
        <asp:BoundField HeaderText="Last Name" DataField="lastname" />
        <asp:BoundField HeaderText="Mobile" DataField="mobile" />
        <asp:BoundField HeaderText="Email" DataField="email" />
            <asp:BoundField HeaderText="Event Type" DataField="eventtypename"/>
            <asp:BoundField HeaderText="Start Date" DataField="eventstartdate"/>
            <asp:BoundField HeaderText="Total Days" DataField="totaldays"/>
            <asp:BoundField HeaderText="Budget Amount" DataField="budgetamount" ItemStyle-HorizontalAlign="right"/>
            <asp:HyperLinkField HeaderText="Detail" Text="View" DataNavigateUrlFields="eventplanid" DataNavigateUrlFormatString="EventServiceDetail.aspx?epid={0}" />
            </Columns>
    </asp:GridView>

</asp:Content>

