Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports MySql
Imports MySql.Data.MySqlClient

Public Class Conexao
    Public Shared Function ObterConexaoAberta() As MySqlConnection
        Dim MysqlConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("MySqlConnectionString").ConnectionString)

        If MysqlConn.State = ConnectionState.Closed Then
            MysqlConn.Open()
        End If

        Return MysqlConn
    End Function

    Public Shared Function IniciarTransacao(ByRef SqlConn As MySqlConnection) As MySqlTransaction
        Dim MysqlTrans As MySqlTransaction
        MysqlTrans = SqlConn.BeginTransaction(IsolationLevel.ReadCommitted)

        Return MysqlTrans
    End Function

    Public Shared Sub CommitTransacao(ByRef transacao As MySqlTransaction)
        transacao.Commit()
    End Sub

    Public Shared Sub RollBackTransacao(ByRef transacao As MySqlTransaction)
        transacao.Rollback()
    End Sub
End Class
