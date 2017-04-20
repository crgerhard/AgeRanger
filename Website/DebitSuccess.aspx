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
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="standard">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Fist Name</td>
                    <td>
                        <input id="txtFirstName" type="text" />
                    </td>
                    <td>Last Name</td>
                    <td>
                        <input id="txtLastName" type="text" />
                    </td>
                    <td>Age</td>
                    <td>
                        <input id="txtAge" type="text" />
                    </td>
                    <td>
                        <input id="btnAdd" type="button" value="Add / Update" />
                    </td>
                    <td>
                        <input id="btnDelete" type="button" value="Delete" />
                    </td>
                    <td>
                        <input id="btnReset" type="button" value="Reset" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>Search:</td>
                </tr>
                <tr>
                    <td>Fist Name</td>
                    <td>
                        <input id="txtSearchFirstName" type="text" />
                    </td>
                    <td>Last Name</td>
                    <td>
                        <input id="txtSearchLastName" type="text" />
                    </td>
                    <td>
                        <input id="btnSearch" type="button" value="Search" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </div>
        <table id="results" class="display dynatable" width="100%">
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
    </form>
</body>
</html>
