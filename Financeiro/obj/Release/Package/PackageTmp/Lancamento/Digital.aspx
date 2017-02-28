<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Digital.aspx.vb" Inherits="Financeiro.Digital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        LANÇAMENTOS > DIGITAL
    </h2>
    <div id="div" align="center" runat="server">
        <asp:HiddenField ID="cod_lancamento" runat="server" />   
        <asp:Label ID="LbResultado" runat="server" Text="" Font-Bold="True" CssClass="failureNotification"></asp:Label>
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
            <tr>                
                <th colspan="3"><label class="col-2 col-form-label"></label></th>                
            </tr>
            <tr>                
                <td colspan="3">
                    <center>
                        <asp:FileUpload ID="flp_arquivo" Width="300" runat="server" />                        
                    </center>
                </td>               
            </tr>
        </table>
        <div class="form-group row">
            <asp:Button ID="btn_incluir" runat="server" Text="Incluir" CssClass="btn btn-secondary" />                        
        </div>
        <br />
        <asp:GridView ID="grd" Width="100%" runat="server" AllowSorting="false" AutoGenerateColumns="False" CellPadding="2" ForeColor="Black" GridLines="None" 
            ClientIDMode="Static" BackColor="White" BorderColor="Tan" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#e7ecee" />

            <Columns>
                <asp:TemplateField HeaderText="Ação" ItemStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Justify">
				    <ItemTemplate>					    
					    <center>
						    <input type="checkbox" name="cod_chave" id="cod_chave" value="<%# Eval("cod_chave") %>" />
					    </center>
				    </ItemTemplate>

<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>

<ItemStyle VerticalAlign="Top"></ItemStyle>
			    </asp:TemplateField>
                <asp:BoundField HeaderText="Arquivo" DataField="txt_arquivo" NullDisplayText="-" HeaderStyle-HorizontalAlign="Justify" >
<HeaderStyle HorizontalAlign="Justify"></HeaderStyle>
                </asp:BoundField>                        
                <asp:BoundField HeaderText="Inclusão" DataField="dt_inclusao" HeaderStyle-HorizontalAlign="Justify" >
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
        
        <div class="form-group row">
            <asp:Button ID="btn_excluir" runat="server" Text="Excluir" CssClass="btn btn-secondary" />                        
        </div>
    </div>
</asp:Content>
