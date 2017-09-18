<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WARDEN.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

  

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="style.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <environment names="Development">
        <link rel="stylesheet" href="Content/bootstrap.css" />
        <link rel="stylesheet" href="~/css/site.css" />
    </environment>
    <environment names="Staging,Production">
        <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/css/bootstrap.min.css"
              asp-fallback-href="Content/bootstrap.min.css"
              asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute" />
        <link rel="stylesheet" href="~/css/site.min.css" asp-append-version="true" />
    </environment>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css?version = 18"/>
    
     
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#nbutton').click(function () {
                var list = document.getElementById("nlist");

                if (list.style.display == "none") {
                    list.style.display = "block";
                } else {
                    list.style.display = "none";
                }
            });
            $('.tabs .tab-links a').on('click', function (e) {
                var currentAttrValue = jQuery(this).attr('href');

                // Show/Hide Tabs
                jQuery('.tabs ' + currentAttrValue).fadeIn(400).siblings().hide();

                // Change/remove current tab to active
                jQuery(this).parent('li').addClass('active').siblings().removeClass('active');

                e.preventDefault();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- Top navigation -->
        <div class="navbar navbar-default navbar-fixed-top header">
            <div class="navbar-form navbar-left">
                <ul class="nav nav-pills">
                    <li role="presentation"><a href=""><span>WARDEN</span></a></li>
                </ul>
            </div>
            <div class="navbar-form navbar-right">
                <ul class="nav nav-pills">
                    <li role="presentation">
                        <a id="nbutton" >Notifications</a>
                    </li>
                    <li role="presentation" >
                        <a id="loginButton">Login</a>
                    </li>
                </ul>
            </div>
        </div>
    <!-- /Top navigation -->
    <!-- Main -->
        <div class="main">
            <div class="col-md-3 col-sm-4" id="blist">
                    <div class="panel panel-beacons">
                        <div class="panel-heading">Beacons</div>
                        <div class="panel-body">
                                <div class ="scrollrow">
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
                                            OnRowCommand="PendingRecordsGridview_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Seen">
                                                    <ItemTemplate>
                                                        <asp:Button CommandArgument='<%# Bind("idn") %>' ID="seenButton" runat="server"
                                                            CausesValidation="false" CommandName="seen" Text="Seen" CssClass ="table" GridLines ="none"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ninfo" SortExpression="ninfo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ninfo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ninfo") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="idn" SortExpression="idn">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("idn") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("idn") %>'></asp:Label>
                                                    </EditItemTemplate>
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
                                        <asp:GridView runat="server" ID="AcceptedRecordsGridview" AutoGenerateColumns="true" 
                                            DataKeyNames="idn" CssClass ="table" GridLines ="none">
                                            <Columns>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>  
                </div>
            </div> 
         </div>
    <!-- Main -->
    <!-- Footer -->
        <div class="navbar navbar-default navbar-fixed-bottom footer">
            <div class="container-fluid text-center">
                <span class="navbar-text">Made by <b>WARDEN</b>. All rights reserved.</span>
            </div>
        </div>
    <!-- /Footer -->
   </form>
</body>
</html>
