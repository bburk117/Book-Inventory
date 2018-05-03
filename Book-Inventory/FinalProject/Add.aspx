<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="FinalProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group Project - Book Inventory</title>
    <meta name="description" content="Group Project, Book Inventory" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" /> 
    <script src="scripts/jquery-3.3.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div><!--
        <aside>
            <div class="col-md-12">
                <h1><asp:Label ID="lblNavigation" runat="server" Text="Navigation"></asp:Label></h1>
            </div>
            <div class="col-md-12 topBtn">
                <asp:Button ID="btnAdd" runat="server" Text="Add" Width="45%" CssClass="btn btn-success"/>
            </div>
            <br />
            <div class="col-md-12">
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="45%" CssClass="btn btn-success"/>
            </div>
            <br />
            <div class="col-md-12">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="45%" CssClass="btn btn-success"/>
            </div>
            <br />
            <div class="col-md-12 bottomBtn">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="45%" CssClass="btn btn-success" />
            </div>
        </aside>
        -->
        <div class="col-md-12">
            <h1>
                <asp:Label ID="lblAdd" runat="server" Text="Add Inventory:"></asp:Label>
            </h1>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <b><asp:Label ID="lblTitle" runat="server" Text="Title: "></asp:Label></b>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="textTitle" Dispaly="Dynamic" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>        
            <div class="col-md-12">
                <asp:TextBox ID="textTitle" runat="server" CssClass="form-control" OnTextChanged="textTitle_TextChanged"></asp:TextBox>            
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="col-md-12">
                <b><asp:Label ID="lblFirstName" runat="server" Text="Author's First Name: "></asp:Label></b>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="textFirstName" Dispaly="Dynamic" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="textFirstName" runat="server" CssClass="form-control" OnTextChanged="textFirstName_TextChanged"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="col-md-12">
                <b><asp:Label ID="lblLastName" runat="server" Text="Author's Last Name: "></asp:Label></b>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="textLastName" Dispaly="Dynamic" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-12">
                <asp:TextBox ID="textLastName" runat="server" CssClass="form-control" OnTextChanged="textLastName_TextChanged"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="form-group">
            <div class="col-md-12">
                <b><asp:Label ID="lblCategory" runat="server" Text="Category: " ></asp:Label></b>
                <asp:Label ID="lblCategoryOptional" runat="server" Text="(optional)"></asp:Label> 
                <asp:CheckBoxList ID="cbCategory" runat="server" BackColor="beige"
                 ForeColor="black" RepeatColumns="5">
                    <asp:ListItem>Fiction</asp:ListItem>
                    <asp:ListItem>Non-Fiction</asp:ListItem>
                    <asp:ListItem>AutoBiography</asp:ListItem>
                    <asp:ListItem>Biography</asp:ListItem>
                    <asp:ListItem>Children's</asp:ListItem>
                    <asp:ListItem>Comedy</asp:ListItem>
                    <asp:ListItem>Drama</asp:ListItem>
                    <asp:ListItem>Fantasy</asp:ListItem>
                    <asp:ListItem>Foreign</asp:ListItem>
                    <asp:ListItem>History</asp:ListItem>
                    <asp:ListItem>Horror</asp:ListItem>
                    <asp:ListItem>Religious</asp:ListItem>
                    <asp:ListItem>Romance</asp:ListItem>
                    <asp:ListItem>Sci-Fi</asp:ListItem>
                    <asp:ListItem>Self-Help</asp:ListItem>
                    <asp:ListItem>Suspense</asp:ListItem>
                    <asp:ListItem>Textbook</asp:ListItem>
                    <asp:ListItem>Thriller</asp:ListItem>
                </asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-md-12">
                    <b><asp:Label ID="lblRating" runat="server" Text="Rating: "></asp:Label></b>
                    <asp:Label ID="lblRatingOptional" runat="server" Text="(optional)"></asp:Label>
                </div>
                <div class="col-md-12">
                    <asp:DropDownList ID="DropDownQuestNum" runat="server" CssClass="form-control">
                        <asp:ListItem Value="N/A"></asp:ListItem>
                        <asp:ListItem Value="0"></asp:ListItem>
                        <asp:ListItem Value="0.5"></asp:ListItem>
                        <asp:ListItem Value="1.0"></asp:ListItem>
                        <asp:ListItem Value="1.5"></asp:ListItem>
                        <asp:ListItem Value="2.0"></asp:ListItem>
                        <asp:ListItem Value="2.5"></asp:ListItem>
                        <asp:ListItem Value="3.0"></asp:ListItem>
                        <asp:ListItem Value="3.5"></asp:ListItem>
                        <asp:ListItem Value="4.0"></asp:ListItem>
                        <asp:ListItem Value="4.5"></asp:ListItem>
                        <asp:ListItem Value="5.0"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="form-group">
                <div class="col-md-12">
                    <b><asp:Label ID="lblIsbn" runat="server" Text="ISBN: "></asp:Label></b>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="textIsbn" Dispaly="Dynamic" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-12">
                    <asp:TextBox ID="textIsbn" runat="server" CssClass="form-control" OnTextChanged="textIsbn_TextChanged"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <b>
                            <asp:Label ID="lbl_format" runat="server" Text="Book Format:"></asp:Label></b>
                        <asp:RadioButtonList ID="rblst_format" runat="server">
                            <asp:ListItem Selected="True">Paperback</asp:ListItem>
                            <asp:ListItem>Hardback</asp:ListItem>
                            <asp:ListItem>Ebook</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-md-12">
                <asp:Label ForeColor="Red" ID="lbl_error" runat="server"></asp:Label>
            </div>
            <br />
            <div class="col-md-12">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
                &nbsp;
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-success" OnClick="btnClear_Click" />
            </div>
        <div class="col-md-12">
            <asp:Label ID="lbl_result" runat="server"></asp:Label>
            </div>
            <br />
            <br />
        <div class="col-md-12">
            <h4><a href="OptionsMenu.aspx" title="Home">Back to Options</a></h4>
            </div>
            <br />
    </div>
    </form>
</body>
</html>
