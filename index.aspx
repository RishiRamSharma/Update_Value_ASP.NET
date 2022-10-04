<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="teacher_project.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Teacher&#39;s Details :-<br />
            <br />
            Id&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextId" runat="server"></asp:TextBox>
            <br />
            <br />
            Name&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextName" runat="server"></asp:TextBox>
            <br />
            <br />
            Subject&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextSub" runat="server"></asp:TextBox>
            <br />
            <br />
            Department&nbsp;:&nbsp;
            <asp:TextBox ID="TextDep" runat="server"></asp:TextBox>
            <br />
            <br />
            Show details :&nbsp;&nbsp;
            <asp:ListBox ID="ShowList" runat="server" Height="96px" Width="231px" AutoPostBack="True" OnSelectedIndexChanged="ShowList_SelectedIndexChanged"></asp:ListBox>
            <br />
            <br />
            <br />
            <asp:Button ID="save_btn" runat="server" Text="Save" OnClick="save_btn_Click" />
            <asp:Button ID="display_btn" runat="server" Text="Display" OnClick="display_btn_Click" />
            <asp:Button ID="update_btn" runat="server" Text="Update" OnClick="update_btn_Click" />
            <asp:Button ID="delete_btn" runat="server" Text="Delete" />
        </div>
    </form>
</body>
</html>
