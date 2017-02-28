Imports Microsoft.VisualBasic

Public Class ResponseStatus
    Public Shared ReadOnly SUCESSO As New ResponseStatus(0, "SUCESSO")
    Public Shared ReadOnly FALHA As New ResponseStatus(1, "FALHA")

    Private _codigo As Integer
    Private _txt As String

    Private Sub New(ByVal codigo As Integer, ByVal txt As String)
        _codigo = codigo
        _txt = txt
    End Sub

    Sub New()

    End Sub

    <System.Xml.Serialization.XmlAttribute()> _
    Public Property Codigo As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    <System.Xml.Serialization.XmlAttribute()> _
    Public Property Texto As String
        Get
            Return _txt
        End Get

        Set(ByVal value As String)
            _txt = value
        End Set

    End Property
End Class
