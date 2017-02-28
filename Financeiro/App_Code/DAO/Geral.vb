Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class Geral
    Public Shared Function ListaAnos(ByVal MysqlTrans As MySqlTransaction, Optional condicao As String = "") As DataTable

        If Not String.IsNullOrWhiteSpace(condicao) Then
            condicao = " AND " & condicao
        End If

        Using retorno As DataTable = New DataTable()
            Using cmd As New MySqlCommand()
                cmd.Connection = MysqlTrans.Connection
                cmd.Transaction = MysqlTrans
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tbl_ano WHERE 1 = 1 " & condicao & " ORDER BY cod_ano"

                Using adaptador As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptador.Fill(retorno)
                End Using
            End Using

            Return retorno
        End Using
    End Function

    Public Shared Function ListaMeses(ByVal MysqlTrans As MySqlTransaction, Optional condicao As String = "") As DataTable

        If Not String.IsNullOrWhiteSpace(condicao) Then
            condicao = " AND " & condicao
        End If

        Using retorno As DataTable = New DataTable()
            Using cmd As New MySqlCommand()
                cmd.Connection = MysqlTrans.Connection
                cmd.Transaction = MysqlTrans
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tbl_mes WHERE 1 = 1 " & condicao & " ORDER BY cod_mes"

                Using adaptador As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptador.Fill(retorno)
                End Using
            End Using

            Return retorno
        End Using
    End Function
End Class
