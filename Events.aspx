<%@ Page Title="Upcoming Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Upcoming Events</h2>
        <asp:GridView ID="gvEvents" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="EventName" HeaderText="Event Name" />
                <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:HyperLinkField DataNavigateUrlFields="EventID" DataNavigateUrlFormatString="EventDetails.aspx?EventID={0}"
                    Text="View Details" HeaderText="Details" />
            </Columns>
        </asp:GridView>
</asp:Content>
