Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class UsuarioBO
    Public Function ValidarAutenticacaoUsuario(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result
        Dim usuarioDAO As New UsuarioDAO

        retorno = usuarioDAO.AutenticarUsuario(obj, MysqlTrans)

        If retorno.txt_status.Equals("FALHA") Then
            retorno.txt_mensagem = Mensagem.MN001.TextoFormatado("Usuário")
        End If

        Return retorno
    End Function
End Class
