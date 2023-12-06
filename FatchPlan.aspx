<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FatchPlan.aspx.cs" Inherits="FatchPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, shrink-to-fit=no">
<link href="images/favicon.png" rel="icon" />
<title>Recharge & Bill Payment, Booking HTML5 Template</title>
<meta name="description" content="Quickai - Recharge & Bill Payment, Booking HTML5 Template">
<meta name="author" content="harnishdesign.net">

<!-- Web Fonts
============================================= -->
<link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap" rel="stylesheet">

<!-- Stylesheet
============================================= -->
<link rel="stylesheet" type="text/css" href="FatchPlanScript/vendor/bootstrap/css/bootstrap.min.css" />
<link rel="stylesheet" type="text/css" href="FatchPlanScript/vendor/font-awesome/css/all.min.css" />
<link rel="stylesheet" type="text/css" href="FatchPlanScript/vendor/owl.carousel/assets/owl.carousel.min.css" />
<link rel="stylesheet" type="text/css" href="FatchPlanScript/css/stylesheet.css" />
<%--<link id="color-switcher" type="text/css" rel="stylesheet" href="#" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<div id="main-wrapper"> 
<!-- Modal Dialog - View Plans
============================================= -->
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Browse Plans</h5>
          <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div class="row g-3 mb-4">
          <div class="col-12 col-sm-6 col-lg-3">
              <asp:DropDownList ID="ddlCircle" class="form-select"  required="" runat="server">
                  <asp:ListItem>Select Your Circle</asp:ListItem>
              </asp:DropDownList>
          </div>
          <div class="col-12 col-sm-6 col-lg-3">
                <asp:DropDownList ID="ddlOperator" class="form-select"  required="" runat="server">
                    <asp:ListItem>Select Your Operator</asp:ListItem>
                </asp:DropDownList>
          </div>
          <div class="col-12 col-sm-6 col-lg-3"> 
              <asp:TextBox ID="txtmobile" class="form-control" MaxLength="10" placeholder="Enter Your Mobile No" required="" runat="server"></asp:TextBox>
          </div>
          <div class="col-12 col-sm-6 col-lg-3 d-grid">
                <asp:Button ID="Button1" runat="server" class="btn btn-primary" OnClick="Button1_Click" Text="View Plans" />
          </div>
              <div style="text-align: center;">
                  <asp:Label ID="lblmsg" ForeColor="Red" runat="server" Text=""></asp:Label>
              </div>
        </div>
        <div runat="server" id="test2" class="plans">
        </div>
      </div>
    </div>
<!-- Modal Dialog - View Plans end --> 
</div>
    <!-- Fatch Recharge Plan --> 
            <div runat="server" id="test1"></div> 
        </div>
        <!-- Script --> 
<script src="FatchPlanScript/vendor/jquery/jquery.min.js"></script> 
<script src="FatchPlanScript/vendor/bootstrap/js/bootstrap.bundle.min.js"></script> 
<script src="FatchPlanScript/vendor/owl.carousel/owl.carousel.min.js"></script> 
<script src="FatchPlanScript/js/switcher.min.js"></script>
<script src="FatchPlanScript/js/theme.js"></script>
    </form>
</body>
</html>
