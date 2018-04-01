<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="Admin_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="title1">Feedback</h2>        
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridtable">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="feedbackid" />
                                        <asp:BoundField HeaderText="Feedback" DataField="feedbackcontent" />
                                        <asp:BoundField HeaderText="First Name" DataField="firstname" />
                                        <asp:BoundField HeaderText="Last Name" DataField="lastname" />
                                        <asp:BoundField HeaderText="Mobile" DataField="mobile" />
                                        <asp:BoundField HeaderText="Email" DataField="email" />
                                        <asp:BoundField HeaderText="Feedback Date" DataField="feedbackdate" />
                                    </Columns>
                                </asp:GridView>
</asp:Content>

