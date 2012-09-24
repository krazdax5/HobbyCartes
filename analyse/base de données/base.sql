DROP TABLE message;
DROP TABLE membre;
DROP TABLE collection;
DROP TABLE fiche;
DROP TABLE commentaire;
DROP TABLE editeur;
DROP TABLE equipe;

CREATE TABLE membre(
	idmembre INTEGER PRIMARY KEY,
	prenom VARCHAR(30) NOT NULL,
	nom VARCHAR(30) NOT NULL,
	nomutilisateur VARCHAR(30) NOT NULL,
	motpasse VARCHAR(30) NOT NULL,
	ville VARCHAR(30) NOT NULL,
	codepostal VARCHAR(6) NOT NULL,
	courriel VARCHAR(30) NOT NULL,
	admin BOOLEAN NOT NULL DEFAULT FALSE,
	arriereplan VARCHAR(30)
);

CREATE TABLE message(
	idmess INTEGER PRIMARY KEY,
	iddestinataire INTEGER NOT NULL,
	iddestinateur INTEGER NOT NULL,
	objet VARCHAR(30),
	mess LONGTEXT NOT NULL,
	FOREIGN KEY(iddestinataire) REFERENCES membre(idmembre),
	FOREIGN KEY(iddestinateur) REFERENCES membre(idmembre)
);

CREATE TABLE collection(
	idcollection INTEGER PRIMARY KEY,
	idmembre INTEGER NOT NULL,
	type ENUM('hockey', 'baseball', 'football', 'basketball') NOT NULL,
	FOREIGN KEY(idmembre) REFERENCES membre(idmembre)
);

CREATE TABLE editeur(
	idediteur INTEGER PRIMARY KEY,
	nom VARCHAR(30) NOT NULL
);

CREATE TABLE equipe(
	idequipe INTEGER PRIMARY KEY,
	nom VARCHAR(30) NOT NULL
);

CREATE TABLE fiche(
	idfiche INTEGER PRIMARY KEY,
	idcollection INTEGER NOT NULL,
	idediteur INTEGER NOT NULL,
	idequipe INTEGER NOT NULL,
	annee DATE NOT NULL,
	nomjoueur VARCHAR(30) NOT NULL,
	prenomjoueur VARCHAR(30) NOT NULL,
	nojoueur INTEGER NOT NULL,
	recrue BOOLEAN NOT NULL,
	position VARCHAR(30) NOT NULL,
	numerotation VARCHAR(15),
	valeur FLOAT(15,2) NOT NULL,
	etat ENUM('impeccable', 'bonne', 'moyenne', 'passable', 'pietre') NOT NULL,
	imagedevant VARCHAR(30) NOT NULL,
	imagederriere VARCHAR(30) NOT NULL,
	publicationsursite DATE NOT NULL,
	FOREIGN KEY(idcollection) REFERENCES collection(idcollection),
	FOREIGN KEY(idediteur) REFERENCES editeur(idediteur),
	FOREIGN KEY(idequipe) REFERENCES equipe(idequipe)
);

CREATE TABLE commentaire(
	idcommentaire INTEGER PRIMARY KEY,
	idfiche INTEGER NOT NULL,
	destinateur VARCHAR(30) NOT NULL,
	message LONGTEXT NOT NULL,
	FOREIGN KEY(idfiche) REFERENCES fiche(idfiche)
);