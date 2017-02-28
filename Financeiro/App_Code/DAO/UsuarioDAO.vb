Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class UsuarioDAO
    Public Function AutenticarUsuario(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM tbl_usuario WHERE txt_login = ? AND txt_senha = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("txt_login", MySqlDbType.VarChar).Value = UCase(obj.txt_login)
            cmd.Parameters.Add("txt_senha", MySqlDbType.VarChar).Value = Trim(Seguranca.MD5(obj.txt_senha))

            Using dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        retorno.cod_usuario = dr("cod_usuario")
                        retorno.txt_login = dr("txt_login")
                        retorno.txt_senha = dr("txt_senha")
                        retorno.txt_nome = dr("txt_nome")                       
                    End While
                    retorno.txt_status = ResponseStatus.SUCESSO.Texto
                Else
                    retorno.txt_status = ResponseStatus.FALHA.Texto
                End If
            End Using
        End Using

        Return retorno
    End Function
End Class
