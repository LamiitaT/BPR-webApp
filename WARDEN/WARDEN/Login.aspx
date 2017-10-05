<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WARDEN.Login" MasterPageFile ="~/Master.Master"%>

<asp:Content ID="Content_Login" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login">
                <table>
                    <tr>
                        <td>Username</td>
                        <td>
                            <asp:TextBox ID="user" class="t" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="pass" class="t" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="btnLogin" class="b" runat="server" OnClick="Login_Click"><span>Login</span></asp:LinkButton>
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
