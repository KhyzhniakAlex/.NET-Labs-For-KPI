<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarInOrdersPage.aspx.cs" MasterPageFile="~/Site.Master"  Inherits="WebFormsClient.CarInOrdersPage" %>

<asp:Content ID="ShiftPage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>CarInOrders list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater ID="Repeater" runat="server" onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <br />
                    <span>CarId: <%#Eval("CarId") %></span>
                    <br />
                    <span>OrderId: <%#Eval("OrderId") %></span>
                </div>
                <asp:Button ID="test" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Delete"></asp:Button>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>