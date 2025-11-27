CREATE TABLE Client (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	adresse VARCHAR(50) NOT NULL,
	code_postal VARCHAR(50) NOT NULL,
	ville VARCHAR(50) NOT NULL,
	telephone VARCHAR(50) NOT NULL
);

CREATE TABLE Commande (
	id INT IDENTITY(1,1) PRIMARY KEY,
	client_id INT,
	date DATETIME2 NOT NULL,
	total DECIMAL NOT NULL,
	CONSTRAINT fk_client_commande_client_id FOREIGN KEY(client_id) REFERENCES client(id)
);