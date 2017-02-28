Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Alterar
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cod_despesa.Value = Request("cod_despesa")

            Dim despesaDAO As New DespesaDAO

            Using MysqlConn = Conexao.ObterConexaoAberta()
                Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                    Try
                        Dim condicao = " cod_despesa = " & cod_despesa.Value

                        Using table As DataTable = despesaDAO.ListaDespesas(MysqlTrans, condicao)
                            For Each row As DataRow In table.Rows
                                txt_despesa.Text = row("txt_despesa")
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

    Protected Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        Dim retorno As New Result

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim obj As New Result
                    obj.cod_despesa = cod_despesa.Value
                    obj.txt_despesa = Trim(txt_despesa.Text)
                    obj.txt_descricao = Trim(txt_descricao.Value)

                    Dim despesaBO As New DespesaBO()
                    retorno = despesaBO.ValidarAlteracao(obj, MysqlTrans)

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