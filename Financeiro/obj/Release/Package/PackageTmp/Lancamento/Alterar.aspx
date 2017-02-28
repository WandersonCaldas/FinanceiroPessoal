<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Alterar.aspx.vb" Inherits="Financeiro.Alterar1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script src="../Scripts/jquery.maskedinput.js"></script>
    <script src="../Scripts/jquery.moneymask.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#MainContent_dt_vencimento").datepicker(
              {
                  buttonImage: '../Imagens/Calendar-icon.png',
                  buttonImageOnly: true,
                  changeMonth: true,
                  changeYear: true,
                  showOn: 'both',
                  monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
           'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                  monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun',
                  'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                  dayNames: ['Domingo', 'Segunda-feira', 'Terça-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
                  dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                  dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                  dateFormat: 'dd/mm/yy',
              });

            $("#MainContent_dt_pagamento").datepicker(
              {
                  buttonImage: '../Imagens/Calendar-icon.png',
                  buttonImageOnly: true,
                  changeMonth: true,
                  changeYear: true,
                  showOn: 'both',
                  monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
           'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                  monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun',
                  'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                  dayNames: ['Domingo', 'Segunda-feira', 'Terça-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
                  dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                  dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                  dateFormat: 'dd/mm/yy',
              });
        });        
  </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        LANÇAMENTOS > INCLUIR
    </h2>
    <div id="div" align="center" runat="server">
        <asp:HiddenField ID="cod_lancamento" runat="server" />           
        <asp:HiddenField ID="acao" runat="server" />           
        <asp:Label ID="LbResultado" runat="server" Text="" Font-Bold="True" CssClass="failureNotification" ForeColor="Red"></asp:Label> 
        <table>
            <tr>
                <th><label class="col-2 col-form-label">Despesa</label></th>                
                <th><label class="col-2 col-form-label">Ano</label></th>
                <th><label class="col-2 col-form-label">Mês</label></th>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="cod_despesa" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="v_cod_despesa" runat="server" ControlToValidate="cod_despesa" ErrorMessage="Campo obrigatório." />                                   
                </td>            
                <td>
                    <asp:DropDownList ID="cod_ano" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="v_cod_ano" runat="server" ControlToValidate="cod_ano" ErrorMessage="Campo obrigatório." />                   
                </td>
                <td>
                    <asp:DropDownList ID="cod_mes" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="v_cod_mes" runat="server" ControlToValidate="cod_mes" ErrorMessage="Campo obrigatório." />                   
                </td>        
            </tr>  
            <tr>
                <th>
                    <label class="col-2 col-form-label">Vencimento</label>
                </th>
                <th>
                    <label class="col-2 col-form-label">Valor da Despesa</label>
                </th>
            </tr>    
            <tr>
                <td>
                    <asp:TextBox CssClass="form-control" ID="dt_vencimento" runat="server" Width="91px"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="v_dt_vencimento" runat="server" ControlToValidate="dt_vencimento" ErrorMessage="Campo obrigatório." />                   
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="txt_valor_despesa" runat="server" Width="91px"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="v_txt_valor_despesa" runat="server" ControlToValidate="txt_valor_despesa" ErrorMessage="Campo obrigatório." />                   
                </td>
            </tr>   
            <tr>
                <th><label class="col-2 col-form-label">Pagamento</label></th>
                <th><label class="col-2 col-form-label">Valor do Pagamento</label></th>
            </tr>    
            <tr>
                <td>
                    <asp:TextBox CssClass="form-control" ID="dt_pagamento" runat="server" Width="91px"></asp:TextBox>                     
                </td>
                 <td>
                    <asp:TextBox CssClass="form-control" ID="txt_valor_pagamento" runat="server" Width="91px"></asp:TextBox>                     
                </td>
            </tr>              
        </table>
                           
        <div class="form-group row">
            <label for="example-text-input" class="col-2 col-form-label">Descrição</label>
            <div class="col-10">
                <textarea CssClass="form-control" ID="txt_descricao" runat="server" rows="5" cols="50"></textarea>                 
            </div>
        </div>
        <div class="form-group row">
            <asp:Button ID="btn_alterar" runat="server" Text="Salvar" CssClass="btn btn-secondary" />
            <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CssClass="btn btn-secondary" />
            <input id="btn_voltar" type="button" value="Voltar" class="btn btn-secondary" onclick="self.location.href = '../Default.aspx'" />
        </div>
    </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $("#MainContent_dt_vencimento").mask("99/99/9999", { placeholder: " " });
                $("#MainContent_dt_pagamento").mask("99/99/9999", { placeholder: " " });

                $('#MainContent_txt_valor_pagamento').maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
                $('#MainContent_txt_valor_despesa').maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
            });
    </script>
</asp:Content>
