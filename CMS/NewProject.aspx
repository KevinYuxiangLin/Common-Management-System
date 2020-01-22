<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="CMS.NewProject" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div style="font-size:14px">
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Create a New Project!"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Project Name: "></asp:Label>
            <asp:TextBox ID="ProjectNameTxtBox" runat="server" cssclass="txtbox"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-default" OnClick="SaveButton_Click" Text="Save" />
            <asp:Button ID="CancelButton" runat="server" CssClass="btn btn-default" OnClick="CancelButton_Click" Text="Cancel"/>
        </div>
</asp:Content>
