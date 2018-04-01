<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="ImageGallery.aspx.cs" Inherits="ServiceProvider_ImageGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Image Gallery</h2>
    <table>
        <tr>
            <td>
                Select Image
            </td>
            <td>
                <asp:FileUpload ID="fuimagefile" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
    </table>
    <asp:DataList ID="DataList1" runat="server" CssClass="datalist" RepeatColumns="4" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton1" CommandName="ibdeleteimage" CommandArgument='<% #Eval("imageid") %>' runat="server" ImageUrl="../images/drop.png" style="height:25px; width:25px;" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" Style="width:150px; height:150px;" ImageUrl='<% #Eval("imagefilename","../Images/ImageGallery/{0}") %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

