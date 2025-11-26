CREATE TABLE Utilisateur (
	id INT IDENTITY(1,1) PRIMARY KEY,
	prenom VARCHAR(50) NOT NULL,
	nom VARCHAR(50) NOT NULL,
	numero_classe INT NOT NULL,
	date_diplome DATE NOT NULL
);

INSERT INTO Utilisateur (prenom, nom, numero_classe, date_diplome)
VALUES ('Titi', 'Tutu', 25, '2014-07-15'),
('Toto', 'Tata', 12, '1996-06-12');

SELECT * FROM Utilisateur