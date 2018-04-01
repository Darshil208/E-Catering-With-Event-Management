<%@ Page Title="" Language="C#" MasterPageFile="~/ServiceProvider/ServiceProviderMaster.master" AutoEventWireup="true" CodeFile="EventServiceDetail.aspx.cs" Inherits="ServiceProvider_EventPlan" %>

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
    <h2 class="title2">Event Service List</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridtable">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="eventserviceid" />
            <asp:BoundField HeaderText="Package Name" DataField="servicepackagename" />
            <asp:BoundField HeaderText="Quantity" DataField="servicepackagequantity" />
            <asp:BoundField HeaderText="Amount" DataField="servicepackageamount" />
            <asp:BoundField HeaderText="Total Amount    " DataField="servicepackagetotalamount" />
        </Columns>
    </asp:GridView>

        <br />
    <hr />
    <h2 class="title2">Customer Detail</h2>
    <asp:DataList ID="DataList2" runat="server" CssClass="datalist">
        <ItemTemplate>
            <p>First Name:
                <asp:Literal ID="Literal8" runat="server" Text='<% #Eval("firstname") %>'></asp:Literal>
            </p>
            <p>Last Name:
                <asp:Literal ID="Literal9" runat="server" Text='<% #Eval("lastname") %>'></asp:Literal>
            </p>
            <p>Address:
                <asp:Literal ID="Literal10" runat="server" Text='<% #Eval("address") %>'></asp:Literal>
            </p>
            <p>City Name:
                <asp:Literal ID="Literal11" runat="server" Text='<% #Eval("cityname") %>'></asp:Literal>
            </p>
            <p>Pincode:
                <asp:Literal ID="Literal12" runat="server" Text='<% #Eval("pincode") %>'></asp:Literal>
            </p>
            <p>Mobile:
                <asp:Literal ID="Literal13" runat="server" Text='<% #Eval("mobile") %>'></asp:Literal>
            </p>
            <p>Email:
                <asp:Literal ID="Literal14" runat="server" Text='<% #Eval("email") %>'></asp:Literal>
            </p>
            <p>Gender:
                <asp:Literal ID="Literal15" runat="server" Text='<% #Eval("gender") %>'></asp:Literal>
            </p>

        </ItemTemplate>
    </asp:DataList>
</asp:Content>

