<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="serviceprovider.aspx.cs" Inherits="Admin_serviceprovider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageheader">
        <div class="pageicon"><span class="iconfa-pencil"></span></div>
        <div class="pagetitle">
            <h1>Service Provider</h1>
        </div>
    </div>
    <div class="maincontent">
        <div class="maincontentinner">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <h4 class="widgettitle">Service Provider Grid</h4>
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
                                Provider Type: <asp:DropDownList ID="drpfilterprovidertype" CssClass="selector" runat="server"></asp:DropDownList><asp:Button ID="btnfilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnfilter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="20" ItemStyle-Width="20">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" SelectImageUrl="../Images/edit.png" ButtonType="Image" ControlStyle-Width="20" ControlStyle-Height="20" />
                                        <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="30"  DeleteImageUrl="../Images/drop.png" ButtonType="Image" ControlStyle-Width="20" ControlStyle-Height="20" />
                                        <asp:BoundField HeaderText="ID" DataField="serviceproviderid" />
                                        <asp:BoundField HeaderText="Provider Name" DataField="serviceprovidername" />
                                        <asp:BoundField HeaderText="City" DataField="cityname" />
                                        <asp:BoundField HeaderText="Mobile" DataField="mobile" />
                                        <asp:BoundField HeaderText="Email" DataField="email" />
                                        <asp:BoundField HeaderText="Image" DataField="serviceproviderimage" />
                                        <asp:BoundField HeaderText="Type" DataField="serviceprovidertype" />
                                        <asp:BoundField HeaderText="User Name" DataField="username" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>



                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="widget">
                        <h4 class="widgettitle">Service Provider Detail</h4>
                        <div class="widgetcontent">

                            <div class="stdform">

                                <p>
                                    <label>Service Provider Name</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtserviceprovidername" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Address</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>State:</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpstate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpstate_SelectedIndexChanged"></asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>City Name</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpcityid" runat="server"></asp:DropDownList>
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
                                    <label>Website</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtwebsite" runat="server"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>About Service Provider</label>
                                    <span class="field">
                                        <asp:TextBox ID="txtaboutserviceprovider" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Service Provider Image</label>
                                    <span class="field">
                                        <asp:FileUpload ID="fuserviceproviderimage" runat="server" />
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>Service Provider Type</label>
                                    <span class="field">
                                        <asp:DropDownList ID="drpserviceprovidertype" runat="server"></asp:DropDownList>
                                    </span>
                                    <%--<small class="desc">Small description of this field.</small>--%>
                                </p>
                                <p>
                                    <label>User Name</label>
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

