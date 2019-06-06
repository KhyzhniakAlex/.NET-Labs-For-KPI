<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarInOrderCreatePage.aspx.cs" Inherits="WebFormsMsMqClient.CarInOrderCreatePage"  MasterPageFile="~/Site.Master"%>

<asp:Content ID="CarInOrderCreatePage" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label" runat="server" Text=""></asp:Label>
    </div>
    <label>Select car</label>
    <asp:DropDownList ID="dropdownCar" runat="server" ></asp:DropDownList><br />
    <label>Select order</label>    
    <asp:DropDownList ID="dropdownOrder" runat="server" ></asp:DropDownList><br />


    <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
    <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>
