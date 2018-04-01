<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="CustomerRegistration.aspx.cs" Inherits="CustomerRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Customer Registration Form</h2>
    <table>
        <tr>
            <td>First Name: <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name Required" ControlToValidate="txtfirstname"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator6" runat="server" ErrorMessage="Only alphabates allowed" ValidationExpression="[A-Za-z ]\w+" ControlToValidate="txtfirstname"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Last Name:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtlastname"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name Required" ControlToValidate="txtlastname"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator7" runat="server" ErrorMessage="Only alphabates allowed" ValidationExpression="[A-Za-z ]\w+" ControlToValidate="txtlastname"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Address:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtaddress" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Address Required" ControlToValidate="txtaddress"></asp:RequiredFieldValidator></td>
        </tr>
        
        <tr>
            <td>State:  <span style="color:red; font-size:14px;">*</span></td>
            <td>
                <asp:DropDownList ID="drpstate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpstate_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>City:  <span style="color:red; font-size:14px;">*</span></td>
            <td>
                <asp:DropDownList ID="drpcity" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Pincode:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtpincode"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pincode Required" ControlToValidate="txtpincode"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid pincode" ValidationExpression="[0-9]{6}" ControlToValidate="txtpincode"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Mobile:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtmobile"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Mobile Number Required" ControlToValidate="txtmobile"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid mobile number" ControlToValidate="txtmobile" ValidationExpression="[789]{1}[0-9]{9}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Email:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtemail"  runat="server" TextMode="Email" placeholdertext="example@domain.com"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Email Required" ControlToValidate="txtemail"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Gender:  <span style="color:red; font-size:14px;">*</span></td>
            <td>
                <asp:DropDownList ID="drpgender" runat="server">
                    <asp:ListItem>-Select Gender-</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Date of Birth:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtdob" TextMode="Date"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Date of Birth Required" ControlToValidate="txtdob"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>User Name:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" runat="server" ErrorMessage="User Name Required" ControlToValidate="txtusername"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator1" runat="server" ErrorMessage="[A-Za-z0-9_.] is allowed" ControlToValidate="txtusername" ValidationExpression="[A-Za-z0-9_.]\w+"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Password:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtpassword" TextMode="Password"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Password Required" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtcpassword" TextMode="Password"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="txtcpassword"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password mismatch" ControlToCompare="txtpassword" ControlToValidate="txtcpassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Security Question:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtsecurityquestion" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Security Question Required" ControlToValidate="txtsecurityquestion"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Secure Answer:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtsecureanswer" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Secure Answer Required" ControlToValidate="txtsecureanswer"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1"><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>


