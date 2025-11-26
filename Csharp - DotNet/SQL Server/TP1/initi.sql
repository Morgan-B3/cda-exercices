CREATE TABLE People (
   id INT PRIMARY KEY IDENTITY(1,1), -- Unique ID for each person
   first_name NVARCHAR(50) NOT NULL, -- First name of the person
   last_name NVARCHAR(50) NOT NULL, -- Last name of the person
   age INT, -- Age of the person
   phone_number NVARCHAR(20), -- Phone number of the person
   address NVARCHAR(100), -- Address of the person
);

-- Table for dogs
CREATE TABLE Dogs (
   id INT PRIMARY KEY IDENTITY(1,1), -- Unique ID for each dog
   name NVARCHAR(50) NOT NULL, -- Name of the dog
   breed NVARCHAR(50), -- Breed of the dog
   age INT, -- Age of the dog
   size DECIMAL(5,2), -- Size (in cm) of the dog
   weight DECIMAL(5,2), -- Weight (in kg) of the dog
   owner_id INT, -- Foreign key referencing Person
   FOREIGN KEY (owner_id) REFERENCES People(id)
);

INSERT INTO People (first_name, last_name, age, phone_number, address)
VALUES 
   ('Tintin', 'Dupont', 30, '1234567890', '123 Rue du Temple'),
   ('Asterix', 'Gaulois', 40, '9876543210', '456 Village Gaulois'),
   ('Sherlock', 'Holmes', 45, '5554443333', '123 Main St'),
   ('Hercule', 'Poirot', 50, '4443332222', '11 Rue du Luxembourg'),
   ('Gandalf', 'Le Gris', 1000, '1112223333', 'Hobbiton'),
   ('Luke', 'Skywalker', 28, '9988776655', 'Tatooine'),
   ('Harry', 'Potter', 35, '5556667777', '4 Privet Drive'),
   ('Daenerys', 'Targaryen', 32, '8887776666', 'Meereen'),
   ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
   ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

INSERT INTO Dogs (name, breed, age, size, weight, owner_id)
VALUES 
   ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1),
   ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), 
   ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), 
   ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), 
   ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5),
   ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), 
   ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7),
   ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), 
   ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, NULL),
   ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), 
   ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), 
   ('Pepette', 'Rottweiler', 6, 60.0, 40.0, 5), 
   ('Princesse', 'Dobermann', 4, 50.0, 30.0, 5), 
   ('Rex', 'Dalmatian', 2, 45.0, 25.0, 5), 
   ('Trixie', 'Poodle', 5, 30.0, 12.0, 5), 
   ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), 
   ('Pikachu', 'Corgi', 2, 25.0, 10.0, 8), 
   ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), 
   ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), 
   ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), 
   ('Max', 'Labrador', 5, 55.0, 30.0, NULL), 
   ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, 8),
   ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), 
   ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), 
   ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); 