Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Visualizar
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cod_despesa.Value = Request("cod_despesa")
            acao_confirma.Value = Request("acao_confirma")

            Dim despesaDAO As New DespesaDAO

            Using MysqlConn = Conexao.ObterConexaoAberta()
                Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                    Try
                        Dim condicao = " cod_despesa = " & cod_despesa.Value

                        Using table As DataTable = despesaDAO.ListaDespesas(MysqlTrans, condicao)
                            For Each row As DataRow In table.Rows
                                txt_despesa.Text = row("txt_despesa")
                                If Not IsDBNull(row("txt_descricao")) Then txt_descricao.Text = row("txt_descricao")
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

            If acao_confirma.Value = "excluir" Then
                btn_excluir.Visible = True
                lbExibir.Text = "CANCELAR"
            ElseIf acao_confirma.Value = "ativar" Then
                btn_ativar.Visible = True
                lbExibir.Text = "REATIVAR"
            Else
                lbExibir.Text = "DETALHAR"
            End If
        End If
    End Sub

    Protected Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        Dim retorno As New Result()

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim despesaBO As New DespesaBO
                    Dim obj As New Result

                    obj.cod_despesa = cod_despesa.Value

                    retorno = despesaBO.ValidarExclusao(obj, MysqlTrans)

                    If retorno.txt_status.Equals("SUCESSO") Then
                        Conexao.CommitTransacao(MysqlTrans)

                        ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>self.location.href = 'Default.aspx';</script>")
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

    Protected Sub btn_ativar_Click(sender As Object, e As EventArgs) Handles btn_ativar.Click
        Dim retorno As New Result()

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim despesaBO As New DespesaBO
                    Dim obj As New Result

                    obj.cod_despesa = cod_despesa.Value

                    retorno = despesaBO.ValidarReativacao(obj, MysqlTrans)

                    If retorno.txt_status.Equals("SUCESSO") Then
                        Conexao.CommitTransacao(MysqlTrans)

                        ClientScript.RegisterStartupScript(Me.GetType, "erro", "<script language='javascript'>self.location.href = 'Default.aspx';</script>")
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