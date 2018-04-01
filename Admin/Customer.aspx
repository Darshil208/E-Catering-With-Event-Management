<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Admin_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageheader">
        <div class="pageicon"><span class="iconfa-pencil"></span></div>
        <div class="pagetitle">
            <h1>Customer</h1>
        </div>
    </div>
    <div class="maincontent">
        <div class="maincontentinner">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <h4 class="widgettitle">Customer Grid</h4>
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
                                        <asp:BoundField HeaderText="ID" DataField="customerid" />
                                        <asp:BoundField HeaderText="First Name" DataField="firstname" />
                                        <asp:BoundField HeaderText="Last Name" DataField="lastname" />
                                        <asp:BoundField HeaderText="City" DataField="cityname" />
                                        <asp:BoundField HeaderText="Pincode" DataField="pincode" />
                                        <asp:BoundField HeaderText="Mobile" DataField="mobile" />
                                        <asp:BoundField HeaderText="Email" DataField="email" />
                                        <asp:BoundField HeaderText="Gender" DataField="gender" />
                                        <asp:BoundField HeaderText="DOB" DataField="dob" />
                                        <asp:BoundField HeaderText="User Name" DataField="username" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="widget">
                        <h4 class="widgettitle">Customer Detail</h4>
                        <div class="widgetcontent">

                            <div class="stdform">
                                <p>
                                    <label>First Name</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Last Name</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Address</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>State Name</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpstate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpstate_SelectedIndexChanged"></asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>City Name</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpcity" runat="server"></asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Pincode</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtpincode" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Mobile</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Email</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Gender</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpgender" runat="server">
                                            <asp:ListItem>-Select Gender-</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>DOB</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtdob" TextMode="Date" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Login</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drploginid" runat="server"></asp:DropDownList>
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

