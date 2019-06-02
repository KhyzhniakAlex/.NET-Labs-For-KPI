<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="WebFormsMsMqClient.OrderPage" MasterPageFile="~/Site.Master"%>
<%@ Import Namespace="WcfRestService.DTOModels" %>

<asp:Content ID="OrderPage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Orders list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater ID="Repeater" runat="server" onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <h5>StartDate: <%#Eval("StartDate") %></h5>
                    <h5>EndDate:  <%#Eval("EndDate") %></h5>
                    <h6>Sum:  <%#Eval("Sum") %></h6>
                    <h6>Manager:  <%#Eval("Manager") %></h6>
                    <h6>Customer:  <%#Eval("Customer") %></h6>
                </div>
                <asp:Button ID="test" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Delete"></asp:Button>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>