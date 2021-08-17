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
