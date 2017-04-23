<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DebitSuccess.aspx.cs" Inherits="DebitSuccess" %>

<!DOCTYPE html>

<script type="text/javascript" src="//code.jquery.com/jquery-1.12.4.js"></script>
<script src="Scripts/DebitSuccess.js"></script>
<script src="Scripts/jquery.dynatable.js"></script>
<link href="Css/jquery.dynatable.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        table {
            border-collapse: collapse;
            font-family: Calibri
        }

        .details {
            margin: auto;
            width: 80%;
            min-width: 830px;
        }

        .search {
            padding-bottom: 10px;
        }

        .number {
            width: 40px;
        }

        h3 {
            border-bottom: 1px solid #0094ff;
        }

        .buttonNew {
            border-radius: 3px;
            background-color: cornflowerblue;
            border: none;
            color: white;
            text-align: center;
            width: 70px;
            height: 22px;
            cursor: pointer;
        }

        .buttonEdit {
            border-radius: 3px;
            background-color: grey;
            border: none;
            color: white;
            text-align: center;
            width: 70px;
            height: 22px;
            cursor: pointer;
        }

        .buttonDisabled {
            opacity: 0.6;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="details">
            <div>
                <h3>Person details:</h3>
                <table class="standard">
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Fist Name:
                            <input id="txtFirstName" type="text" />
                        </td>
                        <td>Last Name:
                            <input id="txtLastName" type="text" />
                        </td>
                        <td>Age:
                            <input id="txtAge" type="text" class="number" />
                        </td>
                        <td>
                            <input id="btnReset" type="button" value="Reset" class="edit buttonEdit" />
                        </td>
                        <td>
                            <input id="btnDelete" type="button" value="Delete" class="edit buttonEdit" />
                        </td>
                        <td>
                            <input id="btnUpdate" type="button" value="Update" class="edit buttonEdit" />
                        </td>
                        <td>
                            <input id="btnAdd" type="button" value="Add" class="new buttonNew" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="search">
                <h3>Search:</h3>
                <table>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>First Name:</td>
                        <td>
                            <input id="txtSearchFirstName" type="text" />
                        </td>
                        <td>Last Name:</td>
                        <td>
                            <input id="txtSearchLastName" type="text" />
                        </td>
                        <td>
                            <input id="btnSearch" type="button" value="Search" class="buttonNew" />
                        </td>
                    </tr>
                </table>
            </div>
            <table id="results" class="results dynatable" width="100%">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Age</th>
                        <th>Age Group</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>

            </table>
        </div>
    </form>
</body>
</html>
