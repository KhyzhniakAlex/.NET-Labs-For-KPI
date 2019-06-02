<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CarCreatePage.aspx.cs" Inherits="WebFormsClient.CarCreatePage" %>

<asp:Content ID="CarCreatePage" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text=""></asp:Label>
        </div>
                <label>Input brand</label>
                <asp:TextBox ID="carBrand" runat="server" Text=""></asp:TextBox><br />
                <label>Input model</label>
                <asp:TextBox ID="carModel" runat="server" Text=""></asp:TextBox><br />
                <label>Input serial number</label>
                <asp:TextBox ID="carSerialNumber" runat="server" Text=""></asp:TextBox><br />
                <label>Input color</label>
                <asp:TextBox ID="carColor" runat="server" Text=""></asp:TextBox><br />
                <label>Input price</label>
                <asp:TextBox ID="carPrice" runat="server" Text=""></asp:TextBox><br />
                <label>Input manufacturer's name</label>
                <asp:TextBox ID="carManufacturer" runat="server" Text=""></asp:TextBox><br />
                <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>