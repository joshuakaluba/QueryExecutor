CREATE TABLE Student
(
ID int IDENTITY,
LastName varchar(255),
FirstName varchar(255),
StreetAddress varchar(255)
);

INSERT INTO Student (LastName, FirstName, StreetAddress) Values ('Smith','James','123 Sessame Street');
INSERT INTO Student (LastName, FirstName, StreetAddress) Values ('Bond','James','123 Brooklyn Ave');
INSERT INTO Student (LastName, FirstName, StreetAddress) Values ('Taylor','Wayne','940 Michigan Lane');