<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentReadingList.aspx.cs" Inherits="FinalProject.CurrentReadingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Inventory - Current Reading List</title>
    <meta name="description" content="Group Project, Current Reading List" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" /> 
    <script src="scripts/jquery-3.3.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="col-md-12">
            <h1>
                <asp:Label ID="lblCurrentReads" runat="server" Text="Current Reading List:"></asp:Label>
            </h1>
        </div>
    </div>
    </form>
</body>
</html>
