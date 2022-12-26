<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Pet_store.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" />

    <div class="box">
        <div class="wf1">
            <h1>Pet Vet</h1>
            <p>Visit us to meet furry friends. </p>
            <img src="Image/cartoon_animals.png" class="img" style="vertical-align: middle" />
        </div>
        <div class="wf2">
            <h1 class="H1">Create Account</h1>
            <p>Please fill in this form to create an account</p>
            <div class="form">
                <div class="txtbox">
                    <asp:Label ID="Label1" runat="server" Text="User Name : " ForeColor="White"> </asp:Label>
                    <asp:TextBox ID="usernameTextBox1" CssClass="usernameTextBox1" runat="server" BackColor="White" BorderColor="#FF99CC" BorderStyle="Groove" BorderWidth="2px" Font-Strikeout="False" Font-Underline="True"></asp:TextBox>
                </div>

                <div class="mno">
                    <asp:Label ID="Label2" runat="server" Text="Mobile Number : " ForeColor="White"></asp:Label>
                    <asp:TextBox ID="mnoTextBox1" runat="server" TextMode="Phone" MaxLength="10" BorderColor="#FF99CC" BorderStyle="Groove" BorderWidth="2px" CssClass="mnoTextBox1"></asp:TextBox>
                </div>

                <div class="email">
                    <asp:Label ID="Label3" runat="server" Text="Email Id : " ForeColor="White"></asp:Label>
                    <asp:TextBox ID="emailTextBox1" runat="server" TextMode="Email" BorderColor="#66CCFF" BorderStyle="Groove" BorderWidth="2px" CssClass="emailTextBox1"></asp:TextBox>
                </div>

                <div class="password">
                    <asp:Label ID="Label4" runat="server" Text="Password : " ForeColor="White"></asp:Label>
                    <asp:TextBox ID="passTextBox1" runat="server"  BorderColor="#66CCFF" BorderStyle="Groove" BorderWidth="2px" CssClass="passwordTextBox1" ></asp:TextBox>
                </div>
              

                <div class="savebtn">
                    <asp:Button ID="Button1" class="button" runat="server" Text="Save" OnClick="Button1_Click" />
                </div>
                <asp:Label ID="conformationLabel6" runat="server" ForeColor="White"></asp:Label>
            </div>

            <label for="login"> Already have account? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/authencation/Login.aspx">Login</asp:HyperLink> </label>

        </div>
    </div>
</asp:Content>
