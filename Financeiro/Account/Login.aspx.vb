Imports Microsoft.VisualBasic
Imports System.Web.Security
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class Login
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'RegisterHyperLink.NavigateUrl = "Register"       

        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not String.IsNullOrEmpty(returnUrl) Then
            'RegisterHyperLink.NavigateUrl &= "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Protected Sub LoginButton_Click1(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim retorno As New Result

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim objUsuario As New Result
                    objUsuario.txt_login = Trim(UserName.Text)
                    objUsuario.txt_senha = Trim(Password.Text)

                    Dim usuarioBO As New UsuarioBO
                    retorno = usuarioBO.ValidarAutenticacaoUsuario(objUsuario, MysqlTrans)

                    Conexao.CommitTransacao(MysqlTrans)

                    If retorno.txt_status.Equals("SUCESSO") Then
                        Dim w As New System.Web.UI.WebControls.AuthenticateEventArgs
                        w.Authenticated = True
                        FormsAuthentication.RedirectFromLoginPage(retorno.txt_login, False)

                        Session("cod_usuario") = retorno.cod_usuario
                        Session("txt_nome") = retorno.txt_nome

                        'Response.Redirect("~/Default.aspx")

                    ElseIf retorno.txt_status.Equals("FALHA") Then
                        LbResultado.Text = retorno.txt_mensagem
                    End If
                Catch ex As Exception
                    Conexao.RollBackTransacao(MysqlTrans)
                    Response.Write(ex.Source & "<br />" & ex.Message & "<br />" & ex.StackTrace)
                    Response.End()
                End Try
            End Using
        End Using
    End Sub
End Class