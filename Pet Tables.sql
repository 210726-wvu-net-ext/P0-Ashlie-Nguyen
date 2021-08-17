Create Table Species (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Species varchar(100) not null
);
Create Table Color (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Color varchar(100) not null
);
Create Table Activities (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Activity varchar(100) not null
);
Create Table Animals(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(100) not null,
	SpeciesID int Foreign Key REFERENCES Species(ID) not null,
	ColorID int Foreign Key REFERENCES Color(ID) not null
);
Create Table Likes (
	ID int IDENTITY(1,1) PRIMARY KEY,
	AnimalID int Foreign Key REFERENCES Animals(ID) not null,
	ActivityID int Foreign Key REFERENCES Activities(ID) not null
);

Insert Into Species (Species) Values ('Cat');
Insert Into Species (Species) Values ('Dog');
Insert Into Species (Species) Values ('Owl');
Insert Into Species (Species) Values ('Ferret');
Insert Into Species (Species) Values ('Fancy Rat');

Select * From Species;

Insert Into Color (Color) Values ('Brown');
Insert Into Color (Color) Values ('Black');
Insert Into Color (Color) Values ('White');
Insert Into Color (Color) Values ('Orange');

Select * From Color;

Insert Into Activities (Activity) Values ('Napping');
Insert Into Activities (Activity) Values ('Playing');
Insert Into Activities (Activity) Values ('Going for walks');
Insert Into Activities (Activity) Values ('Snacking');
Insert Into Activities (Activity) Values ('Singing');
Insert Into Activities (Activity) Values ('Hunting');
Insert Into Activities (Activity) Values ('Flying');
Insert Into Activities (Activity) Values ('Swimming');
Insert Into Activities (Activity) Values ('Eating');

Select * From  Activities;

Insert Into Animals (Name, SpeciesID, ColorID) Values ('Wolf',2,2);
Insert Into Animals (Name, SpeciesID, ColorID) Values ('Margaret',4,1);
Insert Into Animals (Name, SpeciesID, ColorID) Values ('Mono',5,3);
Insert Into Animals (Name, SpeciesID, ColorID) Values ('Leo',1,1);
Insert Into Animals (Name, SpeciesID, ColorID) Values ('Stinker',1,4);
Insert Into Animals (Name, SpeciesID, ColorID) Values ('Hedwig',3,3);
Insert Into Animals (Name, SpeciesID, ColorID) Values ('Crookshanks',1,4);

Select * from Animals;

Insert Into Likes (AnimalID, ActivityID) Values (1,1);
Insert Into Likes (AnimalID, ActivityID) Values (1,2);
Insert Into Likes (AnimalID, ActivityID) Values (1,9);
Insert Into Likes (AnimalID, ActivityID) Values (2,2);
Insert Into Likes (AnimalID, ActivityID) Values (2,3);
Insert Into Likes (AnimalID, ActivityID) Values (2,8);
Insert Into Likes (AnimalID, ActivityID) Values (3,2);
Insert Into Likes (AnimalID, ActivityID) Values (3,1);
Insert Into Likes (AnimalID, ActivityID) Values (4,2);
Insert Into Likes (AnimalID, ActivityID) Values (4,4);
Insert Into Likes (AnimalID, ActivityID) Values (5,5);
Insert Into Likes (AnimalID, ActivityID) Values (5,1);
Insert Into Likes (AnimalID, ActivityID) Values (6,6);
Insert Into Likes (AnimalID, ActivityID) Values (6,7);
Insert Into Likes (AnimalID, ActivityID) Values (7,6);

Select * From Likes;