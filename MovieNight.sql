USE MoviesAndActors;

DROP TABLE MovieActor;
DROP TABLE Movie;
DROP TABLE Actor;

CREATE TABLE Actor
(
	ID INT PRIMARY KEY IDENTITY(1000,1),
	Firstname varChar(50),
	Lastname varChar(50)
);

CREATE TABLE Movie
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Title varChar(50),
	Genre varChar(50),
	Description varChar(500),
	Length varChar(50),
	Release_year Char(4)
);

CREATE TABLE MovieActor
(
	ID_Movie INT FOREIGN KEY REFERENCES Movie(ID),
	ID_Actor INT FOREIGN KEY REFERENCES Actor(ID),
);


INSERT INTO Actor VALUES('Adam', 'Sandler');
INSERT INTO Actor VALUES('Jennifer', 'Aniston');
INSERT INTO Actor VALUES('Luke', 'Evans');
INSERT INTO Actor VALUES('Jason', 'Sudeikis');
INSERT INTO Actor VALUES('Emma', 'Roberts');


INSERT INTO Movie VALUES('Murder Mystery', 'Action, Comedy, Crime',
	'A New York cop and his wife go on a European vacation to reinvigorate the spark in their marriage, but end up getting framed and on the run for the death of an elderly billionaire.',
		'1h 37min', '2019');
INSERT INTO Movie VALUES('We are the Millers', 'Comedy, Crime',
	'A veteran pot dealer creates a fake family as part of his plan to move a huge shipment of weed into the U.S. from Mexico.',
		'1h 50min', '2013');

INSERT INTO MovieActor VALUES(1, 1000);
INSERT INTO MovieActor VALUES(1, 1001);
INSERT INTO MovieActor VALUES(1, 1002);

INSERT INTO MovieActor VALUES(2, 1003);
INSERT INTO MovieActor VALUES(2, 1001);
INSERT INTO MovieActor VALUES(2, 1004);