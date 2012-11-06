DROP TABLE IF EXISTS message;
DROP TABLE IF EXISTS commentaire;
DROP TABLE IF EXISTS fiche;
DROP TABLE IF EXISTS editeur;
DROP TABLE IF EXISTS equipe;
DROP TABLE IF EXISTS collection;
DROP TABLE IF EXISTS membre;

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
	FOREIGN KEY(iddestinataire) REFERENCES membre(idmembre),
	FOREIGN KEY(iddestinateur) REFERENCES membre(idmembre)
);

CREATE TABLE collection(
	idcollection INTEGER PRIMARY KEY AUTO_INCREMENT,
	idmembre INTEGER NOT NULL,
	typecol ENUM('hockey', 'baseball', 'football', 'basketball') NOT NULL,
	FOREIGN KEY(idmembre) REFERENCES membre(idmembre)
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
	imagedevantfi VARCHAR(30) NOT NULL,
	imagederrierefi VARCHAR(30) NOT NULL,
	publicationsursitefi DATETIME NOT NULL,
	FOREIGN KEY(idcollection) REFERENCES collection(idcollection),
	FOREIGN KEY(idediteur) REFERENCES editeur(idediteur),
	FOREIGN KEY(idequipe) REFERENCES equipe(idequipe)
);

CREATE TABLE commentaire(
	idcommentaire INTEGER PRIMARY KEY AUTO_INCREMENT,
	idfiche INTEGER NOT NULL,
	destinateurcom VARCHAR(30) NOT NULL,
	messagecom LONGTEXT NOT NULL,
	FOREIGN KEY(idfiche) REFERENCES fiche(idfiche)
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
VALUES ('Admin', 'Nistrateur', 'admin', '6ZIKdw0V70tLQGA2UXpNozu4DhQtKkrrsB5hzaM4Za/diYmLrRbZtv7Nu9yVOb2j','Lévis','G1Q1Q9', 'admin@test.com', TRUE, '2012-10-30 15:28', "img/loup.jpg");
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

INSERT INTO editeur (nomed) VALUES ('Upper Deck');
INSERT INTO editeur (nomed) VALUES ('Score');
INSERT INTO editeur (nomed) VALUES ('Pinnacle');

INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('1','1', '1','2005-01-01','Crosby','Sidney','87','0','Centre', '50.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2012-09-20 15:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('2','2', '2','2008-01-01','Jo','Blo','22','0','Gardien', '10.00','pietre','img/avant.jpg',
'img/arriere.jpg',CURDATE());
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('1','1', '3','1982-01-01','Wayne','Gretzky','99','0','Gardien', '10.00','passable','img/avant.jpg',
'img/arriere.jpg','2012-09-22 14:32');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('3','1', '3','2007-01-01','Michael','Jordan','17','1','Centre', '100.00','bonne','img/avant.jpg',
'img/arriere.jpg','2012-09-24 10:37');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi)
VALUES ('4','1', '3','2001-01-01','Jo','Lacrasse','69','1','Centre', '69.69','bonne','img/avant.jpg',
'img/arriere.jpg','2012-09-12 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi)
VALUES ('1','2', '1','2001-01-01','Joe','Lamerveille','6','0','Defenseur', '2.00','passable','img/avant.jpg',
'img/arriere.jpg','2011-09-12 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi) 
VALUES ('3','2', '1','2001-01-01','Pat','Lacraque','67','0','Ailier droit', '12.00','passable','img/avant.jpg',
'img/arriere.jpg','2010-09-12 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi)
VALUES ('4','2', '1','2007-01-01','Max','Lefou','98','0','Centre', '112.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2009-09-19 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi)
VALUES ('5','2', '1','2007-01-01','Sam','Letrou','98','0','Centre', '1112.00','bonne','img/avant.jpg',
'img/arriere.jpg','2009-09-19 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi)
VALUES ('5','2', '1','2007-01-01','Gino','Camaro','18','0','Gardien', '12.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2009-08-19 13:48');
INSERT INTO fiche (idcollection, idediteur, idequipe, anneefi, nomjoueurfi, prenomjoueurfi, nojoueurfi, recruefi, 
positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi, publicationsursitefi)
VALUES ('2','3', '3','1997-01-01','Dany','Lamarre','18','0','Centre', '125.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2010-08-18 13:48');

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
VALUES ('1','3','Ouf', 'Tes cartes sont vraiment de la merde!');





