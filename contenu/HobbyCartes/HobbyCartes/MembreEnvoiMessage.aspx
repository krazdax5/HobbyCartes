<%@ Page Language="vb" MasterPageFile="~/Membre.master" CodeBehind="MembreEnvoiMessage.aspx.vb" Inherits="HobbyCartes.MembreEnvoiMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoimessage">
        <p>
            Titre : <asp:TextBox ID="TextBox1" runat="server" Columns="80" /><br />
        </p>
        <p>
            Contenu : <br />
            <asp:TextBox ID="TextBox2" TextMode="MultiLine" Rows="20" Columns="80" runat="server" />
        </p>
    </div>
</asp:Content>
