<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarPage.aspx.cs" Inherits="WebFormsClient.CarPage" MasterPageFile="~/Site.Master"%>
<%@ Import Namespace="WcfRestService.DTOModels" %>

<asp:Content ID="CarPage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Cars list </h1>
        <asp:Button runat="server" class='btn btn-warning' OnClick="OnClick" Text="Create" role='button'></asp:Button>
        <hr>
        <asp:Repeater ID="Repeater" runat="server" onitemcommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div>
                    <span>Id: <%#Eval("Id") %></span>
                    <h5>Brand: <%#Eval("Brand") %></h5>
                    <h5>Model:  <%#Eval("Model") %></h5>
                    <h6>SerialNumber:  <%#Eval("SerialNumber") %></h6>
                    <h6>Color:  <%#Eval("Color") %></h6>
                    <h6>Price:  <%#Eval("Price") %></h6>
                    <h6>Manufacturer:  <%#Eval("Manufacturer") %></h6>
                </div>
                <asp:Button ID="test" runat="server" CommandName="Update" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Update"></asp:Button>
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' class='btn btn-info' Text="Delete"></asp:Button>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>