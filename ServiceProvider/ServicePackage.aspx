<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="ServicePackage.aspx.cs" Inherits="ServiceProvider_ServicePackage" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Service Package</h2>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <h4>Service Provider Grid</h4>
            <table class="datatable">
                <tr>
                    <td>
                        <asp:Button ID="btnaddnew" runat="server" Text="Add New" OnClick="btnaddnew_Click" />
                        <asp:Button ID="btnselectall" runat="server" Text="Select All" OnClick="btnselectall_Click" />
                        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="gridtable">
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="30" ItemStyle-Width="30">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width="30"   SelectImageUrl="../Images/edit.png" ButtonType="Image" ControlStyle-Width="30" ControlStyle-Height="30" />
                                <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="30"  DeleteImageUrl="../Images/drop.png" ButtonType="Image" ControlStyle-Width="30" ControlStyle-Height="30" />
                                <asp:BoundField HeaderText="ID" DataField="servicepackageid" />
                                <asp:BoundField HeaderText="Package Name" DataField="servicepackagename" />
                                <asp:BoundField HeaderText="Package Amount" DataField="servicepackageamount" />
                                <asp:ImageField HeaderText="Image" DataImageUrlField="servicepackageimage" DataImageUrlFormatString="../images/ServicePackage/{0}" ControlStyle-Width="80" ControlStyle-Height="80" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table class="form">
                <tr>
                    <td>Service Package Name</td>
                    <td>
                        <asp:TextBox ID="txtservicepackagename" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Service Package Detail</td>
                    <td>
                        <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>
                        <%--<asp:TextBox ID="txtservicepackagedetail" TextMode="MultiLine" Rows="10" runat="server"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td>Service Package Amount</td>
                    <td>
                        <asp:TextBox ID="txtservicepackageamount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Service Package Image</td>
                    <td>
                        <asp:FileUpload ID="fuservicepackageimage" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                        <asp:Button ID="btnreset" runat="server" Text="Reset" OnClick="btnreset_Click" />
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

