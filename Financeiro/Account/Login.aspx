<%@ Page Title="Log in" Language="VB" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Financeiro.Login" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">             
        <link href="css/style.css" rel="stylesheet" />
    </head>

    <body>        
        <form runat="server">                        
            <div class="login">
	            <div class="login-screen">
		            <div class="app-title">
			            <h1><p><asp:Label ID="LbResultado" runat="server" Text="" Font-Bold="True" CssClass="failureNotification"></asp:Label></p></h1>
		            </div>                    
		            <div class="login-form">
			            <div class="control-group">			                			                
                            <asp:TextBox CssClass="login-field" ID="UserName" placeholder="Login" runat="server"></asp:TextBox>                       
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="Informe o login." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
			            </div>

			            <div class="control-group">			                                            
                            <asp:TextBox CssClass="login-field" ID="Password" placeholder="Senha" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Informe a senha." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup"></asp:RequiredFieldValidator>
			            </div>
			            
			            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Autenticar" ValidationGroup="LoginUserValidationGroup" CssClass="btn btn-primary btn-large btn-block" />
                        <p></p>
		            </div>
	            </div>
            </div>
        </form>        
        <script type="text/javascript">                   
            document.getElementById("UserName").focus();
        </script>
    </body>  
</html>