<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="ServiceProviderDetail.aspx.cs" Inherits="Customer_ServiceProviderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Service Provider</h2>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Style="width: 100%;">
        <ItemTemplate>
            <p>
                <h3>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text='<% #Eval("serviceprovidername")%>' NavigateUrl='<% #Eval("serviceproviderid", "ServicePackageList.aspx?spid={0}")%>'></asp:HyperLink></h3>
            </p>
            <p>
                Address:
                <asp:Literal ID="Literal1" runat="server" Text='<% #Eval("address")%>'></asp:Literal>
            </p>
            <p>
                City Name:
                <asp:Literal ID="Literal2" runat="server" Text='<% #Eval("cityname")%>'></asp:Literal>
            </p>
            <p>
                Pincode:
                <asp:Literal ID="Literal3" runat="server" Text='<% #Eval("pincode")%>'></asp:Literal>
            </p>
            <p>
                Mobile:
                <asp:Literal ID="Literal4" runat="server" Text='<% #Eval("mobile")%>'></asp:Literal>
            </p>
            <p>
                Email:
                <asp:Literal ID="Literal5" runat="server" Text='<% #Eval("email")%>'></asp:Literal>
            </p>
            <p>
                Website:
                <asp:Literal ID="Literal6" runat="server" Text='<% #Eval("website")%>'></asp:Literal>
            </p>
            <p>
                <asp:HyperLink ID="HyperLink2" runat="server" Text="View Package" NavigateUrl='<% #Eval("serviceproviderid", "ServicePackageList.aspx?spid={0}")%>'></asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink3" runat="server" Text="Give Feedback" NavigateUrl='<% #Eval("serviceproviderid", "Feedback.aspx?spid={0}")%>'></asp:HyperLink>
            </p>
            <p>
                About Service Provider:
                <asp:Literal ID="Literal7" runat="server" Text='<% #Eval("aboutserviceprovider")%>'></asp:Literal>
            </p>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <hr />
    <h2 class="title2">Provider Feedback</h2>
        <asp:DataList ID="DataList2" runat="server" RepeatColumns="3" Style="width: 100%;">
        <ItemTemplate>
            <p>"<asp:Literal ID="Literal1" runat="server" Text='<% #Eval("feedbackcontent")%>'></asp:Literal>"</p>
            <p style="width:100%; text-align:right;">by, <asp:Literal ID="Literal2" runat="server" Text='<% #Eval("firstname")%>'></asp:Literal>&nbsp;<asp:Literal ID="Literal8" runat="server" Text='<% #Eval("lastname")%>'></asp:Literal>&nbsp;&nbsp;(<asp:Literal ID="Literal3" runat="server" Text='<% #Eval("feedbackdate")%>'></asp:Literal>)</p>
            <hr style="border:1px dashed #ff6a00;" />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

