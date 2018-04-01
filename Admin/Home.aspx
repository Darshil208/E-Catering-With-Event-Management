<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pageheader">
        <div class="pageicon"><span class="iconfa-pencil"></span></div>
        <div class="pagetitle">
            <h1>Home</h1>
        </div>
    </div>
    <div class="maincontent">
        <div class="maincontentinner">
            <div class="row-fluid">
                    <div id="dashboard-left" class="span12">
                                              <h5 class="subtitle">Data Summary</h5>
                        <ul class="shortcuts">
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal1" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Customer</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal2" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Event Plan</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal3" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Event Service</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal4" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Event Type</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal5" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Feedback</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal6" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Inquiry</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal7" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Package</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal8" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Provider</span>
                                </a>
                            </li>
                            <li class="events">
                                <a href="   ">
                                    <span class="shortcuts-icon"><asp:Literal ID="Literal9" runat="server"></asp:Literal></span>
                                    <span class="shortcuts-label">Provider Type</span>
                                </a>
                            </li>

                        </ul>
                        
                          </div>
                </div>
            </div>
        </div>
</asp:Content>

