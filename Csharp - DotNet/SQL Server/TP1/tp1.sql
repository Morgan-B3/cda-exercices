--Niveau 1 : Questions basiques
--1. Selectionnez tous les chiens avec leur nom, leur race et leur poids.
SELECT name, breed, weight FROM Dogs;
--2. Listez tous les proprietaires (prenom et nom).
SELECT first_name, last_name FROM People;
--3. Recuperez les chiens qui n'ont pas de maitre.
SELECT * FROM Dogs where owner_id is null;
--4. Selectionnez tous les chiens de race "Labrador".
SELECT * FROM Dogs where breed = 'Labrador';

--### Niveau 2 : Jointures simples (INNER JOIN)
--5. Affichez le nom des chiens avec le prenom et le nom de leur maitre.
SELECT d.name, p.first_name, p.last_name FROM Dogs as d INNER JOIN People as p ON d.owner_id = p.id;
--6. Recuperez les maitres qui possedent un chien pesant plus de 20 kg.
SELECT p.* FROM People as p INNER JOIN  Dogs as d  ON d.owner_id = p.id WHERE d.weight > 20;

--### Niveau 3 : LEFT JOIN
--7. Affichez tous les proprietaires et les chiens qu'ils possedent, y compris les proprietaires sans chien.
SELECT * FROM People as p LEFT JOIN Dogs as d ON p.id = d.owner_id;
--8. Listez tous les chiens, avec leurs maitres s'ils en ont, sinon affichez "No Owner".
SELECT d.*, ISNULL (p.first_name + ' ' + p.last_name, 'No Owner') AS OwnerName FROM Dogs as d LEFT JOIN People as p ON p.id = d.owner_id;

--### Niveau 4 : FULL OUTER JOIN
--9. Recuperez tous les chiens et tous les maitres, meme ceux sans correspondance.
SELECT d.*, p.* FROM Dogs d FULL OUTER JOIN People p ON d.owner_id = p.id;


--### Niveau 5 : Filtrage avance
--10. Affichez les chiens dont le poids est superieur a 10 kg mais inferieur a 30 kg.
SELECT * FROM Dogs WHERE weight < 30 AND weight > 10;
--11. Recuperez les chiens de maitres habitant dans la ville "123 Main St".
SELECT d.* FROM Dogs d INNER JOIN People p ON d.owner_id = p.id WHERE p.address = '123 Main St';

--### Niveau 6 : Agregats et GROUP BY
--12. Affichez le nombre de chiens pour chaque maitre.
SELECT p.id, p.first_name, p.last_name, COUNT(d.id) AS DogCount FROM People p LEFT JOIN Dogs d ON d.owner_id = p.id GROUP BY p.id, p.first_name, p.last_name;
--13. Calculez le poids total des chiens appartenant a chaque maitre.
SELECT p.id, p.first_name, p.last_name, SUM(d.weight) AS TotalDogWeight FROM People p LEFT JOIN Dogs d ON d.owner_id = p.id GROUP BY p.id, p.first_name, p.last_name;

--### Niveau 7 : Sous-requetes
--14. Recuperez les maitres qui possedent le chien le plus lourd.
SELECT p.first_name , p.last_name , d.name, d.weight FROM Dogs d INNER JOIN People p ON d.owner_id = p.id WHERE d.weight = (SELECT MAX(weight) FROM Dogs);
--15. Affichez les chiens qui ont un maitre dont l'age est superieur a 40 ans.
SELECT d.*, p.* FROM Dogs d INNER JOIN People p ON d.owner_id = p.id WHERE p.age > 40;

--### Niveau 8 : Cas complexes
--16. Listez les maitres n'ayant pas de chien.
SELECT P.*, d.owner_id FROM People p LEFT JOIN Dogs d ON d.owner_id = p.id WHERE d.owner_id is NULL;
--17. Affichez la race la plus courante parmi les chiens.
WITH BreedCounts AS (
    SELECT breed, COUNT(*) AS CountBreed
    FROM Dogs
    GROUP BY breed
),
MaxBreed AS (
    SELECT MAX(CountBreed) AS MaxCount
    FROM BreedCounts
)
SELECT b.breed, b.CountBreed
FROM BreedCounts b
JOIN MaxBreed m ON b.CountBreed = m.MaxCount;
--18. Listez tous les maitres qui possedent au moins deux chiens.
WITH DogCount AS (
    SELECT owner_id, COUNT(*) AS DogCount
    FROM Dogs
    GROUP BY owner_id
)
SELECT p.*, d.owner_id, d.DogCount FROM People p JOIN DogCount d ON p.id = d.owner_id WHERE d.DogCount >= 2;

--### Niveau 9 : FULL OUTER JOIN combine
--19. Recuperez une liste combinee de chiens sans maitres et de maitres sans chiens.
SELECT p.*, d.* FROM People p FULL OUTER JOIN Dogs d ON d.owner_id = p.id WHERE d.owner_id is null
--20. Affichez le maitre et ses chien associes avec somme de leur tailles respectives (taille du maitre et des chiens).
SELECT p.id, p.first_name, p.last_name, SUM(d.size) AS dogs_size FROM People p LEFT JOIN Dogs d ON d.owner_id = p.id GROUP BY p.id, p.first_name, p.last_name ORDER BY dogs_size DESC;