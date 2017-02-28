Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System
Imports System.Data

Public Class DespesaBO
    Public Function ValidarInclusao(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()
        Dim despesaDAO As New DespesaDAO()

        Dim table As New DataTable()

        Dim condicao As String = " UPPER(txt_despesa) = '" & Trim(UCase(obj.txt_despesa)) & "'"

        table = despesaDAO.ListaDespesas(MysqlTrans, condicao)

        If table.Rows.Count > 0 Then
            retorno.txt_status = ResponseStatus.FALHA.Texto
            retorno.txt_mensagem = Mensagem.MN002.TextoFormatado("Registro")
        Else
            retorno = New Result()
            retorno = despesaDAO.Incluir(obj, MysqlTrans)
        End If

        Return retorno
    End Function

    Public Function ValidarAlteracao(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result()

        Dim despesaDAO As New DespesaDAO

        Dim condicao As String = " UPPER(txt_despesa) = '" & Trim(UCase(obj.txt_despesa)) & "' AND cod_despesa <> " & obj.cod_despesa

        Using table As DataTable = despesaDAO.ListaDespesas(MysqlTrans, condicao)
            If table.Rows.Count > 0 Then
                retorno.txt_status = ResponseStatus.FALHA.Texto
                retorno.txt_mensagem = Mensagem.MN002.TextoFormatado("Registro")
            Else
                retorno = New Result
                retorno = despesaDAO.Alterar(obj, MysqlTrans)
            End If
        End Using

        Return retorno
    End Function

    Public Function ValidarExclusao(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result
        Dim despesaDAO As New DespesaDAO        

        Dim condicao As String = " cod_despesa = " & obj.cod_despesa & " AND cod_ativo = 0 "

        Using table As DataTable = despesaDAO.ListaDespesas(MysqlTrans, condicao)
            If table.Rows.Count > 0 Then
                retorno.txt_status = ResponseStatus.FALHA.Texto
                retorno.txt_mensagem = Mensagem.MN004.TextoFormatado("Despesa", "cancelada")
            Else
                retorno = New Result
                retorno = despesaDAO.Excluir(obj, MysqlTrans)
            End If
        End Using

        Return retorno
    End Function

    Public Function ValidarReativacao(ByVal obj As Result, ByVal MysqlTrans As MySqlTransaction) As Result
        Dim retorno As New Result
        Dim despesaDAO As New DespesaDAO        

        Dim condicao As String = " cod_despesa = " & obj.cod_despesa & " AND cod_ativo = 1 "

        Using table = despesaDAO.ListaDespesas(MysqlTrans, condicao)
            If table.Rows.Count > 0 Then
                retorno.txt_status = ResponseStatus.FALHA.Texto
                retorno.txt_mensagem = Mensagem.MN004.TextoFormatado("Despesa", "ativa")
            Else
                retorno = New Result()
                retorno = despesaDAO.Ativar(obj, MysqlTrans)
            End If
        End Using

        Return retorno
    End Function
End Class
