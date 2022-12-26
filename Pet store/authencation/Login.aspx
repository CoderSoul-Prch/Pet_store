<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pet_store.authencation.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />


    <div class="box">
        <h1> Login </h1>
       <div class="login_body">
            <div class="username">
            <asp:Label ID="Label1"  runat="server" Text="User name : "></asp:Label>
            <asp:TextBox ID="usernameTextBox1" CssClass="userlbl" runat="server"></asp:TextBox>
        </div>
        <div class="password">
            <asp:Label ID="Label2"  runat="server" Text="Password : "></asp:Label>
           <asp:TextBox ID="passwordTextBox2" CssClass="passlbl" runat="server"></asp:TextBox>
            <br />
        </div>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me" />
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
           <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </div>
        
    </div>



</asp:Content>
