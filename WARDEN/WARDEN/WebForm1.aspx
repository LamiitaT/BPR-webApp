<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WARDEN.WebForm1" %>

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
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css?version = 3"/>
    
     
    <script src="Scripts/jquery-3.1.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
      <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
 
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container main"></div>
        <div class="container-fluid top">
          </div> 
         <div class="container-fluid mid">
                  
                  <div class="row listrow">
                  
                       <ul class="nav nav-pills">
                           <li role="presentation" ><a href="LogIn.aspx"><img src="Screenshot_9.png" /></a></li>
                           <li role="presentation"><a href="#"><span>Settings</span></a></li>
                           <li role="presentation"><a href="OrderList.aspx"><span>View List</span></a></li>
                           <li role="presentation"><a href="#"><span>About</span></a></li>
                        </ul>
                 </div>
             <div class="col-md-3 lista">
                 <div class="panel">
                     <div class="panel-heading">denumire</div>
                     <div class="panel-body">
                         <div class="col-md-12">
                             <div class="row scrollrow">
                                 
                                     <div id="scrollrow">
                                       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CssClass="table" ShowHeaderWhenEmpty="True">
                                         <Columns>
                                             <asp:BoundField DataField="Longi" HeaderText="Longi" SortExpression="Longi" />
                                             <asp:BoundField DataField="Lati" HeaderText="Lati" SortExpression="Lati" />
                                             <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                             <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />

                                         </Columns>
                                     </asp:GridView>
                                     </div>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-md-9 mapa"></div>
            </div>
        <div class="container-fluid bot"></div>
        
    </div>
    </form>
</body>
</html>
