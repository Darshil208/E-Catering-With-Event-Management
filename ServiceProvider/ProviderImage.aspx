<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="ProviderImage.aspx.cs" Inherits="ServiceProvider_ProviderImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Service Provider Image</h2>
    <table>
        <tr>
            <td>
                <asp:Image ID="imgserviceproviderimage" Height="100" Width="100" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:FileUpload ID="fuserviceproviderimage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

