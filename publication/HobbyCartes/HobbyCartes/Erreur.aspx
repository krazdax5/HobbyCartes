<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" Inherits="HobbyCartes.Erreur" CodeBehind="~/Erreur.aspx.vb" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <div id="erreur">
        <h1 id="erreurTitre">Erreur</h1>
        <p id="erreurDescription" class="erreurDescription" runat="server" />
        <p>
            <asp:LinkButton id="erreurBoutonRetour" class="erreurBoutonRetour" runat="server" text="Retour a la page precedente" />
        </p>
    </div>
</asp:Content>