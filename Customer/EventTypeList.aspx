<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="EventTypeList.aspx.cs" Inherits="Customer_EventTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Event Type</h2>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" style="width:100%;">
        <ItemTemplate>
            <p>
                <asp:Literal ID="Literal1" runat="server" Text='<% #Eval("eventtypename") %>'></asp:Literal>
                 </p>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

