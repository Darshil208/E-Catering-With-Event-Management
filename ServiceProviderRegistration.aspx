<%@ Page Title="" Language="C#" MasterPageFile="~/GeneralMaster.master" AutoEventWireup="true" CodeFile="ServiceProviderRegistration.aspx.cs" Inherits="ServiceProviderRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Service Provider Registration</h2>
    <table>
        <tr>
            <td>Company Name: <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtserviceprovidername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  Display="Dynamic"   ControlToValidate="txtserviceprovidername"   ID="RequiredFieldValidator1" runat="server" ErrorMessage="Company Name Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator4" runat="server" ErrorMessage="Only alphabates and space is allowed." ControlToValidate="txtserviceprovidername" ValidationExpression="^[a-zA-Z0-9'.\s]{1,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Organizer Name:  <span style="color:red; font-size:14px;">*</span> </td>
            <td><asp:TextBox ID="txtcontactname"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtserviceprovidername"   ID="RequiredFieldValidator13" runat="server" ErrorMessage="Organizer Name Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator5" runat="server" ErrorMessage="Only alphabates and space is allowed." ControlToValidate="txtcontactname" ValidationExpression="^[a-zA-Z\s]{1,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Address:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtaddress" Rows="4" TextMode="MultiLine" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtaddress"   ID="RequiredFieldValidator2" runat="server" ErrorMessage="Address Required"></asp:RequiredFieldValidator></td>
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
            <td><asp:TextBox ID="txtpincode"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtpincode"   ID="RequiredFieldValidator3" runat="server" ErrorMessage="Pincode Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid pincode" ValidationExpression="[0-9]{6}" ControlToValidate="txtpincode"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Mobile:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtmobile"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtmobile"   ID="RequiredFieldValidator4" runat="server" ErrorMessage="Mobile Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid mobile number" ControlToValidate="txtmobile" ValidationExpression="[789]{1}[0-9]{9}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Email:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtemail"  TextMode="Email" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtemail"   ID="RequiredFieldValidator5" runat="server" ErrorMessage="Email Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Website:</td>
            <td><asp:TextBox ID="txtwebsite"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>About Service Provider:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtaboutserviceprovider" Rows="10" TextMode="MultiLine" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtaboutserviceprovider"   ID="RequiredFieldValidator7" runat="server" ErrorMessage="About Service Provider Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Image File:  <span style="color:red; font-size:14px;">*</span></td>
            <td>
                <asp:FileUpload ID="fuimagefile" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Service Detail File:  <span style="color:red; font-size:14px;">*</span></td>
            <td>
                <asp:FileUpload ID="fuservicedetailfile" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Provider Type:  <span style="color:red; font-size:14px;">*</span></td>
            <td>
                <asp:DropDownList ID="drpserviceprovidertype" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>User Name:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtusername"   ID="RequiredFieldValidator8" runat="server" ErrorMessage="User Name Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator1" runat="server" ErrorMessage="[A-Za-z0-9_.] is allowed" ControlToValidate="txtusername" ValidationExpression="[A-Za-z0-9_.]\w+"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>Password:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtpassword" TextMode="Password"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtpassword"   ID="RequiredFieldValidator9" runat="server" ErrorMessage="Password Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Confirm Password:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtcpassword" TextMode="Password"  runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtcpassword"   ID="RequiredFieldValidator10" runat="server" ErrorMessage="Confirm Password Required"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password mismatch" ControlToCompare="txtpassword" ControlToValidate="txtcpassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Security Question:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtsecurityquestion" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtsecurityquestion"   ID="RequiredFieldValidator11" runat="server" ErrorMessage="Security Question Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Secure Answer:  <span style="color:red; font-size:14px;">*</span></td>
            <td><asp:TextBox ID="txtsecureanswer" runat="server"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtsecureanswer" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Secure Answer Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

