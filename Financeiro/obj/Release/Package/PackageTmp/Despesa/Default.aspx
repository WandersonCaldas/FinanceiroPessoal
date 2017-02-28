<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.vb" Inherits="Financeiro._Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Funcao.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        DESPESAS
    </h2>
    <div id="div" align="center" runat="server">
        <div align="left">
             <br />
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Despesa/Incluir.aspx">Incluir</asp:HyperLink>
            <br /> <br />
        </div>        
        <br />
                
        <div align="right">
            <asp:Label ID="txt_ativo_" runat="server" Text="Ativo:" Font-Bold="True"></asp:Label>       
            <asp:DropDownList ID="cod_ativo_" runat="server" CssClass="select input-sm" AutoPostBack="true">
                <asp:ListItem Value="1">SIM</asp:ListItem>
                <asp:ListItem Value="0">NÃO</asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:Panel ID="panSemRegistro" runat="server" BackColor="#CCFFFF">
		    <% =Mensagem.MN003.Texto %> 
        </asp:Panel> 
        <asp:GridView ID="grd" Width="100%" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" ForeColor="Black" GridLines="None" 
            OnPageIndexChanging="OnPageIndexChanging" onprerender="grd_PreRender" OnSorting="SortRecords" ClientIDMode="Static" BackColor="White" BorderColor="Tan" BorderWidth="1px">
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
                <asp:BoundField HeaderText="Ativo" SortExpression="cod_ativo" DataField="cod_ativo" HeaderStyle-HorizontalAlign="Justify" >
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
