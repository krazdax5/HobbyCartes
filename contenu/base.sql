DROP TABLE IF EXISTS message;
DROP TABLE IF EXISTS commentaire;
DROP TABLE IF EXISTS fiche;
DROP TABLE IF EXISTS editeur;
DROP TABLE IF EXISTS equipe;
DROP TABLE IF EXISTS collection;
DROP TABLE IF EXISTS membre;

CREATE TABLE membre(
	idmembre INTEGER PRIMARY KEY AUTO_INCREMENT,
	prenom VARCHAR(30) NOT NULL,
	nom VARCHAR(30) NOT NULL,
	nomutilisateur VARCHAR(30) NOT NULL UNIQUE,
	motpasse VARCHAR(30) NOT NULL,
	ville VARCHAR(30) NOT NULL,
	codepostal VARCHAR(6) NOT NULL,
	courriel VARCHAR(30) NOT NULL,
	admin BOOLEAN NOT NULL DEFAULT FALSE,
	arriereplan VARCHAR(30)
);

CREATE TABLE message(
	idmess INTEGER PRIMARY KEY AUTO_INCREMENT,
	iddestinataire INTEGER NOT NULL,
	iddestinateur INTEGER NOT NULL,
	objet VARCHAR(30),
	mess LONGTEXT NOT NULL,
	FOREIGN KEY(iddestinataire) REFERENCES membre(idmembre),
	FOREIGN KEY(iddestinateur) REFERENCES membre(idmembre)
);

CREATE TABLE collection(
	idcollection INTEGER PRIMARY KEY AUTO_INCREMENT,
	idmembre INTEGER NOT NULL,
	type ENUM('hockey', 'baseball', 'football', 'basketball') NOT NULL,
	FOREIGN KEY(idmembre) REFERENCES membre(idmembre)
);

CREATE TABLE editeur(
	idediteur INTEGER PRIMARY KEY AUTO_INCREMENT,
	nom VARCHAR(30) NOT NULL
);

CREATE TABLE equipe(
	idequipe INTEGER PRIMARY KEY AUTO_INCREMENT,
	nom VARCHAR(30) NOT NULL
);

CREATE TABLE fiche(
	idfiche INTEGER PRIMARY KEY AUTO_INCREMENT,
	idcollection INTEGER NOT NULL,
	idediteur INTEGER NOT NULL,
	idequipe INTEGER NOT NULL,
	annee DATE NOT NULL,
	nomjoueur VARCHAR(30) NOT NULL,
	prenomjoueur VARCHAR(30) NOT NULL,
	nojoueur INTEGER NOT NULL,
	recrue BOOLEAN NOT NULL DEFAULT FALSE,
	position VARCHAR(30) NOT NULL,
	numerotation VARCHAR(15),
	valeur FLOAT(15,2) NOT NULL,
	etat ENUM('impeccable', 'bonne', 'moyenne', 'passable', 'pietre') NOT NULL,
	imagedevant VARCHAR(30) NOT NULL,
	imagederriere VARCHAR(30) NOT NULL,
	publicationsursite DATETIME NOT NULL,
	FOREIGN KEY(idcollection) REFERENCES collection(idcollection),
	FOREIGN KEY(idediteur) REFERENCES editeur(idediteur),
	FOREIGN KEY(idequipe) REFERENCES equipe(idequipe)
);

CREATE TABLE commentaire(
	idcommentaire INTEGER PRIMARY KEY AUTO_INCREMENT,
	idfiche INTEGER NOT NULL,
	destinateur VARCHAR(30) NOT NULL,
	message LONGTEXT NOT NULL,
	FOREIGN KEY(idfiche) REFERENCES fiche(idfiche)
);

INSERT INTO membre (prenom, nom, nomutilisateur, motpasse, ville, codepostal, courriel) 
VALUES ('Homer', 'Simpson', 'hsimpson', 'hsimpson123', 'Springfield', 'X0X0X0', 'hsimpson@test.com');
INSERT INTO membre (prenom, nom, nomutilisateur, motpasse, ville, codepostal, courriel) 
VALUES ('Jean-François', 'Collin', 'jfcollin', 'jfcollin123','Lévis','G1Q1Q9', 'jfcollin@test.com');
INSERT INTO membre (prenom, nom, nomutilisateur, motpasse, ville, codepostal, courriel) 
VALUES ('Loïc', 'Vial', 'lvial', 'lvial123','Lévis','G1Q1Q9', 'lvial@test.com');
INSERT INTO membre (prenom, nom, nomutilisateur, motpasse, ville, codepostal, courriel) 
VALUES ('Charles', 'Lesveque', 'clevesque', 'clevesque123','Lévis','G1Q1Q9', 'clesveque@test.com');
INSERT INTO membre (prenom, nom, nomutilisateur, motpasse, ville, codepostal, courriel, admin) 
VALUES ('Admin', 'Nistrateur', 'admin', 'admin123','Lévis','G1Q1Q9', 'admin@test.com', TRUE);

INSERT INTO collection (idmembre, type) VALUES (1, 'hockey');
INSERT INTO collection (idmembre, type) VALUES (2, 'baseball');
INSERT INTO collection (idmembre, type) VALUES (3, 'basketball');
INSERT INTO collection (idmembre, type) VALUES (1, 'football');
INSERT INTO collection (idmembre, type) VALUES (4, 'hockey');

INSERT INTO equipe (nom) VALUES ('Bruins');
INSERT INTO equipe (nom) VALUES ('Flyers');
INSERT INTO equipe (nom) VALUES ('Canadiens');
INSERT INTO equipe (nom) VALUES ('Hurricane');

INSERT INTO editeur (nom) VALUES ('Upper Deck');
INSERT INTO editeur (nom) VALUES ('Score');
INSERT INTO editeur (nom) VALUES ('Pinnacle');

INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('1','1', '1','2005-01-01','Crosby','Sidney','87','0','Centre', '50.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2012-09-20 15:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('2','2', '2','2008-01-01','Jo','Blo','22','0','Gardien', '10.00','pietre','img/avant.jpg',
'img/arriere.jpg','2011-09-20 14:28');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('1','1', '3','1982-01-01','Wayne','Gretzky','99','0','Gardien', '10.00','passable','img/avant.jpg',
'img/arriere.jpg','2012-09-22 14:32');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('3','1', '3','2007-01-01','Michael','Jordan','17','1','Centre', '100.00','bonne','img/avant.jpg',
'img/arriere.jpg','2012-09-24 10:37');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('4','1', '3','2001-01-01','Jo','Lacrasse','69','1','Centre', '69.69','bonne','img/avant.jpg',
'img/arriere.jpg','2012-09-12 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('1','2', '1','2001-01-01','Joe','Lamerveille','6','0','Defenseur', '2.00','passable','img/avant.jpg',
'img/arriere.jpg','2011-09-12 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('3','2', '1','2001-01-01','Pat','Lacraque','67','0','Ailier droit', '12.00','passable','img/avant.jpg',
'img/arriere.jpg','2010-09-12 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite) 
VALUES ('4','2', '1','2007-01-01','Max','Lefou','98','0','Centre', '112.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2009-09-19 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite)
VALUES ('5','2', '1','2007-01-01','Sam','Letrou','98','0','Centre', '1112.00','bonne','img/avant.jpg',
'img/arriere.jpg','2009-09-19 12:45');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite)
VALUES ('5','2', '1','2007-01-01','Gino','Camaro','18','0','Gardien', '12.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2009-08-19 13:48');
INSERT INTO fiche (idcollection, idediteur, idequipe, annee, nomjoueur, prenomjoueur, nojoueur, recrue, position, 
valeur, etat, imagedevant, imagederriere, publicationsursite)
VALUES ('2','3', '3','1997-01-01','Dany','Lamarre','18','0','Centre', '125.00','impeccable','img/avant.jpg',
'img/arriere.jpg','2010-08-18 13:48');

INSERT INTO commentaire (idfiche,destinateur, message) VALUES ('1','hsimpson','Ceci est un test');
INSERT INTO commentaire (idfiche,destinateur, message) VALUES ('3','lvial','Ceci est un autre test');
INSERT INTO commentaire (idfiche,destinateur, message) VALUES ('2','clevesque','Ceci est un autre autre test');
INSERT INTO commentaire (idfiche,destinateur, message) VALUES ('1','jfcollin','Assez les tests !');
INSERT INTO commentaire (idfiche,destinateur, message) VALUES ('1','jfcollin','pk !');
INSERT INTO commentaire (idfiche,destinateur, message) VALUES ('1','jfcollin','pas !');

INSERT INTO message (iddestinataire, iddestinateur, objet, mess) 
VALUES ('1','2','Belles cartes', 'Mon dieu que tu as de belles cartes!');
INSERT INTO message (iddestinataire, iddestinateur, objet, mess)
VALUES ('2','3','Wow', 'Que de belles cartes je suis sans mot!');
INSERT INTO message (iddestinataire, iddestinateur, objet, mess)
VALUES ('3','1','Ouf', 'Tes cartes sont vraiment de la merde!');






