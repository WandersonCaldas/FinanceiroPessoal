<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Pesquisar.aspx.vb" Inherits="Financeiro.Pesquisar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Funcao.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        LANÇAMENTOS > PESQUISAR
    </h2>
    <div id="div" align="center" runat="server">
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
                </td>            
                <td>
                    <asp:DropDownList ID="cod_ano" runat="server"></asp:DropDownList>                    
                </td>
                <td>
                    <asp:DropDownList ID="cod_mes" runat="server"></asp:DropDownList>                    
                </td>        
            </tr>  
        </table>
        <div class="form-group row">
            <asp:Button ID="btn_pesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-secondary" />
            <input id="btn_voltar" type="button" value="Voltar" class="btn btn-secondary" onclick="self.location.href = '../Default.aspx'" />
        </div>
    </div>
    <div id="div_resultado" runat="server">
         <asp:Panel ID="panSemRegistro" runat="server" BackColor="#CCFFFF">
		    <center><% =Mensagem.MN003.Texto %></center>
        </asp:Panel> 

        <asp:GridView ID="grd" Width="100%" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" ForeColor="Black" GridLines="None" 
            OnPageIndexChanging="OnPageIndexChanging" OnSorting="SortRecords" ClientIDMode="Static" BackColor="White" BorderColor="Tan" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#e7ecee" />

            <Columns>
                <asp:TemplateField HeaderText="Ação" ItemStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Justify">
				    <ItemTemplate>					    
					    <asp:DropDownList ID="ddlAcao" onchange="javascript:go(this)" runat="server">
						    <asp:ListItem Value="" Text="" />
					    </asp:DropDownList>
				    </ItemTemplate>

<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>

<ItemStyle VerticalAlign="Top"></ItemStyle>
			    </asp:TemplateField>
                <asp:BoundField HeaderText="Despesa" DataField="txt_despesa" SortExpression="txt_despesa" NullDisplayText="-" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>                        
                <asp:BoundField HeaderText="Ano" SortExpression="cod_ano" DataField="cod_ano" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Mês" SortExpression="txt_mes" DataField="txt_mes" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>
                 <asp:BoundField HeaderText="Vencimento" SortExpression="dt_vencimento" DataField="dt_vencimento" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Valor" SortExpression="txt_valor_despesa" DataField="txt_valor_despesa" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Pagamento" SortExpression="dt_pagamento" DataField="dt_pagamento" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Valor Pago" SortExpression="txt_valor_pagamento" DataField="txt_valor_pagamento" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Descrição" DataField="txt_descricao" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>                
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
    </div>
</asp:Content>
