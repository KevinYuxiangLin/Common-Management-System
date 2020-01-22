<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShareProject.aspx.cs" Inherits="CMS.ShareProject" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center" style="font-size:14px">
        <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="<u>Currently Shared Projects</u>"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="SharedGridView" runat="server" AutoGenerateColumns="false" BorderWidth="0" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CompleteCheck" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProjectId" HeaderText="Id" ItemStyle-Width="50" />
                <asp:BoundField DataField="ProjectName" HeaderText="Project Name" ItemStyle-Width="120" />
                <asp:BoundField DataField="OwnerName" HeaderText="Project Owner" ItemStyle-Width="120" />
                <asp:BoundField DataField="SharedByUsers" HeaderText="Shared UserName" ItemStyle-Width="150" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnChk" runat="server" CssClass="btn btn-default" Text="Undo Share" OnClick="btnChk_Click" />
    </div>
    <br />
    <br />
    <div style="font-size:14px">
        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="<u>Share a Project With Others!</u>"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Choose Project: "></asp:Label>
        Project :
            <asp:DropDownList ID="ProjectDropDownList" CssClass="txtbox" runat="server">
            </asp:DropDownList>
        <br />
        <br />

        <asp:Label ID="Label3" runat="server" Text="Choose User: "></asp:Label>
        User :
            <asp:DropDownList ID="UserDropDownList" CssClass="txtbox" runat="server">
            </asp:DropDownList>
        <br />
        <br />

        <asp:Button ID="SaveButton" CssClass="btn btn-default" runat="server" OnClick="SaveButton_Click" Text="Share" />
        <asp:Button ID="CancelButton" CssClass="btn btn-default" runat="server" OnClick="CancelButton_Click" Text="Cancel" />
    </div>
</asp:Content>
