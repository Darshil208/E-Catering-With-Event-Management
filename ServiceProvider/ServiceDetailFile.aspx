<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="ServiceDetailFile.aspx.cs" Inherits="ServiceProvider_ServiceDetailFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Service Provider Image</h2>
    <table>
        <tr>
            <td>
                <asp:HyperLink ID="hlservicedetailfile" runat="server"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fuservicedetailfile" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

