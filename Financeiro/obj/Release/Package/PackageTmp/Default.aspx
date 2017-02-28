<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Financeiro._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
              <%--  <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>--%>
                <h1>Controle Financeiro</h1>
            </hgroup>
            <p>
               <%-- To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.--%>
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--<h3>We suggest the following:</h3>--%>
    <ol class="round">
        <h4>LANÇAMENTOS</h4>   
        <li class="one">                     
            <a href="Lancamento/Incluir.aspx">INCLUIR</a>
            <br />&nbsp;
        </li>
        <li class="two">           
            <a href="Lancamento/Pesquisar.aspx">PESQUISAR</a>
            <br />&nbsp;
        </li>
        <%--
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>--%>
    </ol>
</asp:Content>
