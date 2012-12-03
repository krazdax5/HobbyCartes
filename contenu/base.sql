/* créer un utilisateur mobby ayant tous les accès à la base de données hobbycartes et ayant le mot de passe hob_cartes5*/

DROP TABLE IF EXISTS message;
DROP TABLE IF EXISTS commentaire;
DROP TABLE IF EXISTS fiche;
DROP TABLE IF EXISTS editeur;
DROP TABLE IF EXISTS equipe;
DROP TABLE IF EXISTS collection;
DROP TABLE IF EXISTS transactions;
DROP TABLE IF EXISTS membre;

DROP TRIGGER IF EXISTS infiche;
DROP TRIGGER IF EXISTS delfiche;
DROP TRIGGER IF EXISTS inmembre;
DROP TRIGGER IF EXISTS delmembre;

DROP DATABASE IF EXISTS hobbycartes;

CREATE DATABASE hobbycartes;
USE hobbycartes;

CREATE TABLE membre(
	idmembre INTEGER PRIMARY KEY AUTO_INCREMENT,
	prenommem VARCHAR(30) NOT NULL,
	nommem VARCHAR(30) NOT NULL,
	nomutilisateurmem VARCHAR(30) NOT NULL UNIQUE,
	motpassemem TEXT NOT NULL,
	villemem VARCHAR(30) NOT NULL,
	codepostalmem VARCHAR(6) NOT NULL,
	courrielmem VARCHAR(30) NOT NULL,
	adminmem BOOLEAN NOT NULL DEFAULT FALSE,
	arriereplanmem VARCHAR(30),
	dateinscriptionmem DATETIME NOT NULL,
	imagemem VARCHAR(30)
);

CREATE TABLE message(
	idmess INTEGER PRIMARY KEY AUTO_INCREMENT,
	iddestinataire INTEGER NOT NULL,
	iddestinateur INTEGER NOT NULL,
	objetmes VARCHAR(60),
	mesmes LONGTEXT NOT NULL,
	FOREIGN KEY(iddestinataire) REFERENCES membre(idmembre) ON DELETE CASCADE,
	FOREIGN KEY(iddestinateur) REFERENCES membre(idmembre) ON DELETE CASCADE
);

CREATE TABLE collection(
	idcollection INTEGER PRIMARY KEY AUTO_INCREMENT,
	idmembre INTEGER NOT NULL,
	typecol ENUM('hockey', 'baseball', 'football', 'basketball') NOT NULL,
	FOREIGN KEY(idmembre) REFERENCES membre(idmembre) ON DELETE CASCADE
);

CREATE TABLE editeur(
	idediteur INTEGER PRIMARY KEY AUTO_INCREMENT,
	nomed VARCHAR(30) NOT NULL
);

CREATE TABLE equipe(
	idequipe INTEGER PRIMARY KEY AUTO_INCREMENT,
	nomeq VARCHAR(30) NOT NULL
);

CREATE TABLE fiche(
	idfiche INTEGER PRIMARY KEY AUTO_INCREMENT,
	idcollection INTEGER NOT NULL,
	idediteur INTEGER NOT NULL,
	idequipe INTEGER NOT NULL,
	anneefi DATE NOT NULL,
	nomjoueurfi VARCHAR(30) NOT NULL,
	prenomjoueurfi VARCHAR(30) NOT NULL,
	nojoueurfi INTEGER NOT NULL,
	recruefi BOOLEAN NOT NULL DEFAULT FALSE,
	positionfi VARCHAR(30) NOT NULL,
	numerotationfi VARCHAR(15),
	valeurfi FLOAT(15,2) NOT NULL,
	etatfi ENUM('impeccable', 'bonne', 'moyenne', 'passable', 'pietre') NOT NULL,
	imagedevantfi VARCHAR(30),
	imagederrierefi VARCHAR(30),
	publicationsursitefi DATETIME NOT NULL,
	FOREIGN KEY(idcollection) REFERENCES collection(idcollection) ON DELETE CASCADE,
	FOREIGN KEY(idediteur) REFERENCES editeur(idediteur) ON DELETE CASCADE,
	FOREIGN KEY(idequipe) REFERENCES equipe(idequipe) ON DELETE CASCADE
);

CREATE TABLE commentaire(
	idcommentaire INTEGER PRIMARY KEY AUTO_INCREMENT,
	idfiche INTEGER NOT NULL,
	destinateurcom VARCHAR(30) NOT NULL,
	messagecom LONGTEXT NOT NULL,
	FOREIGN KEY(idfiche) REFERENCES fiche(idfiche) ON DELETE CASCADE
);

CREATE TABLE transactions (
	idtransactions INTEGER PRIMARY KEY AUTO_INCREMENT,
	nomutilisateurtrans TEXT NOT NULL,
	typetrans ENUM ('ajout', 'suppression'),
	typeobjettrans ENUM ('fiche','membre'),
	datetrans DATETIME
);

INSERT INTO membre (prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, dateinscriptionmem, imagemem) 
VALUES ('Homer', 'Simpson', 'hsimpson', 'k/MSzDGfkER1OM4lE9yJLq3Z/7PeoBzvwkVpn/Vy+YoZi0P5qa+v7mPW+rU0CrTc', 'Springfield', 'X0X0X0', 'hsimpson@test.com', '2012-11-03 15:28', "img/profil.jpg");
INSERT INTO membre (prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, dateinscriptionmem, imagemem) 
VALUES ('Jean-François', 'Collin', 'jfcollin', 'BpfFWZqvZUViODQvwzyvae+JAmTYwOe1+tfhLCdpcdpqrJXnHoV/6ZoQZgfuKFCe','Lévis','G1Q1Q9', 'jfcollin@test.com', '2012-11-02 15:28', "img/jf.jpg");
INSERT INTO membre (prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, dateinscriptionmem, imagemem) 
VALUES ('Loïc', 'Vial', 'lvial', 'uVnVe/1uYgdRMd7zrLFs5d/2ctFG6Fj88vKlUdVYrD2I9hRASJ9muzDsrDIuGuFW','Lévis','G1Q1Q9', 'lvial@test.com', '2012-11-01 15:28', "img/loic.jpg");
INSERT INTO membre (prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, dateinscriptionmem, imagemem) 
VALUES ('Charles', 'Lesveque', 'clevesque', 'jP5qt+0cWzg4uAumlDUoWYPoyae8Q7JhtmhvfT35uyBCciV8Mtvm5h8xi02kez3q','Lévis','G1Q1Q9', 'clesveque@test.com', '2012-10-31 15:28', "img/charles.jpg");
INSERT INTO membre (prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, adminmem, dateinscriptionmem, imagemem) 
VALUES ('Mobby', 'Administrateur', 'mobby', 'Y2ARghqsiiZuF1OxV7xORnvHL1y+Do1lZLUy4svcAiXow8LtOgzgp232x/3mmnVx','Lévis','G1Q1Q9', 'admin@test.com', TRUE, '2012-10-30 15:28', "img/loup.jpg");
INSERT INTO membre (prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, dateinscriptionmem, imagemem) 
VALUES ('Rory', 'B. Bellows', 'rbellows', '014G4Z3mrozn8IgOl9d4WU5oPRTVIeFZRT6LHdoMhNCCe41LvkrmXhPbZFGuIA03', 'Springfield', 'X0X0X0', 'rb@test.com', '2012-10-29 15:28', "img/chevaux.jpg");

INSERT INTO collection (idmembre, typecol) VALUES (1, 'hockey');
INSERT INTO collection (idmembre, typecol) VALUES (2, 'baseball');
INSERT INTO collection (idmembre, typecol) VALUES (3, 'basketball');
INSERT INTO collection (idmembre, typecol) VALUES (1, 'football');
INSERT INTO collection (idmembre, typecol) VALUES (4, 'hockey');

INSERT INTO equipe (nomeq) VALUES ('Bruins');
INSERT INTO equipe (nomeq) VALUES ('Flyers');
INSERT INTO equipe (nomeq) VALUES ('Canadiens');
INSERT INTO equipe (nomeq) VALUES ('Hurricane');
INSERT INTO equipe (nomeq) VALUES ('Bulls');
INSERT INTO equipe (nomeq) VALUES ('Heat');
INSERT INTO equipe (nomeq) VALUES ('Colts');
INSERT INTO equipe (nomeq) VALUES ('Broncos');
INSERT INTO equipe (nomeq) VALUES ('Stealers');
INSERT INTO equipe (nomeq) VALUES ('Capitals');
INSERT INTO equipe (nomeq) VALUES ('Canadiens');


INSERT INTO editeur (nomed) VALUES ('Upper Deck');
INSERT INTO editeur (nomed) VALUES ('Score');
INSERT INTO editeur (nomed) VALUES ('Pinnacle');
INSERT INTO editeur (nomed) VALUES ('Fleer');
INSERT INTO editeur (nomed) VALUES ('Topps');
INSERT INTO editeur (nomed) VALUES ('Bowman');


INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('1','1', '1','2005-01-01','Crosby','Sidney','87','0','Centre', '50.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2012-09-20 15:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('3','4', '5','2012-01-01','Jordan','Micheal','23','0','Guard', '50.00','impeccable','img/jordan.jpg',
'img/jordanback.jpg','2012-09-20 15:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('3','2', '6','2012-01-01','James','Lebron','8','1','Forward', '100.00','impeccable','img/lebronfront.jpg',
'img/lebronback.jpg','2012-11-20 16:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('4','5', '7','2012-01-01','Luck','Andrew','12','1','Quart-arrière', '10.00','bonne','img/andrewluckfront.jpg',
'img/andrewluckback.jpg','2012-11-20 16:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('4','6', '8','2012-01-01','Maning','Peyton','18','0','Quart-arrière', '18.00','pietre','img/peytonfront.jpg',
'img/peytonback.jpg','2012-11-20 16:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('4','1', '9','2012-01-01','Polamalu','Troy','43','0','Safety', '18.50','impeccable','img/troypolamalufront.jpg',
'img/troypolamaluback.jpg','2012-11-20 16:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('1','1', '10','2012-01-01','Ovechkin','Alexander','8','0','Centre', '16.25','impeccable','img/ovifront.jpg',
'img/oviback.jpg','2012-11-20 16:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('5','1', '11','2012-01-01','Price','Carey','31','1','Gardien', '36.25','moyenne','img/pricefront.jpg',
'img/priceback.jpg','2012-10-20 16:28');

INSERT INTO commentaire (idfiche,destinateurcom, messagecom) VALUES ('1','hsimpson','Ceci est un test');
INSERT INTO commentaire (idfiche,destinateurcom, messagecom) VALUES ('3','lvial','Ceci est un autre test');
INSERT INTO commentaire (idfiche,destinateurcom, messagecom) VALUES ('2','clevesque','Ceci est un autre autre test');
INSERT INTO commentaire (idfiche,destinateurcom, messagecom) VALUES ('1','jfcollin','Assez les tests !');
INSERT INTO commentaire (idfiche,destinateurcom, messagecom) VALUES ('1','jfcollin','pk !');
INSERT INTO commentaire (idfiche,destinateurcom, messagecom) VALUES ('1','jfcollin','pas !');

INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes) 
VALUES ('1','2','Belles cartes', 'Mon dieu que tu as de belles cartes!');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('3','2','Wow', 'Que de belles cartes je suis sans mot!');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('1','3','Ouf', 'Tes cartes sont vraiment de la merde!');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('1','2','Salut', 'Je suis inutile!');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes) 
VALUES ('3','2','Offre pour ta carte de Crosby Sidney', 'Salut !\r\n
Ta carte de Crosby Sidney m''interesse beaucoup, je te propose 60$ pour son acquisition.\r\n
Ca t''interesserais ?');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('3','4','Salut toi :)', 'Je t''envoie ce message uniquement pour tester le cas d''envoi de messages, donc tu n''es pas obligé de me répondre...\r\n
Mais si tu veux tester le bouton ""Répondre"" en bas du message, fais toi plaisir.\r\n
\r\n
Bye !');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('3','2','Offre pour Wayne Gretzky', 'Salut,\r\n
je t''ai déjà fait une offre pour ta carte de Crosby, mais celle de Gretzky me plait beaucoup aussi !\r\n
Si ça te va, je te propose 100$ les deux, ok ?');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('1','2','Salut', 'Je suis inutile!');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('5','3','Long message', 'Bien le bonjour, je cherche à évaluer la capacité de la base de données à enregistrer de longs textes contenant une multitude d''âççêñt$,\r\n
des sauts de lignes, et des caractères <\'spéciaux\'>.');
INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes)
VALUES ('3','1','Ouf', 'Tes cartes sont vraiment de la merde!');





