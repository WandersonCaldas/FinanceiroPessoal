Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class LancamentoDAO
    Public Function ListaLancamentos(ByVal MysqlTrans As MySqlTransaction, Optional condicao As String = "") As DataTable

        If Not String.IsNullOrWhiteSpace(condicao) Then
            condicao = " AND " & condicao
        End If

        Using retorno As DataTable = New DataTable()
            Using cmd As New MySqlCommand()
                cmd.Connection = MysqlTrans.Connection
                cmd.Transaction = MysqlTrans
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT tbl_lancamento.*, txt_despesa, txt_mes FROM tbl_lancamento " &
                                    " INNER JOIN tbl_despesa ON tbl_despesa.cod_despesa = tbl_lancamento.cod_despesa" &
                                    " INNER JOIN tbl_mes ON tbl_mes.cod_mes = tbl_lancamento.cod_mes" &
                                    " WHERE 1 = 1 " & condicao

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
            cmd.CommandText = "INSERT INTO tbl_lancamento(dt_vencimento, cod_despesa, txt_descricao, cod_ano, cod_mes, txt_valor_despesa, dt_pagamento, txt_valor_pagamento) VALUES(?, ?, ?, ?, ?, ?, ?, ?)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("dt_vencimento", MySqlDbType.DateTime).Value = CDate(Trim(obj.dt_vencimento))
            cmd.Parameters.Add("cod_despesa", MySqlDbType.Int32).Value = obj.cod_despesa
            cmd.Parameters.Add("txt_descricao", MySqlDbType.VarChar).Value = Trim(obj.txt_descricao)
            cmd.Parameters.Add("cod_ano", MySqlDbType.Int32).Value = obj.cod_ano
            cmd.Parameters.Add("cod_mes", MySqlDbType.Int32).Value = obj.cod_mes
            cmd.Parameters.Add("txt_valor_despesa", MySqlDbType.VarChar).Value = Trim(obj.txt_valor_despesa)
            If obj.dt_pagamento = "01/01/1900" Then
                cmd.Parameters.Add("dt_pagamento", MySqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("dt_pagamento", MySqlDbType.DateTime).Value = CDate(obj.dt_pagamento)
            End If
            cmd.Parameters.Add("txt_valor_pagamento", MySqlDbType.VarChar).Value = Trim(obj.txt_valor_pagamento)
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function Alterar(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE tbl_lancamento SET dt_vencimento = ?, cod_despesa = ?, txt_descricao = ?, cod_ano = ?, cod_mes = ?, txt_valor_despesa = ?, dt_pagamento = ?, txt_valor_pagamento = ? WHERE cod_lancamento = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("dt_vencimento", MySqlDbType.DateTime).Value = CDate(Trim(obj.dt_vencimento))
            cmd.Parameters.Add("cod_despesa", MySqlDbType.Int32).Value = obj.cod_despesa
            cmd.Parameters.Add("txt_descricao", MySqlDbType.VarChar).Value = Trim(obj.txt_descricao)
            cmd.Parameters.Add("cod_ano", MySqlDbType.Int32).Value = obj.cod_ano
            cmd.Parameters.Add("cod_mes", MySqlDbType.Int32).Value = obj.cod_mes
            cmd.Parameters.Add("txt_valor_despesa", MySqlDbType.VarChar).Value = Trim(obj.txt_valor_despesa)
            If obj.dt_pagamento = "01/01/1900" Then
                cmd.Parameters.Add("dt_pagamento", MySqlDbType.DateTime).Value = System.DBNull.Value
            Else
                cmd.Parameters.Add("dt_pagamento", MySqlDbType.DateTime).Value = CDate(obj.dt_pagamento)
            End If
            cmd.Parameters.Add("txt_valor_pagamento", MySqlDbType.VarChar).Value = Trim(obj.txt_valor_pagamento)
            cmd.Parameters.Add("cod_lancamento", MySqlDbType.Int32).Value = obj.cod_lancamento
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function Excluir(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "DELETE FROM tbl_lancamento WHERE cod_lancamento = ?"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("cod_lancamento", MySqlDbType.Int32).Value = obj.cod_lancamento
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function ListaDigital(ByVal MysqlTrans As MySqlTransaction, Optional condicao As String = "") As DataTable

        If Not String.IsNullOrWhiteSpace(condicao) Then
            condicao = " AND " & condicao
        End If

        Using retorno As DataTable = New DataTable()
            Using cmd As New MySqlCommand()
                cmd.Connection = MysqlTrans.Connection
                cmd.Transaction = MysqlTrans
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT tbl_digital.* FROM tbl_digital WHERE 1 = 1 " & condicao & " ORDER BY cod_chave DESC"

                Using adaptador As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    adaptador.Fill(retorno)
                End Using
            End Using

            Return retorno
        End Using
    End Function

    Public Function IncluirDigital(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()
        Dim io As New IO()

        retorno = io.GravarArquivo(obj)

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO tbl_digital(cod_lancamento, txt_arquivo) VALUES(?, ?)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("cod_lancamento", MySqlDbType.Int32).Value = obj.cod_lancamento
            cmd.Parameters.Add("txt_arquivo", MySqlDbType.VarChar).Value = Trim(retorno.txt_nome_arquivo)            
            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function

    Public Function ExcluirDigital(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()
        Dim io As New IO()

        Using cmd As New MySqlCommand()
            cmd.Connection = MysqlTrans.Connection
            cmd.Transaction = MysqlTrans
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "DELETE FROM tbl_digital WHERE cod_chave IN(" & Trim(obj.cod_chave) & ")"                        

            'REMOVER ARQUIVOS FÍSICOS
            Using table As DataTable = ListaDigital(MysqlTrans, " tbl_digital.cod_chave IN( " & Trim(obj.cod_chave) & " )")
                Dim objArquivo As New Result()                

                For Each row As DataRow In table.Rows
                    objArquivo.txt_nome_arquivo &= "[" & Trim(row("txt_arquivo")) & "]"
                Next

                io.ExcluirArquivo(objArquivo)
            End Using

            cmd.ExecuteNonQuery()

            retorno.txt_status = ResponseStatus.SUCESSO.Texto
        End Using

        Return retorno
    End Function
End Class
