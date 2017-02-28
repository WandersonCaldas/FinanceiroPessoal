Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class LancamentoBO
    Public Function ValidarInclusao(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()
        Dim lancamentoDAO As New LancamentoDAO()

        Dim condicao As String = " tbl_lancamento.cod_despesa = " & obj.cod_despesa & " AND tbl_lancamento.cod_ano = " & obj.cod_ano &
                                    " AND tbl_lancamento.cod_mes = " & obj.cod_mes

        Using table As DataTable = lancamentoDAO.ListaLancamentos(MysqlTrans, condicao)
            If table.Rows.Count > 0 Then
                retorno.txt_status = ResponseStatus.FALHA.Texto
                retorno.txt_mensagem = Mensagem.MN002.TextoFormatado("Lançamento")
            Else
                retorno = New Result()
                retorno = lancamentoDAO.Incluir(obj, MysqlTrans)
            End If
        End Using

        Return retorno
    End Function

    Public Function ValidarAlteracao(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()
        Dim lancamentoDAO As New LancamentoDAO()

        Dim condicao As String = " tbl_lancamento.cod_despesa = " & obj.cod_despesa & " AND tbl_lancamento.cod_ano = " & obj.cod_ano &
                                " AND tbl_lancamento.cod_mes = " & obj.cod_mes & " AND tbl_lancamento.cod_lancamento <> " & obj.cod_lancamento

        Using table As DataTable = lancamentoDAO.ListaLancamentos(MysqlTrans, condicao)
            If table.Rows.Count > 0 Then
                retorno.txt_status = ResponseStatus.FALHA.Texto
                retorno.txt_mensagem = Mensagem.MN002.TextoFormatado("Lançamento")
            Else
                retorno = New Result()
                retorno = lancamentoDAO.Alterar(obj, MysqlTrans)
            End If
        End Using

        Return retorno
    End Function

    Public Function ValidarExcluir(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()
        Dim lancamentoDAO As New LancamentoDAO()

        retorno = lancamentoDAO.Excluir(obj, MysqlTrans)

        Return retorno
    End Function

End Class
