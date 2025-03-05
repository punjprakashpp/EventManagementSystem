<%@ Page Title="Event Registrations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EventRegistrations.aspx.cs" Inherits="EventRegistrations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Event Registrations</h2>
    <asp:GridView ID="gvRegistrations" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="FullName" HeaderText="User Name" />
            <asp:BoundField DataField="EventName" HeaderText="Event" />
            <asp:BoundField DataField="RegistrationDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
        </Columns>
    </asp:GridView>
</asp:Content>
