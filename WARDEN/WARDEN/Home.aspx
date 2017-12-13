<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WARDEN.WebForm1" EnableEventValidation="false" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar-form navbar-right">
        <ul class="nav nav-pills">
            <li role="presentation">
                <div id="noti_Container">
                    <a id="nbutton">Notifications</a>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="noti_bubble" id="count" runat="server">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
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
            <div class="panel-heading">
                <h4>Beacons</h4>
                <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal" id="addunit" style="float: right">Add Unit</button>
                <div class="row" style="padding-left: 10px">

                    <div class="input-group">
                        <asp:TextBox ID="delete" runat="server" placeholder="Enter a valid ID"></asp:TextBox>
                        <asp:Button ID="Deletebts" runat="server" Text="Delete" CssClass=" btn btn-info btn-sm" />
                    </div>
                </div>

            </div>
            <div class="panel-body">

                <div class="scrollrow" id="scroll">
                    <asp:GridView ID="GridView1" runat="server"
                        ShowHeaderWhenEmpty="true"
                        CssClass="table"
                        GridLines="none"
                        AutoGenerateColumns="False"
                        CellPadding="6"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowEditing="GridView1_RowEditing"
                        OnRowUpdating="GridView1_RowUpdating"
                        CellSpacing="1"
                        BorderStyle="Solid"
                        BorderWidth="1"
                        BorderColor="Black"
                        EditRowStyle-BorderStyle="Solid"
                        EditRowStyle-BorderColor="Black"
                        EditRowStyle-BorderWidth="1"
                        HeaderStyle-BackColor="#0099CC"
                        HeaderStyle-BorderStyle="Solid"
                        HeaderStyle-BorderColor="Black"
                        HeaderStyle-BorderWidth="1"
                        RowStyle-BorderStyle="Solid" RowStyle-BorderColor="Black" RowStyle-BorderWidth="1" SelectedRowStyle-BorderStyle="Solid" SelectedRowStyle-BorderColor="Black" SelectedRowStyle-BorderWidth="1" BackColor="#33CCFF" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="Middle" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" AlternatingRowStyle-HorizontalAlign="Center" AlternatingRowStyle-VerticalAlign="Middle" EditRowStyle-HorizontalAlign="Center" EditRowStyle-VerticalAlign="Middle" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-VerticalAlign="Middle" FooterStyle-HorizontalAlign="Center" FooterStyle-VerticalAlign="Middle" SelectedRowStyle-HorizontalAlign="Center" SelectedRowStyle-VerticalAlign="Middle">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>

                                    <asp:Button ID="ping" runat="server" Text="Ping" Width="50" CssClass="btn btn-primary btn-xs" />
                                    <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" Width="50" CssClass=" btn btn-primary btn-xs" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-primary btn-xs" />
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-primary btn-xs" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("idb") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="X">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_x" runat="server" Text='<%#Eval("x") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_x" runat="server" Text='<%#Eval("x") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Y">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_y" runat="server" Text='<%#Eval("y") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_y" runat="server" Text='<%#Eval("y") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_comments" runat="server" Text='<%#Eval("comments") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_comments" runat="server" Text='<%#Eval("comments") %>'></asp:TextBox>
                                </EditItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last seen">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ls" runat="server" Text='<%#Eval("last_seen") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_ls" runat="server" Text='<%#Eval("last_seen") %>'></asp:TextBox>
                                </EditItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass=".simple-linear" ForeColor="#ffffff" />
                        <RowStyle BackColor="#87CEFA" />
                    </asp:GridView>
                </div>
                <div class="row">
                    <!-- Trigger the modal with a button -->


                    <!-- Modal -->
                    <div id="myModal" class="modal fade" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Unit Data</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label for="exampleInputEmail1">X-coordinates</label>
                                        <asp:TextBox type="text" CssClass="form-control" ID="xcords" runat="server" placeholder="Enter Coordinates"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label for="exampleInputPassword1">Y-coordinates</label>
                                        <asp:TextBox type="text" CssClass="form-control" ID="ycords" runat="server" placeholder="Enter Coordinates"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label for="comments">Comments</label>
                                        <asp:TextBox type="text" CssClass="form-control" ID="comments" runat="server" placeholder="Enter Comments"></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <label for="neighbourid">Neighbour Id</label>
                                        <asp:TextBox type="text" CssClass="form-control" ID="neighbourid" runat="server" placeholder="Enter valid neighbour"></asp:TextBox>

                                    </div>
                                    <asp:Button ID="confirmadd" runat="server" CssClass="btn btn-primary" Text="AddUnit" OnClick="Addbeacon_click"></asp:Button>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal" runat="server">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var markers = [
            <asp:Repeater ID="rptMarkers" runat="server" >
                <ItemTemplate>
                    {
                        "title": '<%# Eval("idb") %>',
                        "lat": '<%# Eval("x") %>',
                        "lng": '<%# Eval("y") %>',
                         "description": '<%# Eval("comments") %>'
        }
</ItemTemplate>
              <SeparatorTemplate>
                  ,
</SeparatorTemplate>
            </asp:Repeater >
];
    </script>
    <div class="col-md-8" id="map" style="height: 600px">
    </div>

    <div id="nlist" style="display: none">
        <div class="tabs">
            <ul class="tab-links">
                <li class="active">
                    <a href="#tab1">Latest</a>
                </li>
                <li><a href="#tab2">History</a></li>
            </ul>
            <div class="tabcontent">
                <div id="tab1" class="tab active">
                    <div class="panel panel-notifications">
                        <div class="panel-body">
                            <div class="scrollrow">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="PendingRecordsGridview"
                                            AutoGenerateColumns="False" DataKeyNames="idn"
                                            OnRowCommand="PendingRecordsGridview_RowCommand" CssClass="table" GridLines="none" AllowPaging="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" SortExpression="idn">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("idn")  %>'></asp:Label>
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
                                                <asp:TemplateField HeaderText="Unit ID" SortExpression="idb">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("idb") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("idb") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Received" SortExpression="time">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# getTime( Eval("time").ToString() )%>'></asp:Label>
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
                                        <asp:Timer runat="server" ID="Timer1" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>
                                        <asp:Label runat="server" Text="page not refreshed yet" ID="refreshnotif"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tab2" class="tab">
                    <div class="panel panel-history">
                        <div class="panel-body">
                            <div class="scrollrow">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ShowHeaderWhenEmpty="true" ID="AcceptedRecordsGridview" AutoGenerateColumns="false"
                                            DataKeyNames="idn" CssClass="table " GridLines="none" AllowPaging="true" OnPageIndexChanging="OnPaging" AllowSorting="true" PageSize="4">
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
                                                <asp:TemplateField HeaderText="Unit ID" SortExpression="idb">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("idb") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("idb") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        Status:
                                                        <asp:DropDownList ID="ddlStatus" runat="server"
                                                            OnSelectedIndexChanged="StatusChanged" AutoPostBack="true"
                                                            AppendDataBoundItems="true">
                                                            <asp:ListItem Text="ALL" Value="ALL"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Received" SortExpression="time">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Solved" SortExpression="timeUpdated">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("timeUpdated") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("timeUpdated") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Timer runat="server" ID="Timer2" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>
                                        <asp:Label runat="server" Text="page not refreshed yet" ID="refreshhist"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
