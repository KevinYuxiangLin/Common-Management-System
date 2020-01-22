<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewList.aspx.cs" Inherits="CMS.NewList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-size:14px">
        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Create a New List!"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="List Name: "></asp:Label>
        <asp:TextBox ID="NewListNameTxtBox" runat="server" CssClass="txtbox"></asp:TextBox>
        <br />
        <br />
        Project :
            <asp:DropDownList ID="ProjectDropDownList" CssClass="txtbox" runat="server">
            </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-default" OnClick="SaveButton_Click" Text="Save" />
        <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-default" OnClick="CancelButton_Click" Text="Cancel" />
    </div>
</asp:Content>
