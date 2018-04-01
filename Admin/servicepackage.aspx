<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="servicepackage.aspx.cs" Inherits="Admin_servicepackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageheader">
        <div class="pageicon"><span class="iconfa-pencil"></span></div>
        <div class="pagetitle">
            <h1>Service Package</h1>
        </div>
    </div>
    <div class="maincontent">
        <div class="maincontentinner">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <h4 class="widgettitle">Service Package Grid</h4>
                    <table class="table">
                        <tr>
                            <td>
                                <%--<asp:Button ID="btnaddnew" runat="server" Text="Add New" OnClick="btnaddnew_Click" CssClass="btn btn-primary" />--%>
                                <asp:Button ID="btnselectall" runat="server" Text="Select All" OnClick="btnselectall_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" CssClass="btn btn-primary" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Service Provider Type: <asp:DropDownList ID="drpfilterserviceprovidertype" CssClass="selector" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpfilterserviceprovidertype_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Service Provider:<asp:DropDownList ID="drpfilterserviceprovider" CssClass="selector" runat="server"></asp:DropDownList><asp:Button ID="btnfilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnfilter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="30" ItemStyle-Width="30">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" SelectImageUrl="../Images/edit.png" ButtonType="Image" ControlStyle-Width="30" ControlStyle-Height="30" />
                                        <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="30"  DeleteImageUrl="../Images/drop.png" ButtonType="Image" ControlStyle-Width="30" ControlStyle-Height="30" />
                                        <asp:BoundField HeaderText="ID" DataField="servicepackageid" />
                                        <asp:BoundField HeaderText="Service Package Name" DataField="servicepackagename" />
                                        <asp:BoundField HeaderText="Service Package Detail" DataField="servicepackagedetail" />
                                        <asp:BoundField HeaderText="Service Package Amount" DataField="servicepackageamount" />
                                        <asp:BoundField HeaderText="Service Pakcage Image" DataField="servicepackageimage" />
                                        <asp:ImageField HeaderText="Image" DataImageUrlField="servicepackageimage" DataImageUrlFormatString="../images/ServicePackage/{0}" ControlStyle-Width="80" ControlStyle-Height="80"/>
                                        <asp:BoundField HeaderText="Service Parovider" DataField="serviceprovidername" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>



                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="widget">
                        <h4 class="widgettitle">Service Package Detail</h4>
                        <div class="widgetcontent">

                            <div class="stdform">
                                <p>
                                    <label>Service Package Name</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtservicepackagename" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Service Package Detail</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtservicepackagedetail" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Service Package Amount</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtservicepackageamount" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Service Package Image</label>
                                    <span class="field">
                                        <asp:FileUpload ID="fuservicepackageimage" runat="server" />
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Service parovider Name</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpserviceparoviderid" runat="server"></asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                                                <p class="stdformbutton">
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnsubmit_Click" />
                                    <asp:Button ID="btnreset" runat="server" Text="Reset" class="btn btn-primary" OnClick="btnreset_Click"/>
                                    <asp:Button ID="btncancle" runat="server" Text="Cancle" class="btn btn-primary" OnClick="btncancel_Click"/>
                                </p>
                            </div>
                        </div>
                        <!--widgetcontent-->
                    </div>
                    <!--widget-->




                </asp:View>
            </asp:MultiView>

                        <div class="footer">
                <div class="footer-left">
                    <span>Copyright &copy; Majesty IT Services 2015-2016. All Rights Reserved.</span>
                </div>
                <div class="footer-right">
                    <span>Developed by: <a href="http://majestyservices.in/">Darshil, Jashna, Dhara - LJ CE Trainee</a></span>
                </div>
            </div>
            <!--footer-->

        </div>
        <!--maincontentinner-->
    </div>


</asp:Content>

