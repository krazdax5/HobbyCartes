<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HobbyCartes.master" CodeBehind="rapport.aspx.vb" Inherits="HobbyCartes.rapport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
<ul id="ulRapport">
    <li><asp:LinkButton CssClass="lnkbtnAdmin" ID="lkbtnRetour" runat="server" PostBackUrl="~/Administration.aspx" Font-Size="XX-Large" Text="Retour" /></li>
</ul>
    
    <br />
    <br />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" GroupTreeImagesFolderUrl="" Height="1202px" 
        ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" 
        ToolPanelView="None" ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="rapport_hobbycartes.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
