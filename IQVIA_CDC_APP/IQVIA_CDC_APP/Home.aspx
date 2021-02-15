﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IQVIA_CDC_APP.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.23/css/jquery.dataTables.css">
  

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>


    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.13/css/jquery.dataTables.css">
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.js"></script>
  

    <title>CDC COVID-19 Death Count</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                </br>
                </br>

                <div class="row">
  <div class="col-2"></div>
  <div class="col-8"><h1 class="display-3">COVID-19 Death Count</h1></div>
  <div class="col-2"></div>
</div>
                </br>
                </br>

                <div class="row">
                <div class="col">
                    <ul class="list-group list-group-flush">
  <li class="list-group-item">Important Factors</li>
  <li class="list-group-item">1. Data of all states are not avaialble from the API</li>
  <li class="list-group-item">2. Percentage Calculated is from available data from provided states</li>
  <li class="list-group-item">3. Data of some US Minor Islands are also present</li>
  <li class="list-group-item">4. Data may be inacurate as submission date of provided states varies and not up to date</li>

  
</ul>
                </div>
                    <div class="col-8">
                       <div id="divDisplay" runat="Server">
      
    </div>

           <!-- <asp:GridView ID="cdcData" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-hover">

                <Columns>

                
                <asp:BoundField DataField="state" HeaderText="State" />


                <asp:BoundField DataField="submission_date" HeaderText="Date of Submission" />

                <asp:BoundField DataField="tot_death" HeaderText="Total Covid-19 Deaths" />

                    <asp:TemplateField HeaderText="% US Covid-19 Deaths"></asp:TemplateField>

            </Columns>

            </asp:GridView> -->
                        </div>
                    <div class="col">
                        <figure class="text-center">
                        <blockquote class="blockquote">
                        <!--<p>Please select state from dropdown to see data of specific state</p>
                        </br>
            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="btn btn-secondary btn-lg dropdown-toggle"></asp:DropDownList>-->
                        </blockquote>
                            <figcaption class="blockquote-footer">
    Please note not all states are available per CDC data
  </figcaption>
                            </br>
                            <asp:Button ID="btnRefresh" runat="server" Text="Data of all States" OnClick="btnRefresh_Click" CssClass="btn btn-success"/>

                            </figure>
                    </div>
                    </div>
                </div>
    </div>

    </form>
    <script src="Scripts/DataTables/jquery.dataTables.min.js"></script>


<script>
    $(document).ready(function () {
        $('#example').DataTable({
            "order": [[2, "desc"]]
        });
    });
</script>
</body>
</html>
