<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="Admin_UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageheader">
        <div class="pageicon"><span class="iconfa-pencil"></span></div>
        <div class="pagetitle">
            <h1>User Login</h1>
        </div>
    </div>
    <div class="maincontent">
        <div class="maincontentinner">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <h4 class="widgettitle">User Login Grid</h4>
                    <table class="table">
                        <tr>
                            <td>
<%--                                <asp:Button ID="btnaddnew" runat="server" Text="Add New" OnClick="btnaddnew_Click" CssClass="btn btn-primary" />--%>
                                <asp:Button ID="btnselectall" runat="server" Text="Select All" OnClick="btnselectall_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" CssClass="btn btn-primary" />
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
                                        <asp:BoundField HeaderText="ID" DataField="loginid" />
                                        <asp:BoundField HeaderText="Username" DataField="username" />
                                        <asp:BoundField HeaderText="Security Question" DataField="securityquestion" />
                                        <asp:BoundField HeaderText="Secure Answer" DataField="secureanswer" />
                                        <asp:BoundField HeaderText="Userrole" DataField="userrole" />
                                        <asp:BoundField HeaderText="Create Date" DataField="createdate" />
                                        <asp:BoundField HeaderText="Status" DataField="accountstatus" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>



                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="widget">
                        <h4 class="widgettitle">User Login Detail</h4>
                        <div class="widgetcontent">

                            <div class="stdform">
                                <p>
                                    <label>User Name</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Password</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Security Question</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtsecurityquestion" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Secure Answer</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtsecureanswer" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>User Role</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpuserrole" runat="server">
                                            <asp:ListItem>-Select User Role-</asp:ListItem>
                                            <asp:ListItem>ServiceProvider</asp:ListItem>
                                            <asp:ListItem>Customer</asp:ListItem>
                                        </asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Create Date</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtcreatedate" TextMode="Date" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Account Status</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpaccountstatus" runat="server">
                                            <asp:ListItem>-Select Account Status-</asp:ListItem>
                                            <asp:ListItem>Pending</asp:ListItem>
                                            <asp:ListItem>Active</asp:ListItem>
                                            <asp:ListItem>Deactive</asp:ListItem>
                                        </asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>

                                <p class="stdformbutton">
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnsubmit_Click" />
                                    <asp:Button ID="btnreset" runat="server" Text="Reset" class="btn btn-primary" OnClick="btnreset_Click" />
                                    <asp:Button ID="btncancle" runat="server" Text="Cancle" class="btn btn-primary" OnClick="btncancel_Click" />
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

