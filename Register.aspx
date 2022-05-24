<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table width="50%" align="center">
        <tr>
            
            <td colspan="2" align="center"><h2 style="color:#2C60C6">REGISTRATION FORM</h2></td>
            
        </tr>
        <tr>
            <td><strong>Username</strong></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="205px"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Username Cannot be blank" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td ><strong>E-Mail</strong></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="205px"></asp:TextBox>
            </td>
            <td >
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Incorrect E-Mail" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td ><strong>Phone No.</strong></td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Height="20px" Width="205px"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td ><strong>Gender</strong></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>MALE</asp:ListItem>
                    <asp:ListItem>FEMALE</asp:ListItem>
                </asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td ><strong>Password</strong></td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Height="19px" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Password cannot be blank" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td ><strong>Confirm Passowrd</strong></td>
            <td >
                <asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="200px" TextMode="Password"></asp:TextBox>
            </td>
            <td >
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4" ControlToValidate="TextBox5" ErrorMessage="Same as Password" Font-Bold="True" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>

        </tr>
        <tr>
            
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" BackColor="#2C60C6"  Font-Bold="True" ForeColor="white" Text="Register Now" OnClick="Button1_Click" width="200px" Height="30px"/>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
       
    </table>
    
</asp:Content>

