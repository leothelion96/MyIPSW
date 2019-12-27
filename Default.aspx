﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyIPSWMinimal.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="Leonard Wong, MyIPSW" />
    <title>MyIPSW</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <style>
    </style>
</head>

<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">MyIPSW</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item active">
        <a class="nav-link" href="Default.aspx">Firmware</a>
      </li>
    </ul>
  </div>
</nav>
<body>
    <form id="form1" runat="server">
        <div class="container" style="background-color:#f5f5f5">
        <div class="row">
            <div class="col-sm" style="margin-top: 30px">
                <h4>Step 1</h4>
                <div class="row">
                    <asp:RadioButtonList ID="rblOptions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblOptions_SelectedIndexChanged">
                        <asp:ListItem>Official</asp:ListItem>
                        <asp:ListItem>OTA</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <br />
                

            </div>

            <div class="col-sm" style="margin-top:30px;">
                <h4>
                    <asp:Label ID="lblStep2" runat="server" Text="Step 2"></asp:Label>
                </h4>
                <br />
                <div class="row">
                    <asp:DropDownList ID="ddliPhone" runat="server" OnSelectedIndexChanged="ddliPhone_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Text="Select iPhone Model" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />
                <div class="row">
                    <asp:DropDownList ID="ddliPad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddliPad_SelectedIndexChanged">
                        <asp:ListItem Text="Select iPad Model" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                 <br />
                <div class="row">
                    <asp:DropDownList ID="ddliPod" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddliPod_SelectedIndexChanged">
                        <asp:ListItem Text="Select iPod Model" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />
                <div class="row">
                    <asp:DropDownList ID="ddlWatch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWatch_SelectedIndexChanged">
                        <asp:ListItem Text="Select Apple Watch Model" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />
                <div class="row">
                    <asp:DropDownList ID="ddlAudioAccessory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAudioAccessory_SelectedIndexChanged">
                        <asp:ListItem Text="Select HomePod Model" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="row">
                    <asp:DropDownList ID="ddlAppleTV" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAppleTV_SelectedIndexChanged">
                        <asp:ListItem Text="Select Apple TV Model" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-sm" style="margin-top: 30px;">
                <h4>
                    <asp:Label ID="lblStep3" runat="server" Text="Step 3"></asp:Label></h4>
                <br />
                <asp:Label ID="lblSelectionComment" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblSelection" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnRetrieve" runat="server" OnClick="btnRetrieve_Click" />
            </div>

        </div>

        <div class="row">
            <div class="col-sm">
                
                <asp:Table ID="tblData" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="3" GridLines="Both" class="table table-dark" style="width:100%;text-align:center;">
                </asp:Table>
                
            </div>
        </div>

    </div>
    <br />
    </form>
</body>
</html>
