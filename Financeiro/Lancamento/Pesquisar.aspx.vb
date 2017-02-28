Public Class Pesquisar
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.CarregarDespesas()
            Me.CarregarAnos()
            Me.CarregarMeses()

            div_resultado.Visible = False
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
                    table = despesaDAO.ListaDespesas(MysqlTrans)

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

    Protected Sub btn_pesquisar_Click(sender As Object, e As EventArgs) Handles btn_pesquisar.Click
        Me.Carregar()
        div_resultado.Visible = True
    End Sub

    Private Sub Carregar()
        grd.DataSource = Me.Tabela()
        grd.DataBind()
    End Sub

    Private Function Tabela() As DataTable
        Dim lancamentoDAO As New LancamentoDAO()
        Dim table As New DataTable()
        Dim condicao As String = " 1 = 1"

        If Not String.IsNullOrEmpty(cod_ano.SelectedValue) Then
            condicao &= " AND tbl_lancamento.cod_ano = " & cod_ano.SelectedValue
        End If

        If Not String.IsNullOrEmpty(cod_mes.SelectedValue) Then
            condicao &= " AND tbl_lancamento.cod_mes = " & cod_mes.SelectedValue
        End If

        If Not String.IsNullOrEmpty(cod_despesa.SelectedValue) Then
            condicao &= " AND tbl_lancamento.cod_despesa = " & cod_despesa.SelectedValue
        End If

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    table = lancamentoDAO.ListaLancamentos(MysqlTrans, condicao)

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

    Protected Sub grd_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cod_lancamento As String = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("cod_lancamento")
            Dim dt_vencimento As String = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("dt_vencimento")

            e.Row.Cells(4).Text = FormatDateTime(dt_vencimento, 2)
            If Not IsDBNull(CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("dt_pagamento")) Then
                Dim dt_pagamento As String = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("dt_pagamento")
                e.Row.Cells(6).Text = FormatDateTime(dt_pagamento, 2)
            End If

            'AÇÕES
            Dim ddlAcao As DropDownList
                ddlAcao = e.Row.FindControl("ddlAcao")
            ddlAcao.Items.Add(New ListItem("Alterar", String.Format("Alterar.aspx?cod_lancamento={0}", cod_lancamento)))
            ddlAcao.Items.Add(New ListItem("Digital", String.Format("Digital.aspx?cod_lancamento={0}", cod_lancamento)))
            ddlAcao.Items.Add(New ListItem("Excluir", String.Format("Alterar.aspx?cod_lancamento={0}&acao=excluir", cod_lancamento)))            

        End If
    End Sub

    Protected Sub grd_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DataBound
        If grd.Rows.Count = 0 Then
            panSemRegistro.Visible = True
        Else
            panSemRegistro.Visible = False
        End If
    End Sub

    Protected Sub OnPageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        grd.PageIndex = e.NewPageIndex
        Me.Carregar()
    End Sub

    Protected Sub SortRecords(ByVal sender As Object, ByVal e As GridViewSortEventArgs)
        Dim sortExpression As String = e.SortExpression
        Dim direction As String = String.Empty
        If SortDirection = SortDirection.Ascending Then
            SortDirection = SortDirection.Descending
            direction = " DESC"
        Else
            SortDirection = SortDirection.Ascending
            direction = " ASC"
        End If
        Dim table As DataTable = Me.Tabela()
        table.DefaultView.Sort = sortExpression & direction
        grd.DataSource = table
        grd.DataBind()
    End Sub

    Public Property SortDirection() As SortDirection
        Get
            If ViewState("SortDirection") Is Nothing Then
                ViewState("SortDirection") = SortDirection.Ascending
            End If
            Return DirectCast(ViewState("SortDirection"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("SortDirection") = value
        End Set
    End Property
End Class