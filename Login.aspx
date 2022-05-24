<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <link rel="stylesheet" href="StyleSheet.css" type="text/css" runat="server"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1" style="margin-top:60px">
        <tr>
            <td class="auto-style4" colspan="2" align="center"><strong id="homehead">LOGIN FORM</strong><br /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>USERNAME</strong></td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBox1" runat="server" Height="29px" Width="232px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Username Cannot be blank" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>PASSWORD</strong></td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBox2" runat="server" Height="28px" TextMode="Password" Width="231px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Password cannot be blank" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" BackColor="#2C60C6" ForeColor="White" Width="100px" Height="30px" Font-Bold="True" OnClick="Button1_Click" Text="LOGIN" />
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

