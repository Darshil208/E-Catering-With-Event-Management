<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="EventPlan.aspx.cs" Inherits="Customer_EventPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title1">Event Plan</h2>
    <asp:DataList ID="DataList1" runat="server" CssClass="datalist">
        <ItemTemplate>
            <table style="width:100%">
                <tr>
                    <td>
                        <p>Event Type: <asp:Literal ID="Literal3" runat="server" Text='<% #Eval("eventtypename") %>'></asp:Literal></p>
                    </td>
                    <td>
                        <p>Total Days: <asp:Literal ID="Literal2" runat="server" Text='<% #Eval("totaldays") %>'></asp:Literal></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Plan Create Date: <asp:Literal ID="Literal6" runat="server" Text='<% #Eval("createdate") %>'></asp:Literal></p>
                    </td>
                    <td>
                        <p>Start Date: <asp:Literal ID="Literal1" runat="server" Text='<% #Eval("eventstartdate") %>'></asp:Literal></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Budget Amount: <asp:Literal ID="Literal4" runat="server" Text='<% #Eval("budgetamount") %>'></asp:Literal>/- Rs.</p>
                    </td>
                    <td>
                        <p>Plan Status: <asp:Literal ID="Literal7" runat="server" Text='<% #Eval("planstatus") %>'></asp:Literal></p>
                    </td>
                </tr>
            </table>
            <hr />
            <h2 class="title2">About Plan:</h2>
            <p></p><asp:Literal ID="Literal5" runat="server" Text='<% #Eval("aboutplan") %>'></asp:Literal></h3>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <hr />
    <h2 class="title2">Choose services for event</h2>
    <asp:DataList ID="DataList2" runat="server" RepeatColumns="5" style="width:100%;">
        <ItemTemplate>
            <p class="equaltext">
                <asp:HyperLink ID="HyperLink1" runat="server" Text='<% #Eval("serviceprovidertype") %>'  NavigateUrl='<% #Eval("serviceprovidertypeid","ServiceProviderList.aspx?sptid={0}") %>'></asp:HyperLink></p>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <hr />
    <asp:Literal ID="lteventservice" runat="server"></asp:Literal>
    <asp:GridView ID="GridView1" runat="server" EmptyDataText="No servie package yet added to event plan." AutoGenerateColumns="False" CssClass="gridtable" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="30"  DeleteImageUrl="../Images/drop.png" ButtonType="Image" ControlStyle-Width="30" ControlStyle-Height="30" >
<ControlStyle Height="30px" Width="30px"></ControlStyle>
            </asp:CommandField>
            <asp:CommandField ButtonType="Image" CancelImageUrl="../Images/drop.png" EditImageUrl="../Images/edit.png" ShowEditButton="True" UpdateImageUrl="../Images/edit.png" ControlStyle-Width="30" ControlStyle-Height="30"  />
            <asp:BoundField HeaderText="ID" DataField="eventserviceid" ReadOnly="True" />
            <asp:BoundField HeaderText="Provider Name" DataField="serviceprovidername" ReadOnly="True" />
      
                  <asp:BoundField HeaderText="Package Name" DataField="servicepackagename" ReadOnly="True" />
            <asp:TemplateField HeaderText="Qty">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("servicepackagequantity") %>' Width="50"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("servicepackagequantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Package Amount" DataField="servicepackageamount" ReadOnly="True" />
            <asp:BoundField HeaderText="Total Amount" DataField="servicepackagetotalamount" ReadOnly="True" />
            

        </Columns>
    </asp:GridView>
    <asp:Literal ID="ltservicepackagetotal" runat="server"></asp:Literal>
    <br />
    <p id="confirmdisplay" runat="server">
    <asp:Button ID="btnconfirm" runat="server" Text="Confirm" OnClick="btnconfirm_Click" />
        </p>
</asp:Content>

