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
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css?version = 6"/>
    
     
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
      <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
 
    
</head>
<body>
    <form id="form1" runat="server">
        <!-- Top navigation -->
        <div class="navbar navbar-default navbar-fixed-top header">
                <div class="container-fluid" >
                    <a class="navbar-brand" href="Home.aspx" ><b>WARDEN</b></a> 
                </div>
        </div>
        <!-- /Top navigation -->
        <!-- Main -->
        <div class="responsive-container main">
        <div class="container-fluid">
            <div class="col-xs-2">
                <div class="list-current">
                    <div class="panel">
                        <div class="panel-heading">denumire</div>
                        <div class="panel-body"></div>
                    </div>
                 </div>
            </div>
            <div class="col-xs-10">
                <div class="map">

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
