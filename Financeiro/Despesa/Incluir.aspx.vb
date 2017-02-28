Imports Microsoft.VisualBasic
Imports MySql
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Incluir
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        Dim retorno As New Result

        Using MysqlConn = Conexao.ObterConexaoAberta()
            Using MysqlTrans = Conexao.IniciarTransacao(MysqlConn)
                Try
                    Dim obj As New Result
                    Dim despesaBO As New DespesaBO

                    obj.txt_despesa = txt_despesa.Text
                    obj.txt_descricao = txt_descricao.Value

                    retorno = despesaBO.ValidarInclusao(obj, MysqlTrans)

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