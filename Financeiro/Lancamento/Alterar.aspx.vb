﻿Public Class Alterar1
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cod_lancamento.Value = Request("cod_lancamento")
            acao.Value = Request("acao")

            If UCase(acao.Value) = "EXCLUIR" Then
                btn_alterar.Visible = False
            Else
                btn_excluir.Visible = False
            End If

            Me.CarregarDespesas()
            Me.CarregarAnos()
            Me.CarregarMeses()

            Dim lancamentoDAO As New LancamentoDAO

            Using MysqlConn = Conexao.ObterConexaoAberta()
                Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                    Try
                        Dim condicao = " cod_lancamento = " & cod_lancamento.Value

                        Using table As DataTable = lancamentoDAO.ListaLancamentos(MysqlTrans, condicao)
                            For Each row As DataRow In table.Rows
                                cod_despesa.SelectedValue = row("cod_despesa")
                                cod_ano.SelectedValue = row("cod_ano")
                                cod_mes.SelectedValue = row("cod_mes")
                                dt_vencimento.Text = row("dt_vencimento")
                                txt_valor_despesa.Text = row("txt_valor_despesa")
                                If Not IsDBNull(row("dt_pagamento")) Then dt_pagamento.Text = row("dt_pagamento")
                                If Not IsDBNull(row("txt_valor_pagamento")) Then txt_valor_pagamento.Text = row("txt_valor_pagamento")
                                If Not IsDBNull(row("txt_descricao")) Then txt_descricao.Value = row("txt_descricao")
                            Next
                        End Using

                        Conexao.CommitTransacao(MysqlTrans)
                    Catch ex As Exception
                        Conexao.RollBackTransacao(MysqlTrans)
                        Response.Write(ex.Source & "<br />" & ex.Message & "<br />" & ex.StackTrace)
                        Response.End()
                    End Try
                End Using
            End Using
        End If

    End Sub

    Private Sub CarregarDespesas()
        cod_despesa.DataTextField = "txt_despesa"
        cod_despesa.DataValueField = "cod_despesa"
        cod_despesa.DataSource = Me.TabelaDespesa()
        cod_despesa.DataBind()
        cod_despesa.Items.Insert(0, "")
    End Sub

    Private Sub CarregarAnos()
        cod_ano.DataTextField = "cod_ano"
        cod_ano.DataValueField = "cod_ano"
        cod_ano.DataSource = Me.TabelaAno()
        cod_ano.DataBind()
        cod_ano.Items.Insert(0, "")
    End Sub

    Private Sub CarregarMeses()
        cod_mes.DataTextField = "txt_mes"
        cod_mes.DataValueField = "cod_mes"
        cod_mes.DataSource = Me.TabelaMes()
        cod_mes.DataBind()
        cod_mes.Items.Insert(0, "")
    End Sub

    Private Function TabelaDespesa() As DataTable
        Dim despesaDAO As New DespesaDAO()
        Dim table As New DataTable

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    table = despesaDAO.ListaDespesas(MysqlTrans, "cod_ativo = 1")

                    Conexao.CommitTransacao(MysqlTrans)
                Catch ex As Exception
                    Conexao.RollBackTransacao(MysqlTrans)
                    Response.Write(ex.Source & "<br />" & ex.Message & "<br />" & ex.StackTrace)
                    Response.End()
                End Try
            End Using
        End Using

        Return table
    End Function

    Private Function TabelaAno() As DataTable
        Dim table As New DataTable

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    table = Geral.ListaAnos(MysqlTrans)

                    Conexao.CommitTransacao(MysqlTrans)
                Catch ex As Exception
                    Conexao.RollBackTransacao(MysqlTrans)
                    Response.Write(ex.Source & "<br />" & ex.Message & "<br />" & ex.StackTrace)
                    Response.End()
                End Try
            End Using
        End Using

        Return table
    End Function

    Private Function TabelaMes() As DataTable
        Dim table As New DataTable

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    table = Geral.ListaMeses(MysqlTrans)

                    Conexao.CommitTransacao(MysqlTrans)
                Catch ex As Exception
                    Conexao.RollBackTransacao(MysqlTrans)
                    Response.Write(ex.Source & "<br />" & ex.Message & "<br />" & ex.StackTrace)
                    Response.End()
                End Try
            End Using
        End Using

        Return table
    End Function

    Protected Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        Dim retorno As New Result

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim obj As New Result
                    obj.cod_lancamento = cod_lancamento.Value
                    obj.cod_despesa = cod_despesa.SelectedValue
                    obj.cod_ano = cod_ano.SelectedValue
                    obj.cod_mes = cod_mes.SelectedValue
                    obj.dt_vencimento = dt_vencimento.Text.Trim
                    obj.txt_valor_despesa = txt_valor_despesa.Text.Trim
                    If Not String.IsNullOrWhiteSpace(dt_pagamento.Text) Then
                        obj.dt_pagamento = dt_pagamento.Text.Trim
                    Else
                        obj.dt_pagamento = "01/01/1900"
                    End If
                    If Not String.IsNullOrWhiteSpace(txt_valor_pagamento.Text) Then
                        obj.txt_valor_pagamento = txt_valor_pagamento.Text.Trim
                    End If
                    If Not String.IsNullOrWhiteSpace(txt_descricao.Value) Then
                        obj.txt_descricao = Trim(txt_descricao.Value)
                    End If

                    Dim LancamentoBO As New LancamentoBO
                    retorno = LancamentoBO.ValidarAlteracao(obj, MysqlTrans)

                    If retorno.txt_status.Equals("SUCESSO") Then
                        Conexao.CommitTransacao(MysqlTrans)

                        ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>self.location.href = 'Pesquisar.aspx';</script>")
                    ElseIf retorno.txt_status.Equals("FALHA") Then
                        Conexao.RollBackTransacao(MysqlTrans)
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

    Protected Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        Dim retorno As New Result

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)

                Try
                    Dim obj As New Result
                    obj.cod_lancamento = cod_lancamento.Value

                    Dim LancamentoBO As New LancamentoBO
                    retorno = LancamentoBO.ValidarExcluir(obj, MysqlTrans)

                    If retorno.txt_status.Equals("SUCESSO") Then
                        Conexao.CommitTransacao(MysqlTrans)

                        ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>self.location.href = 'Pesquisar.aspx';</script>")
                    ElseIf retorno.txt_status.Equals("FALHA") Then
                        Conexao.RollBackTransacao(MysqlTrans)
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