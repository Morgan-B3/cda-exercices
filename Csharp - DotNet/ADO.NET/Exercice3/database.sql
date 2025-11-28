CREATE TABLE Livre (
	id INT IDENTITY(1,1) PRIMARY KEY,
	titre VARCHAR(50),
	auteur VARCHAR(50),
	isbn VARCHAR(50),
	annee_publication VARCHAR(50),
	est_disponible BIT
);

CREATE TABLE Membre (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nom VARCHAR(50),
	prenom VARCHAR(50),
	email VARCHAR(50),
	date_inscription DATETIME2
);

CREATE TABLE Emprunt (
	id INT IDENTITY(1,1) PRIMARY KEY,
	livre_id INT,
	membre_id INT,
	date_emprunt DATETIME2,
	date_retour DATETIME2,
	CONSTRAINT fk_membre_emprunt_membre_id FOREIGN KEY(membre_id) REFERENCES membre(id),
	CONSTRAINT fk_livre_emprunt_livre_id FOREIGN KEY(livre_id) REFERENCES livre(id)
);
