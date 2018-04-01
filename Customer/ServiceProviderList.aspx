<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="ServiceProviderList.aspx.cs" Inherits="Customer_ServiceProviderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Service Provider</h2>
    <asp:DataList ID="DataList1" runat="server" CssClass="datalist" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table>
                <tr>
                    <td style="width:16%">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<% #Eval("serviceproviderimage", "../Images/ServiceProvider/{0}")%>' Height="130" Width="100" Style="margin-right: 10px;" />
                    </td>
                    <td style="width:66%;">
                        <h2 class="title2">
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<% #Eval("serviceprovidername")%>' NavigateUrl='<% #Eval("serviceproviderid", "ServiceProviderDetail.aspx?spid={0}")%>'></asp:HyperLink></h2>
                        <p>
                            Mobile:
                <asp:Literal ID="Literal1" runat="server" Text='<% #Eval("mobile")%>'></asp:Literal>
                        </p>
                        <p>
                            Email:
                <asp:Literal ID="Literal2" runat="server" Text='<% #Eval("email")%>'></asp:Literal>
                        </p>
                        <p>
                            Website:
                <asp:Literal ID="Literal3" runat="server" Text='<% #Eval("website")%>'></asp:Literal>
                        </p>
                        <p><asp:HyperLink ID="HyperLink4" runat="server" Text="Service File Detail" NavigateUrl='<% #Eval("servicedetailfile", "../Images/ServiceDetailFile/{0}")%>'></asp:HyperLink></p>
                        </td>
                    <td  style="width:18%;">
                         <p>
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink2" runat="server" Text="View Package" NavigateUrl='<% #Eval("serviceproviderid", "ServicePackageList.aspx?spid={0}")%>'></asp:HyperLink></p>
                        <p>
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink3" runat="server" Text="Give Feedback" NavigateUrl='<% #Eval("serviceproviderid", "Feedback.aspx?spid={0}")%>'></asp:HyperLink>
                        </p>
                        <p>
                            <asp:HyperLink CssClass="btn btn-link" ID="HyperLink5" runat="server" Text="Image Gallery" NavigateUrl='<% #Eval("serviceproviderid", "ImageGallery.aspx?spid={0}")%>'></asp:HyperLink>
                        </p>
<%--                        <p>
                            <asp:LinkButton CssClass="btn btn-link" ID="LinkButton1" runat="server" Text="Add to Plan" CommandName="hlbaddtoplan" CommandArgument='<% #Eval("serviceproviderid") %>'></asp:LinkButton>
                        </p>--%>
                    </td>
                </tr>
            </table>
            <hr />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

