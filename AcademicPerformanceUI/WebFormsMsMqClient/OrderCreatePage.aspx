<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="OrderCreatePage.aspx.cs" Inherits="WebFormsMsMqClient.OrderCreatePage" %>


<asp:Content ID="OrderCreatePage" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text=""></asp:Label>
        </div>
                <label>Input start date</label>
                <asp:TextBox ID="orderStartDate" runat="server" Text=""></asp:TextBox><br />
                <label>Input end date</label>
                <asp:TextBox ID="orderEndDate" runat="server" Text=""></asp:TextBox><br />
                <label>Input sum</label>
                <asp:TextBox ID="orderSum" runat="server" Text=""></asp:TextBox><br />
                <label>Input manager's surname</label>
                <asp:TextBox ID="orderManagerId" runat="server" Text=""></asp:TextBox><br />
                <label>Input customer's surname</label>
                <asp:TextBox ID="orderCustomerId" runat="server" Text=""></asp:TextBox><br />
                <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>