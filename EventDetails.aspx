<%@ Page Title="Event Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EventDetails.aspx.cs" Inherits="EventDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Event Details</h2>
    <p><strong>Event Name:</strong> <asp:Label ID="lblEventName" runat="server" /></p>
    <p><strong>Date:</strong> <asp:Label ID="lblEventDate" runat="server" /></p>
    <p><strong>Location:</strong> <asp:Label ID="lblLocation" runat="server" /></p>
    <p><strong>Description:</strong> <asp:Label ID="lblDescription" runat="server" /></p>
    <asp:Button ID="btnRegister" runat="server" Text="Register for Event" CssClass="btn btn-success" OnClick="btnRegister_Click" />
</asp:Content>