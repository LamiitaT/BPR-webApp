<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WARDEN.Login" MasterPageFile ="~/Master.Master"%>

<asp:Content ID="Content_Login" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
                <table>
                    <tr>
                        <td>Username</td>
                        <td>
                            <asp:TextBox ID="user" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="login_button" runat="server" Text="Login" OnClick="Login_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="feedback" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
    </div>
    </asp:Content>
