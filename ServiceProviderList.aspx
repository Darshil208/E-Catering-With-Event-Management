<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="ServiceProviderList.aspx.cs" Inherits="ServiceProviderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Service Provider</h2>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" style="width:100%;">
        <ItemTemplate>
            <p><h3><asp:HyperLink ID="HyperLink1" runat="server" Text='<% #Eval("serviceprovidername") %>'  NavigateUrl='<% #Eval("serviceproviderid","ServicePackageList.aspx?spid={0}") %>'></asp:HyperLink></h3><br />
                Mobile: <asp:Literal ID="Literal1" runat="server" Text='<% #Eval("mobile") %>'></asp:Literal>
                <br />
                Email: <asp:Literal ID="Literal2" runat="server" Text='<% #Eval("email") %>'></asp:Literal>
                <br />Website: <asp:Literal ID="Literal3" runat="server" Text='<% #Eval("website") %>'></asp:Literal>
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" Text="View Package"  NavigateUrl='<% #Eval("serviceproviderid","ServicePackageList.aspx?spid={0}") %>'></asp:HyperLink>
            </p>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

