<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CMS.ContactUs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <address>
        4 Parkway<br />
        Kanata, Ontario<br />
        <abbr title="Phone">Phone:</abbr>
        613-123-4567
    </address>

    <address>
        <strong>Website App Designer (Kevin Lin) :</strong>   <a href="mailto:kevin.yx.lin@gmail.com">kevin.yx.lin@gmail.com</a><br />
        <strong>Desktop App Designer (Andy Li) :</strong> <a href="mailto:ali4@ocdsb.ca">ali4@ocdsb.ca</a>
    </address>
</asp:Content>
