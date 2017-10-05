<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WARDEN.WebForm1" enableEventValidation="false" MasterPageFile ="~/Master.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="navbar-form navbar-right">
    <ul class="nav nav-pills">
        <li role="presentation">
            <a id="nbutton">Notifications</a>
        </li>
        <li role="presentation">
            <a id="logoutButton" href="Logout.aspx">Logout</a>
        </li>
    </ul>
   </div>
</asp:Content>

<asp:Content ID="Content_Home" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div class="col-md-3 col-sm-4" id="blist">
    <div class="panel panel-beacons">
        <div class="panel-heading">Beacons</div>
        <div class="panel-body">
            <div class="scrollrow">
                <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="true" CssClass="table" ShowHeaderWhenEmpty="True">
                    <Columns>
                        <asp:BoundField DataField="idn" HeaderText="idn" SortExpression="idn" />
                        <asp:BoundField DataField="ntype" HeaderText="ntype" SortExpression="ntype" />
                        <asp:BoundField DataField="ninfo" HeaderText="ninfo" SortExpression="ninfo" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
    <div class="col-md-9 col-sm-8 map">
    </div>
    <div id="nlist" style="display: none">
        <div class="tabs">
            <ul class="tab-links">
                <li class="active"><a href="#tab1">Latest</a></li>
                <li><a href="#tab2">History</a></li>
            </ul>
            <div class="tabcontent">
                <div id="tab1" class="tab active">
                    <div class="panel panel-notifications">
                        <div class="panel-body">
                            <div class="scrollrow">
                                <asp:GridView runat="server" ID="PendingRecordsGridview"
                                    AutoGenerateColumns="False" DataKeyNames="idn"
                                    OnRowCommand="PendingRecordsGridview_RowCommand" CssClass="table" GridLines="none">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Message info" SortExpression="ninfo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ninfo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ninfo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Beacon ID" SortExpression="idb">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("idb") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("idb") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandArgument='<%# Bind("idn") %>' ID="seenButton" runat="server"
                                                    CausesValidation="false" CommandName="seen" Text="Seen" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tab2" class="tab">
                    <div class="panel panel-history">
                        <div class="panel-body">
                            <div class="scrollrow">
                                <asp:GridView runat="server" ID="AcceptedRecordsGridview" AutoGenerateColumns="false"
                                    DataKeyNames="idn" CssClass="table" GridLines="none">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" SortExpression="idn">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("idn") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("idn") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Message info" SortExpression="ninfo">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ninfo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ninfo") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Beacon ID" SortExpression="idb">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("idb") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("idb") %>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> 
    </asp:Content>
