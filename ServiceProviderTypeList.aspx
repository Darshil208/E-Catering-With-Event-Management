<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="ServiceProviderTypeList.aspx.cs" Inherits="ServiceProviderTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Service Provider Type</h2>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" style="width:100%;">
        <ItemTemplate>
            <p>
                <asp:HyperLink ID="HyperLink1" runat="server" Text='<% #Eval("serviceprovidertype") %>'  NavigateUrl='<% #Eval("serviceprovidertypeid","ServiceProviderList.aspx?sptid={0}") %>'></asp:HyperLink></p>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

