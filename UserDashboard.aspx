<%@ Page Title="User Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UserDashboard.aspx.cs" Inherits="UserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome, <%= Session["FullName"] %>!</h2>
    
    <h3>Upcoming Events</h3>
    <asp:GridView ID="gvUpcomingEvents" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="EventName" HeaderText="Event Name" />
            <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="Location" HeaderText="Location" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success"
                        CommandArgument='<%# Eval("EventID") %>' OnClick="btnRegister_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h3>Your Registered Events</h3>
    <asp:GridView ID="gvRegisteredEvents" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="EventName" HeaderText="Event Name" />
            <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="Location" HeaderText="Location" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>