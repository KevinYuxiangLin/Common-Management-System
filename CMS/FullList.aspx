<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FullList.aspx.cs" Inherits="CMS.FullList" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="FullListGridView" runat="server" AutoGenerateColumns="false" BorderWidth="0" GridLines="None">
        <%--<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#BFE4FF" />--%>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CompleteCheck" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TaskId" HeaderText="Task Id" ItemStyle-Width="50" />
            <asp:BoundField DataField="ProjectName" HeaderText="Project Name" ItemStyle-Width="100" />
            <asp:BoundField DataField="TaskListName" HeaderText="Task List Name" ItemStyle-Width="100" />
            <asp:BoundField DataField="TaskName" HeaderText="Task Name" ItemStyle-Width="100" />
            <asp:BoundField DataField="PriorityName" HeaderText="Priority" ItemStyle-Width="50" />
            <asp:BoundField DataField="DueDate" HeaderText="Due Date" ItemStyle-Width="100" />
            <asp:BoundField DataField="Progress" HeaderText="Progress" ItemStyle-Width="50" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnChk" runat="server" CssClass="btn btn-default" Text="Change Progress" OnClick="btnChk_Click" />


</asp:Content>
