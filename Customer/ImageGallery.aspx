<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="ImageGallery.aspx.cs" Inherits="Customer_ImageGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2>Image Gallery</h2>
    <asp:DataList ID="DataList1" runat="server" CssClass="datalist" RepeatColumns="4" >
        <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Style="width:150px; height:150px;" ImageUrl='<% #Eval("imagefilename","../Images/ImageGallery/{0}") %>' />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

