Imports System.IO

Public Class IO
    Public Function GravarArquivo(ByVal obj As Result) As Result
        Dim retorno As New Result()

        Dim txt_nome_arquivo As String = "{" & UCase(System.Guid.NewGuid().ToString()) & "}_" & Funcao.RemoveAcento(Trim(obj.txt_nome_arquivo))

        Dim txt_caminho As String = CriarDiretorioGravacao()

        Dim txt_arquivo_completo As String = txt_caminho & txt_nome_arquivo

        File.WriteAllBytes(txt_arquivo_completo, obj.byteArquivo)

        txt_caminho = txt_caminho.Replace(HttpContext.Current.Application("txt_caminho_gravacao"), "")

        retorno.txt_nome_arquivo = txt_caminho.ToString() & "\" & txt_nome_arquivo.ToString()
        retorno.txt_status = ResponseStatus.SUCESSO.Texto

        Return retorno
    End Function

    Private Function CriarDiretorioGravacao() As String
        Dim txt_caminho As String = Year(Date.Now()) & "\" & Funcao.CompletaZero(Month(Date.Now()), 2)

        If Not Directory.Exists(txt_caminho) Then
            If Not Directory.Exists(HttpContext.Current.Application("txt_caminho_gravacao") & Year(Date.Now())) Then
                Directory.CreateDirectory(HttpContext.Current.Application("txt_caminho_gravacao") & Year(Date.Now()))
            End If
            Directory.CreateDirectory(HttpContext.Current.Application("txt_caminho_gravacao") & txt_caminho)

        End If

        Return HttpContext.Current.Application("txt_caminho_gravacao") & txt_caminho & "\"
    End Function

    Public Function ExcluirArquivo(ByVal obj As Result) As Result
        Dim retorno As New Result()
        Dim a_txt_arquivo
        Dim txt_arquivo As String = String.Empty

        obj.txt_nome_arquivo = Funcao.MontaArrayQuery(obj.txt_nome_arquivo)

        a_txt_arquivo = Split(obj.txt_nome_arquivo, ",")

        For i As Integer = LBound(a_txt_arquivo) To UBound(a_txt_arquivo)
            txt_arquivo = HttpContext.Current.Application("txt_caminho_gravacao") & a_txt_arquivo(i)

            If File.Exists(txt_arquivo) Then
                File.Delete(txt_arquivo)
            End If
        Next

        retorno.txt_status = ResponseStatus.SUCESSO.Texto
        Return retorno
    End Function
End Class
