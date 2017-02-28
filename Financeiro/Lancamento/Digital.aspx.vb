Public Class Digital
    Inherits PageBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cod_lancamento.Value = Request("cod_lancamento")

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

            Me.Carregar()
        End If

        cod_ano.Enabled = False
        cod_despesa.Enabled = False
        cod_mes.Enabled = False
    End Sub

    Private Sub Carregar()
        grd.DataSource = Me.Tabela()
        grd.DataBind()
    End Sub

    Private Function Tabela() As DataTable
        Dim lancamentoDAO As New LancamentoDAO()
        Dim table As New DataTable()

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim condicao = " tbl_digital.cod_lancamento = " & cod_lancamento.Value

                    table = lancamentoDAO.ListaDigital(MysqlTrans, condicao)

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

    Protected Sub grd_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DataBound
        If grd.Rows.Count = 0 Then
            btn_excluir.Visible = False
        End If
    End Sub

    Protected Sub grd_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grd.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cod_chave As Integer = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("cod_chave")
            Dim txt_arquivo As String = CType(e.Row.DataItem, System.Data.DataRowView).Row.Item("txt_arquivo")

            Dim txt_arquivo_exibir As String = Replace(Application("txt_caminho"), "\", "/") & Replace(txt_arquivo, "\", "/")
            e.Row.Cells(1).Text = "<a href=""#"" onclick=""window.open('Ver.aspx?txt_arquivo=" & txt_arquivo_exibir & "', '_blank', 'menubar=yes, resizable=yes, titlebar=yes, toolbar=yes, status=yes,width=650,height=450,scrollbars=1')""> " & Funcao.NomeContratoDigital(txt_arquivo) & " </a>"
        End If
    End Sub

    Protected Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        If Page.IsValid Then
            If flp_arquivo.HasFile Then
                Dim retorno As New Result()
                Dim lancamentoDAO As New LancamentoDAO

                Dim objDigital As New Result()
                objDigital.cod_lancamento = cod_lancamento.Value
                objDigital.byteArquivo() = flp_arquivo.FileBytes
                objDigital.txt_nome_arquivo = Server.HtmlEncode(flp_arquivo.FileName)
                objDigital.txt_extensao = LCase(System.IO.Path.GetExtension(objDigital.txt_nome_arquivo))
                objDigital.cod_tamanho_arquivo = flp_arquivo.PostedFile.ContentLength

                Using MysqlConn = Conexao.ObterConexaoAberta()
                    Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                        Try
                            retorno = lancamentoDAO.IncluirDigital(objDigital, MysqlTrans)

                            If retorno.txt_status.Equals("SUCESSO") Then
                                Conexao.CommitTransacao(MysqlTrans)

                                ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>self.location.href = 'Digital.aspx?cod_lancamento=" & cod_lancamento.Value & "';</script>")
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
            End If
        End If
    End Sub

    Protected Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        Dim cod_chave As String = Request("cod_chave")

        If cod_chave <> "" Then
            Using MysqlConn = Conexao.ObterConexaoAberta()
                Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                    Try
                        Dim retorno As New Result()
                        Dim lancamentoDAO As New LancamentoDAO()
                        Dim objDigital As New Result()
                        objDigital.cod_lancamento = cod_lancamento.Value
                        objDigital.cod_chave = Request("cod_chave")

                        retorno = lancamentoDAO.ExcluirDigital(objDigital, MysqlTrans)

                        If retorno.txt_status.Equals("SUCESSO") Then
                            Conexao.CommitTransacao(MysqlTrans)

                            ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>self.location.href = 'Digital.aspx?cod_lancamento=" & cod_lancamento.Value & "';</script>")
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
        End If
    End Sub
End Class