<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionPage.aspx.cs" Inherits="BasicQuizASPNET_v1_.questionPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 321px">
    
        <asp:Label ID="lblQuestion" runat="server" 
            style="z-index: 1; left: 13px; top: 64px; position: absolute" 
            Text="lblQuestion" Height="70px" Width="150px"></asp:Label>
        <asp:Label ID="lblResult" runat="server" 
            style="z-index: 1; left: 259px; top: 67px; position: absolute; height: 66px; width: 161px" 
            Text="lblResult" Visible="False"></asp:Label>
        <asp:Label ID="lblScore" runat="server" 
            style="z-index: 1; left: 464px; top: 65px; position: absolute" 
            Text="lblScore" Visible="False"></asp:Label>
        <asp:Label ID="lblAverageScore" runat="server" 
            style="z-index: 1; left: 462px; top: 93px; position: absolute" 
            Text="lblAverageScore" Visible="False"></asp:Label>
        <asp:Button ID="btnExit" runat="server" 
            style="z-index: 1; left: 61px; top: 285px; position: absolute; width: 86px" 
            Text="Exit" Visible="False" onclick="btnExit_Click" />
        <asp:Button ID="btnNext" runat="server" 
            style="z-index: 1; left: 66px; top: 286px; position: absolute; width: 87px" 
            Text="Next" onclick="btnNext_Click" />
    
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:quiz1ConnectionString %>" 
            SelectCommand="SELECT [UserID], [QuestionDescription], [UserAnswerDescription], [CorrectAnswerDescription], [UserQuestionScore] FROM [UserScore]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:quiz1ConnectionString %>" 
            SelectCommand="SELECT [QuestionDescription], [CorrectAnswerDescription] FROM [Question]">
        </asp:SqlDataSource>
    
        <asp:Label ID="lblMessage" runat="server" 
            style="z-index: 1; left: 688px; top: 70px; position: absolute" 
            Text="lblMessage" Visible="False"></asp:Label>
    
        <asp:RadioButton ID="radioButton1" runat="server" 
            
            
            style="z-index: 1; left: 29px; top: 156px; position: absolute; bottom: 150px;" 
            GroupName="Answers" />
        <asp:RadioButton ID="radioButton2" runat="server" 
            style="z-index: 1; left: 29px; top: 190px; position: absolute" 
            GroupName="Answers" />
        <asp:RadioButton ID="radioButton3" runat="server" 
            style="z-index: 1; left: 29px; top: 227px; position: absolute" 
            GroupName="Answers" />
    
        <asp:Label ID="lblExit" runat="server" Font-Size="X-Large" 
            style="z-index: 1; left: 242px; top: 183px; position: absolute" 
            Text="Goodbye!!" Visible="False"></asp:Label>
    
        <asp:GridView ID="dataGridView1" runat="server" 
            
            
            style="z-index: 1; left: 250px; top: 150px; position: absolute;  width: 656px" 
            AutoGenerateColumns="False" DataSourceID="SqlDataSource2" 
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
            CellPadding="5" CellSpacing="2">
            <Columns>
                <asp:BoundField DataField="QuestionDescription" HeaderText="Question Description" 
                    SortExpression="QuestionDescription" >
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserAnswerDescription" 
                    HeaderText="User Answer" SortExpression="UserAnswerDescription" >
                <ControlStyle Width="300px" />
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="CorrectAnswerDescription" 
                    HeaderText="Correct Answer" 
                    SortExpression="CorrectAnswerDescription" >
                <ControlStyle Width="200px" />
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="UserQuestionScore" HeaderText="Score" 
                    SortExpression="UserQuestionScore" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
