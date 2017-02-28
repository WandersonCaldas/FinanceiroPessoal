<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Visualizar.aspx.vb" Inherits="Financeiro.Visualizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        DESPESAS > <asp:Label ID="lbExibir" runat="server" Text="Label"></asp:Label>
    </h2>
    <div id="div" align="center" runat="server">
        <asp:HiddenField ID="cod_despesa" runat="server" />
        <asp:HiddenField ID="acao_confirma" runat="server" />   
        <asp:Label ID="LbResultado" runat="server" Text="" Font-Bold="True" CssClass="failureNotification"></asp:Label> 
        <div class="form-group row">
            <label for="example-text-input" class="col-2 col-form-label">Despesa</label>
            <div class="col-10">                
                <asp:Label ID="txt_despesa" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <label for="example-text-input" class="col-2 col-form-label">Descrição</label>
            <div class="col-10">                
                <asp:Label ID="txt_descricao" runat="server" Text="Label"></asp:Label>                     
            </div>
        </div>
        <div class="form-group row">         
            <asp:Button ID="btn_ativar" runat="server" Text="Reativar" Visible="false" CssClass="btn btn-secondary" />
            <asp:Button ID="btn_excluir" runat="server" Text="Cancelar" Visible="false" CssClass="btn btn-secondary" />   
            <input id="btn_voltar" type="button" value="Voltar" class="btn btn-secondary" onclick="self.location.href = 'Default.aspx'" />
        </div>
    </div>
</asp:Content>
