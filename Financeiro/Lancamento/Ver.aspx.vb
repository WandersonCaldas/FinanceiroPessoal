Public Class Ver
    Inherits PageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim txt_arquivo As String = Request.QueryString("txt_arquivo")

        txt_arquivo = Replace(txt_arquivo, "/", "\")

        Try
            Dim txt_nome_arquivo As String = Funcao.NomeContratoDigital(txt_arquivo)

            Response.Clear()
            Response.AddHeader("Content-Disposition", "inline; filename=" + txt_nome_arquivo)
            Response.ContentType = RetornaTipo(txt_nome_arquivo)
            Response.Buffer = False
            Response.BufferOutput = False
            Response.WriteFile(txt_arquivo)
        Catch ex As Exception
            Response.Write(ex.Source & "<br />" & ex.Message & "<br />" & ex.StackTrace)
            Response.End()
        End Try
    End Sub

    Private Function RetornaTipo(ByVal txt_arquivo As String) As String
        Dim txt_tipo As String = "application/octet-stream"
        txt_arquivo = LCase(StrReverse(txt_arquivo))
        txt_arquivo = Left(txt_arquivo, InStr(txt_arquivo, ".") - 1)
        txt_arquivo = StrReverse(txt_arquivo)

        Select Case txt_arquivo
            Case "pdf"
                txt_tipo = "application/pdf"
            Case Else
                txt_tipo = "application/octet-stream"
        End Select

        Return txt_tipo
    End Function

End Class