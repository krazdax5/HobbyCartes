DELIMITER //

CREATE TRIGGER infiche 
	AFTER INSERT ON fiche 
	FOR EACH ROW
BEGIN
	INSERT INTO transactions (nomutilisateurtrans, typetrans, typeobjettrans, datetrans) 
		VALUES (
				(SELECT membre.nomutilisateurmem FROM membre
					JOIN collection ON membre.idmembre = collection.idmembre
					JOIN fiche ON collection.idcollection = fiche.idcollection
					WHERE fiche.idfiche = NEW.idfiche), 
		'ajout', 'fiche', NOW());
END	//

CREATE TRIGGER delfiche
	BEFORE DELETE ON fiche
	FOR EACH ROW
BEGIN
	INSERT INTO transactions (nomutilisateurtrans, typetrans, typeobjettrans, datetrans)
		VALUES(
			(SELECT membre.nomutilisateurmem FROM membre
				JOIN collection ON membre.idmembre = collection.idmembre
				JOIN fiche ON collection.idcollection = fiche.idcollection
				WHERE fiche.idfiche = OLD.idfiche),
			'suppression', 'fiche', NOW());
END //

CREATE TRIGGER inmembre
	AFTER INSERT ON membre
	FOR EACH ROW
BEGIN
	INSERT INTO transactions (nomutilisateurtrans, typetrans, typeobjettrans, datetrans)
		VALUES( NEW.nomutilisateurmem, 'ajout', 'membre', NOW());
END //

CREATE TRIGGER delmembre
	AFTER DELETE ON membre
	FOR EACH ROW
BEGIN
	INSERT INTO transactions (nomutilisateurtrans, typetrans, typeobjettrans, datetrans)
		VALUES (OLD.nomutilisateurmem, 'suppression', 'membre', NOW());
END //