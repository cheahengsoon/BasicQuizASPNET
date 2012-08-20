<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BasicQuizASPNET_v1_._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Quiz Engine Splash Page</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divHeader" align="center" class="box1" 
        
        style="height: 272px; width: 700px; z-index: 100; left: 125px; top: 43px; position: absolute">
    
        <asp:Label ID="lblHeading" runat="server" Font-Size="Larger" 
            style="z-index: 1; left: 185px; top: 49px; position: absolute; height: 38px; width: 266px" 
            Text="Welcome to Basic Quiz"></asp:Label>
    
        <asp:Label ID="lblUserName" runat="server" 
            style="z-index: 1; left: 144px; top: 117px; position: absolute; height: 14px; width: 120px" 
            Text="User Name:"></asp:Label>

        <asp:Label ID="lblPassword" runat="server" 
            style="z-index: 1; left: 146px; top: 151px; position: absolute; height: 14px; width: 120px" 
            Text="Password:"></asp:Label>
    
        <asp:TextBox ID="txtUserName" runat="server" 
            
            style="z-index: 1; left: 301px; top: 111px; position: absolute; width: 183px" 
            ForeColor="Black"></asp:TextBox>

        <asp:TextBox ID="txtPassword" runat="server" 
        style="z-index: 1; left: 302px; top: 147px; position: absolute; width: 183px"></asp:TextBox>
    
        <asp:Button ID="btnEnter" runat="server" 
            style="z-index: 1; left: 218px; top: 204px; position: absolute; width: 210px; height: 45px" 
            Text="Enter Here" onclick="btnEnter_Click" />
        <asp:Button ID="btnTryAgain" runat="server" 
            style="z-index: 1; left: 151px; top: 218px; position: absolute; right: 466px" 
            Text="Try Again" Visible="False" onclick="btnEnter_Click" />
        <asp:Button ID="btnAddUser" runat="server" 
            style="z-index: 1; left: 276px; top: 217px; position: absolute" Text="Add User" 
            Visible="False" onclick="btnAddUser_Click" />
        <asp:Button ID="btnExit" runat="server" 
            style="z-index: 1; top: 217px; position: absolute; width: 78px; left: 392px" 
            Text="Exit" Visible="False" onclick="btnExit_Click"/>
    
        <asp:Label ID="lblMessage" runat="server" Font-Size="Small" 
            style="z-index: 1; left: 521px; top: 51px; position: absolute; width: 151px; height: 159px; text-align:left"  
            Text="lblMessage" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
