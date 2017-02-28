Imports Microsoft.VisualBasic

Public Class Funcao
    Public Shared Function Destacar(ByVal valor As String) As String
        If valor = "1" Or valor Then
            Return "<font color=""green""><b>SIM</b></font>"
        Else
            Return "<font color=""red""><b>NÃO</b></font>"
        End If

    End Function

    Public Shared Function NomeContratoDigital(ByVal txt_valor As String) As String
        Return Mid(txt_valor, InStr(txt_valor, "_") + 1, Len(txt_valor))
    End Function

    Public Shared Function RemoveAcento(ByVal texto As String) As String
        If texto <> "" Then
            Do While InStr(texto, " ")
                texto = Replace(texto, " ", "_")
            Loop
            texto = Replace(texto, "á", "a")
            texto = Replace(texto, "â", "a")
            texto = Replace(texto, "ã", "a")
            texto = Replace(texto, "à", "a")
            texto = Replace(texto, "ä", "a")
            texto = Replace(texto, "Â", "A")
            texto = Replace(texto, "À", "A")
            texto = Replace(texto, "Á", "A")
            texto = Replace(texto, "Ä", "A")
            texto = Replace(texto, "Ã", "A")
            texto = Replace(texto, "Ê", "E")
            texto = Replace(texto, "È", "E")
            texto = Replace(texto, "É", "E")
            texto = Replace(texto, "Ë", "E")
            texto = Replace(texto, "é", "e")
            texto = Replace(texto, "ê", "e")
            texto = Replace(texto, "è", "e")
            texto = Replace(texto, "ë", "e")
            texto = Replace(texto, "í", "i")
            texto = Replace(texto, "ì", "i")
            texto = Replace(texto, "ï", "i")
            texto = Replace(texto, "î", "i")
            texto = Replace(texto, "Í", "I")
            texto = Replace(texto, "Ì", "I")
            texto = Replace(texto, "Ï", "I")
            texto = Replace(texto, "Î", "I")
            texto = Replace(texto, "ó", "o")
            texto = Replace(texto, "ò", "o")
            texto = Replace(texto, "ô", "o")
            texto = Replace(texto, "õ", "o")
            texto = Replace(texto, "ö", "o")
            texto = Replace(texto, "Ó", "O")
            texto = Replace(texto, "Ô", "O")
            texto = Replace(texto, "Ò", "O")
            texto = Replace(texto, "Õ", "O")
            texto = Replace(texto, "Ö", "O")
            texto = Replace(texto, "ú", "u")
            texto = Replace(texto, "ù", "u")
            texto = Replace(texto, "û", "u")
            texto = Replace(texto, "ü", "u")
            texto = Replace(texto, "Ú", "U")
            texto = Replace(texto, "Ù", "U")
            texto = Replace(texto, "Ü", "U")
            texto = Replace(texto, "Û", "U")
            texto = Replace(texto, "ç", "c")
            texto = Replace(texto, "Ç", "C")
            texto = Replace(texto, " ", "_")
            texto = Replace(texto, "!", "_")
            texto = Replace(texto, "@", "_")
            texto = Replace(texto, "#", "_")
            texto = Replace(texto, "$", "_")
            texto = Replace(texto, "%", "_")
            texto = Replace(texto, "¨", "_")
            texto = Replace(texto, "&", "_")
            texto = Replace(texto, "*", "_")
            texto = Replace(texto, "(", "_")
            texto = Replace(texto, ")", "_")
            texto = Replace(texto, "-", "_")
            texto = Replace(texto, "+", "_")
            texto = Replace(texto, "=", "_")
            texto = Replace(texto, "§", "_")
            texto = Replace(texto, "'", "_")
            texto = Replace(texto, "´", "_")
            texto = Replace(texto, "`", "_")
            texto = Replace(texto, "{", "_")
            texto = Replace(texto, "}", "_")
            texto = Replace(texto, "[", "_")
            texto = Replace(texto, "]", "_")
            texto = Replace(texto, "ª", "_")
            texto = Replace(texto, "º", "_")
            texto = Replace(texto, "°", "_")
            texto = Replace(texto, "|", "_")
            texto = Replace(texto, ",", "_")
            texto = Replace(texto, ":", "_")
            texto = Replace(texto, ";", "_")
            texto = Replace(texto, "^", "_")
            texto = Replace(texto, "~", "_")
            texto = Replace(texto, ",", "_")
            texto = Replace(texto, Chr(166), "_")
            texto = Replace(texto, Chr(167), "_")
            texto = Replace(texto, Chr(248), "_")
            texto = Replace(texto, Chr(176), "_")
            texto = Replace(texto, Chr(186), "_")
        End If

        Return texto
    End Function

    Public Shared Function CompletaZero(ByVal txt_texto As String, ByVal cod_quantidade As Integer) As String
        While Len(txt_texto) < cod_quantidade
            txt_texto = "0" & txt_texto
        End While

        Return txt_texto
    End Function

    Public Shared Function MontaArrayQuery(ByVal txt_valor As String) As String
        Dim retorno As String = String.Empty

        retorno = Replace(txt_valor, "][", ",")
        retorno = Replace(retorno, "]", "")
        retorno = Replace(retorno, "[", "")

        Return trim(retorno)
    End Function
End Class
