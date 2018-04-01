<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="ServicePackageList.aspx.cs" Inherits="Customer_ServicePackageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Service Package</h2>
    <asp:DataList ID="DataList1" runat="server" CssClass="datalist" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table>
                <tr>
                    <td style="width:16%;">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<% #Eval("servicepackageimage", "../images/ServicePackage/{0}")%>' Height="100" Width="100" />
                    </td>
                    <td style="width:68%;">
                        <h2 class="title2"><asp:Literal ID="Literal4" runat="server" Text='<% #Eval("servicepackagename")%>'></asp:Literal></h2>
                        <p><b>Detail: </b><asp:Literal ID="Literal1" runat="server" Text='<% #Eval("servicepackagedetail")%>'></asp:Literal>
                        </p>
                    </td>
                    <td style="width:16%;">
                        <p><strong>Price:</strong><br />
                        <span style="font-size:16px; font-weight:bold;"><asp:Literal ID="Literal2" runat="server" Text='<% #Eval("servicepackageamount")%>'></asp:Literal>/- Rs.</span></p>
                        <p>
                            <asp:LinkButton CssClass="btn btn-link" ID="LinkButton1" runat="server" Text="Add to Plan" CommandName="hlbaddtoplan" CommandArgument='<% #Eval("servicepackageid") %>'></asp:LinkButton>
                        </p>
                    </td>
                </tr>
            </table>
            <hr />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

