Imports Microsoft.VisualBasic

Public Class Mensagem
    Public Shared ReadOnly MN001 As Mensagem = New Mensagem("MN001", "{0} não encontrado.")
    Public Shared ReadOnly MN002 As Mensagem = New Mensagem("MN002", "{0} já está cadastrado.")
    Public Shared ReadOnly MN003 As Mensagem = New Mensagem("MN003", "NÃO EXISTEM REGISTROS CADASTRADOS.")
    Public Shared ReadOnly MN004 As Mensagem = New Mensagem("MN004", "{0} já está {1}.")

    Private _codigo, _txt As String
    Private Sub New(ByVal codigo As String, ByVal txt As String)
        _codigo = codigo
        _txt = txt
    End Sub

    Public ReadOnly Property Codigo As String
        Get
            Return _codigo
        End Get
    End Property

    Public ReadOnly Property Texto As String
        Get
            Return _txt
        End Get
    End Property

    Public Function TextoFormatado(ByVal ParamArray Args() As String) As String
        Return String.Format(_txt, Args)
    End Function
End Class
