<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Incluir.aspx.vb" Inherits="Financeiro.Incluir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        DESPESAS > INCLUIR
    </h2>
    <div id="div" align="center" runat="server">
        <asp:Label ID="LbResultado" runat="server" Text="" Font-Bold="True" CssClass="failureNotification"></asp:Label> 
        <div class="form-group row">
            <label for="example-text-input" class="col-2 col-form-label">Despesa</label>
            <div class="col-10">
                <asp:TextBox CssClass="form-control" ID="txt_despesa" runat="server"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="v_txt_despesa" runat="server" ControlToValidate="txt_despesa" ErrorMessage="Campo obrigatório." />                   
            </div>
        </div>
        <div class="form-group row">
            <label for="example-text-input" class="col-2 col-form-label">Descrição</label>
            <div class="col-10">
                <textarea CssClass="form-control" ID="txt_descricao" runat="server" rows="5" cols="50"></textarea>                 
            </div>
        </div>
        <div class="form-group row">
            <asp:Button ID="btn_incluir" runat="server" Text="Incluir" CssClass="btn btn-secondary" />
            <input id="btn_voltar" type="button" value="Voltar" class="btn btn-secondary" onclick="self.location.href = 'Default.aspx'" />
        </div>
    </div>
</asp:Content>
