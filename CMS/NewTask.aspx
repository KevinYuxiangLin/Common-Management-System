<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewTask.aspx.cs" Inherits="CMS.NewTask" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-size: 14px;">
        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Create a New Task!"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Task Name: "></asp:Label>
        <asp:TextBox ID="NewTaskNameTxtBox" CssClass="txtbox" runat="server" Width="193px"></asp:TextBox>
        <br />
        <br />
        Choose Project:
            <asp:DropDownList ID="ProjectDropDownList" CssClass="txtbox" runat="server" OnSelectedIndexChanged="Selected_Changed" AutoPostBack="True">
            </asp:DropDownList>
        <br />
        <br />
        TaskList:
            <asp:DropDownList ID="DropDownList1" CssClass="txtbox" runat="server">
            </asp:DropDownList>
        <br />
        <br />
        Task Priority:
            <asp:DropDownList ID="PriorityDropDownList" CssClass="txtbox" runat="server">
                <asp:ListItem>High</asp:ListItem>
                <asp:ListItem>Medium</asp:ListItem>
                <asp:ListItem Selected="True">Low</asp:ListItem>
            </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Date: "></asp:Label>
        <asp:TextBox ID="DateTextBox" CssClass="txtbox" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
    </div>
    <br />
    <div align="center">
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="FullMonth">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
        <br />
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-default" OnClick="SaveButton_Click" Text="Save" />
        <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-default" OnClick="CancelButton_Click" Text="Cancel" />
    </div>
</asp:Content>
