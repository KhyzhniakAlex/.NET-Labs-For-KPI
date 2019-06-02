<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="ManufacturerCreatePage.aspx.cs" Inherits="WebFormsClient.ManufacturerCreatePage" %>


<asp:Content ID="ManufacturerCreatePage" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text=""></asp:Label>
        </div>
                <label>Input name</label>
                <asp:TextBox ID="manufacturerName" runat="server" Text=""></asp:TextBox><br />
                <label>Input office phone number</label>
                <asp:TextBox ID="manufacturerOfficePhoneNumber" runat="server" Text=""></asp:TextBox><br />
                <label>Input country</label>
                <asp:TextBox ID="manufacturerCountry" runat="server" Text=""></asp:TextBox><br />
                <asp:Button ID="btnCreate" runat="server" class='btn btn-info' Text="Create" OnClick="btnCreate_Click" />
                <asp:Button ID="btnUpdate" runat="server" class='btn btn-info' Text="Update" OnClick="btnUpdate_Click" />
</asp:Content>