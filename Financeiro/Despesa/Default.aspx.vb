Public Class _Default1
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Carregar()
        End If

    End Sub

    Private Sub Carregar()
        grd.DataSource = Me.Tabela()
        grd.DataBind()
    End Sub

    Private Function Tabela() As DataTable
        Dim despesaDAO As New DespesaDAO()
        Dim table As New DataTable()

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try                    
                    Dim condicao As String = "cod_ativo = " & cod_ativo_.SelectedValue

                    table = despesaDAO.ListaDespesas(MysqlTrans, condicao)

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
            Dim cod_despesa As String = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("cod_despesa")
            Dim cod_ativo As Integer = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("cod_ativo")

            e.Row.Cells(2).Text = Funcao.Destacar(cod_ativo)

            'AÇÕES
            Dim ddlAcao As DropDownList
            ddlAcao = e.Row.FindControl("ddlAcao")

            If cod_ativo = 1 Then
                ddlAcao.Items.Add(New ListItem("Alterar", String.Format("Alterar.aspx?cod_despesa={0}", cod_despesa)))
            End If

            If cod_ativo = 0 Then
                ddlAcao.Items.Add(New ListItem("Reativar", String.Format("Visualizar.aspx?cod_despesa={0}&acao_confirma=ativar", cod_despesa)))
            End If

            If cod_ativo = 1 Then
                ddlAcao.Items.Add(New ListItem("Cancelar", String.Format("Visualizar.aspx?cod_despesa={0}&acao_confirma=excluir", cod_despesa)))
            End If

            ddlAcao.Items.Add(New ListItem("Visualizar", String.Format("Visualizar.aspx?cod_despesa={0}", cod_despesa)))
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

    Protected Sub grd_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles grd.PreRender
        If grd.Rows.Count > 0 Then
            grd.UseAccessibleHeader = True
            grd.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub cod_ativo__SelectedIndexChanged(sender As Object, e As EventArgs) Handles cod_ativo_.SelectedIndexChanged
        Me.Carregar()
    End Sub
End Class