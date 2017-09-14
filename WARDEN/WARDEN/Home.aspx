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
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css?version = 13"/>
    
     
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#ntoggle').click(function () {
                if ($(this).data('name') == 'show') {
                    $("#nlist").animate({
                        width: '0%'
                    }).hide()
                    $("#map").animate({
                        width: '100vh'
                    });
                    $(this).data('name', 'hide')
                } else {
                    $("#nlist").animate({
                        width: '19%'
                    }).show()
                    $("#map").animate({
                        width: '80%'
                    });
                    $(this).data('name', 'show')
                }
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
                        <a id="ntoggle" data-name="" >Notifications</a>
                    </li>
                    <li role="presentation" class ="Login"><a href=""><span>Login</span></a>

                    </li>
                </ul>
            </div>
        </div>
    <!-- /Top navigation -->
    <!-- Main -->
        <div class="main">
            <div class="col-md-3 col-sm-4 blist">
                    <div class="panel">
                        <div class="panel-heading">denumire</div>
                        <div class="panel-body">
                                <div id="scrollrow">
                                    <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="true" CssClass="table" ShowHeaderWhenEmpty="True">
                                        <Columns>
                                            <asp:BoundField DataField="something" HeaderText="something" SortExpression="somehitng" />
                                            <asp:BoundField DataField="Ordrenr" HeaderText="Ordrenr" SortExpression="Ordrenr" />
                                            <asp:BoundField DataField="Kundenavn" HeaderText="Kundenavn" SortExpression="Kundenavn" />
                                            <asp:BoundField DataField="Varenr" HeaderText="Varenr" SortExpression="Varenr" />
                                            <asp:BoundField DataField="Tegningsnr" HeaderText="Tegningsnr" SortExpression="Tegningsnr" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                    </div>
            </div>
            <div class="col-md-9 col-sm-8 map">

            </div>
             <div id="nlist">

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
