<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="EventPlan.aspx.cs" Inherits="ServiceProvider_EventPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title1">Event Plan</h2>
    <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" CssClass="gridtable">
    <Columns>
        <asp:BoundField HeaderText="ID" DataField="eventplanid" />
        <asp:BoundField HeaderText="First Name" DataField="firstname" />
        <asp:BoundField HeaderText="Last Name" DataField="lastname" />
        <asp:BoundField HeaderText="Mobile" DataField="mobile" />
        <asp:BoundField HeaderText="Email" DataField="email" />
        <asp:BoundField HeaderText="Start Date" DataField="eventstartdate" />
        <asp:BoundField HeaderText="Days" DataField="totaldays" />
        <asp:HyperLinkField HeaderText="Service" Text="View" DataNavigateUrlFields="eventplanid" DataNavigateUrlFormatString="EventServiceDetail.aspx?epid={0}" />
    </Columns>
    </asp:GridView>
</asp:Content>

