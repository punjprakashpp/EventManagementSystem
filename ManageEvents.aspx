<%@ Page Title="Admin - Manage Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ManageEvents.aspx.cs" Inherits="ManageEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Events</h2>

    <!-- Add/Edit Event Form -->
    <div class="card p-3 mb-3">
        <h4>Add/Edit Event</h4>
        <asp:HiddenField ID="hfEventID" runat="server" />
        <div class="mb-2">
            <label>Event Name</label>
            <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label>Date</label>
            <asp:TextBox ID="txtEventDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label>Location</label>
            <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label>Description</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:Button ID="btnSave" runat="server" Text="Save Event" CssClass="btn btn-success" OnClick="btnSave_Click" />
    </div>

    <!-- Events List -->
    <h4>Existing Events</h4>
    <asp:GridView ID="gvEvents" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowCommand="gvEvents_RowCommand">
        <Columns>
            <asp:BoundField DataField="EventID" HeaderText="ID" />
            <asp:BoundField DataField="EventName" HeaderText="Event Name" />
            <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="Location" HeaderText="Location" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditEvent" CommandArgument='<%# Eval("EventID") %>' CssClass="btn btn-warning btn-sm" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteEvent" CommandArgument='<%# Eval("EventID") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>