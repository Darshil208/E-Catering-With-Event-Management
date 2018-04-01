<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="ServicePackageList.aspx.cs" Inherits="ServicePackageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Service Package</h2>
    <asp:DataList ID="DataList1" runat="server"  style="width:100%;">
        <ItemTemplate>
            <table>
                <tr>
                    <td style="vertical-align:top;">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<% #Eval("servicepackageimage","images/ServicePackage/{0}") %>' Height="100" Width="100" />
                    </td>
                    <td>
            <h2 class="title2"><asp:Literal ID="Literal4" runat="server" Text='<% #Eval("servicepackagename") %>'></asp:Literal></h2>
                <br />
                <p>Amount: <asp:Literal ID="Literal2" runat="server" Text='<% #Eval("servicepackageamount") %>'></asp:Literal></p>
                        <p>Detail: <asp:Literal ID="Literal1" runat="server" Text='<% #Eval("servicepackagedetail") %>'></asp:Literal>
            </p>
                    </td>
                </tr>
            </table>
            <hr />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

