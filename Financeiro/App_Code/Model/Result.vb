Imports Microsoft.VisualBasic

Public Class Result
    Public Property cod_usuario() As Integer
        Get
            Return m_cod_usuario
        End Get
        Set(ByVal value As Integer)
            m_cod_usuario = value
        End Set
    End Property
    Private m_cod_usuario As Integer

    Public Property txt_login() As String
        Get
            Return m_txt_login
        End Get
        Set(ByVal value As String)
            m_txt_login = value
        End Set
    End Property
    Private m_txt_login As String

    Public Property txt_senha() As String
        Get
            Return m_txt_senha
        End Get
        Set(ByVal value As String)
            m_txt_senha = value
        End Set
    End Property
    Private m_txt_senha As String

    Public Property txt_nome() As String
        Get
            Return m_txt_nome
        End Get
        Set(ByVal value As String)
            m_txt_nome = value
        End Set
    End Property
    Private m_txt_nome As String

    Public Property cod_despesa() As Integer
        Get
            Return m_cod_despesa
        End Get
        Set(ByVal value As Integer)
            m_cod_despesa = value
        End Set
    End Property
    Private m_cod_despesa As Integer

    Public Property txt_despesa() As String
        Get
            Return m_txt_despesa
        End Get
        Set(ByVal value As String)
            m_txt_despesa = value
        End Set
    End Property
    Private m_txt_despesa As String

    Public Property txt_valor_despesa() As String
        Get
            Return m_txt_valor_despesa
        End Get
        Set(ByVal value As String)
            m_txt_valor_despesa = value
        End Set
    End Property
    Private m_txt_valor_despesa As String

    Public Property txt_valor_pagamento() As String
        Get
            Return m_txt_valor_pagamento
        End Get
        Set(ByVal value As String)
            m_txt_valor_pagamento = value
        End Set
    End Property
    Private m_txt_valor_pagamento As String

    Public Property txt_descricao() As String
        Get
            Return m_txt_descricao
        End Get
        Set(ByVal value As String)
            m_txt_descricao = value
        End Set
    End Property
    Private m_txt_descricao As String

    Public Property cod_lancamento() As Integer
        Get
            Return m_cod_lancamento
        End Get
        Set(ByVal value As Integer)
            m_cod_lancamento = value
        End Set
    End Property
    Private m_cod_lancamento As Integer

    Public Property dt_inclusao() As Date
        Get
            Return m_dt_inclusao
        End Get
        Set(ByVal value As Date)
            m_dt_inclusao = value
        End Set
    End Property
    Private m_dt_inclusao As Date

    Public Property dt_pagamento() As Date
        Get
            Return m_dt_pagamento
        End Get
        Set(ByVal value As Date)
            m_dt_pagamento = value
        End Set
    End Property
    Private m_dt_pagamento As Date

    Public Property dt_vencimento() As Date
        Get
            Return m_dt_vencimento
        End Get
        Set(ByVal value As Date)
            m_dt_vencimento = value
        End Set
    End Property
    Private m_dt_vencimento As Date

    Public Property cod_ativo() As Integer
        Get
            Return m_cod_ativo
        End Get
        Set(ByVal value As Integer)
            m_cod_ativo = value
        End Set
    End Property
    Private m_cod_ativo As Integer

    Public Property cod_ano() As Integer
        Get
            Return m_cod_ano
        End Get
        Set(ByVal value As Integer)
            m_cod_ano = value
        End Set
    End Property
    Private m_cod_ano As Integer

    Public Property cod_mes() As Integer
        Get
            Return m_cod_mes
        End Get
        Set(ByVal value As Integer)
            m_cod_mes = value
        End Set
    End Property
    Private m_cod_mes As Integer

    Public Property cod_chave() As String
        Get
            Return m_cod_chave
        End Get
        Set(ByVal value As String)
            m_cod_chave = value
        End Set
    End Property
    Private m_cod_chave As String

    Public Property txt_extensao() As String
        Get
            Return m_txt_extensao
        End Get
        Set(ByVal value As String)
            m_txt_extensao = value
        End Set
    End Property
    Private m_txt_extensao As String

    Public Property txt_nome_arquivo() As String
        Get
            Return m_txt_nome_arquivo
        End Get
        Set(ByVal value As String)
            m_txt_nome_arquivo = value
        End Set
    End Property
    Private m_txt_nome_arquivo As String

    Public Property cod_tamanho_arquivo() As Integer
        Get
            Return m_cod_tamanho_arquivo
        End Get
        Set(ByVal value As Integer)
            m_cod_tamanho_arquivo = value
        End Set
    End Property
    Private m_cod_tamanho_arquivo As Integer

    Public Property byteArquivo() As Byte()
        Get
            Return m_byteArquivo
        End Get
        Set(ByVal value As Byte())
            m_byteArquivo = value
        End Set
    End Property
    Private m_byteArquivo As Byte()

    Public Property txt_mensagem() As String
        Get
            Return m_txt_mensagem
        End Get
        Set(ByVal value As String)
            m_txt_mensagem = value
        End Set
    End Property
    Private m_txt_mensagem As String

    Public Property txt_status() As String
        Get
            Return m_txt_status
        End Get
        Set(ByVal value As String)
            m_txt_status = value
        End Set
    End Property
    Private m_txt_status As String
End Class
