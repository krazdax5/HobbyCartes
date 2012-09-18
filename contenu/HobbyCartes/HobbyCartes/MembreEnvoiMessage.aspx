<%@ Page Language="vb" MasterPageFile="~/Membre.master" CodeBehind="MembreEnvoiMessage.aspx.vb" Inherits="HobbyCartes.MembreEnvoiMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoimessage">
        <h1>Envoyer un message à Homer Simpson</h1>
        <p>
            Objet : <asp:TextBox ID="txtObjet" runat="server" Columns="100" /><br />
        </p>
        <p>
            Contenu : <br />
            <asp:TextBox ID="txtContenu" TextMode="MultiLine" Rows="20" Columns="80" runat="server" />
        </p>
        <p id="btnEnvoyer">
            <asp:Button runat="server" Text="Envoyer" />
        </p>
    </div>
</asp:Content>
