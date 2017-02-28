Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class DespesaDAO
    Public Function ListaDespesas(ByVal MysqlTrans As MySqlTransaction, Optional condicao As String = "") As DataTable

        If Not String.IsNullOrWhiteSpace(condicao) Then
            condicao = " AND " & condicao
        End If

        Using retorno As DataTable = New DataTable()
            Using cmd As New MySqlCommand()
                cmd.Connection = MysqlTrans.Connection
                cmd.Transaction = MysqlTrans
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM tbl_despesa WHERE 1 = 1 " & condicao & " ORDER BY txt_despesa"

                Using adaptador As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptador.Fill(retorno)
                End Using
            End Using

            Return retorno
        End Using
    End Function

    Public Function Incluir(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO tbl_despesa(txt_despesa, txt_descricao) VALUES(?, ?)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("txt_despesa", MySqlDbType.VarChar).Value = Trim(UCase(obj.txt_despesa))
            cmd.Parameters.Add("txt_descricao", MySqlDbType.VarChar).Value = Trim(obj.txt_descricao)
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function Alterar(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE tbl_despesa SET txt_despesa = ?, txt_descricao = ? WHERE cod_despesa = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("txt_despesa", MySqlDbType.VarChar).Value = Trim(UCase(obj.txt_despesa))
            cmd.Parameters.Add("txt_descricao", MySqlDbType.VarChar).Value = Trim(obj.txt_descricao)
            cmd.Parameters.Add("cod_despesa", MySqlDbType.Int32).Value = obj.cod_despesa
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function Excluir(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE tbl_despesa SET cod_ativo = 0 WHERE cod_despesa = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("cod_despesa", MySqlDbType.Int32).Value = obj.cod_despesa
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function Ativar(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE tbl_despesa SET cod_ativo = 1 WHERE cod_despesa = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("cod_despesa", MySqlDbType.Int32).Value = obj.cod_despesa
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function
End Class
