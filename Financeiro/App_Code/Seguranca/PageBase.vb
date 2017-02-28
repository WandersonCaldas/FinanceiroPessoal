Imports Microsoft.VisualBasic

Public Class PageBase
    Inherits System.Web.UI.Page

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        If IsNothing(Session("cod_usuario")) Then
            FormsAuthentication.SignOut()
            Session.Abandon()
            Response.Redirect("~/Account/Login.aspx")
        End If
    End Sub
End Class
