<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pageheader">
        <div class="pageicon"><span class="iconfa-pencil"></span></div>
        <div class="pagetitle">
            <h1>City</h1>
        </div>
    </div>
    <div class="maincontent">
        <div class="maincontentinner">
            <div class="widget">
                <h4 class="widgettitle">Form Elements</h4>
                <div class="widgetcontent">

                    <div class="stdform">
                        <p>
                            <label>Old Password:</label>
                            <span class="field">
                                <asp:TextBox ID="txtopassword" TextMode="Password" runat="server"></asp:TextBox>
                            </span>
                            <%--<small class="desc">Small description of this field.</small>--%>
                        </p>
                        <p>
                            <label>New Password:</label>
                            <span class="field">
                                <asp:TextBox ID="txtnpassword" TextMode="Password" runat="server"></asp:TextBox>
                            </span>
                            <%--<small class="desc">Small description of this field.</small>--%>
                        </p>
                        <p>
                            <label>Confirm Password:</label>
                            <span class="field">
                                <asp:TextBox ID="txtcpassword" TextMode="Password" runat="server"></asp:TextBox>
                            </span>
                            <%--<small class="desc">Small description of this field.</small>--%>
                        </p>
                        <p class="stdformbutton">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </p>
                    </div>
                </div>
                <!--widgetcontent-->
            </div>
            <!--widget-->
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

