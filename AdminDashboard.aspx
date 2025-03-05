<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Dashboard</h2>

    <div class="row">
        <div class="col-md-4">
            <div class="card text-white bg-primary mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Events</h5>
                    <p class="card-text"><asp:Label ID="lblTotalEvents" runat="server"></asp:Label></p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card text-white bg-success mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Users</h5>
                    <p class="card-text"><asp:Label ID="lblTotalUsers" runat="server"></asp:Label></p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card text-white bg-warning mb-3">
                <div class="card-body">
                    <h5 class="card-title">Total Registrations</h5>
                    <p class="card-text"><asp:Label ID="lblTotalRegistrations" runat="server"></asp:Label></p>
                </div>
            </div>
        </div>
    </div>

    <h3>Quick Links</h3>
    <ul>
        <li><a href="ManageUsers.aspx" class="btn btn-secondary">Manage Users</a></li>
        <li><a href="EventRegistrations.aspx" class="btn btn-secondary">View Event Registrations</a></li>
        <li><a href="ManageEvents.aspx" class="btn btn-secondary">Manage Events</a></li>
    </ul>
</asp:Content>
