CREATE PROCEDURE [dbo].[sp_CreateTables]
AS
    CREATE TABLE Publishs (PublishID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null);
    CREATE TABLE Genres (GenreID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null);
    CREATE TABLE Users (UserID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null, Password Text not null, Level int not null);
    CREATE TABLE Autors (AutorID int IDENTITY(1,1) PRIMARY KEY, Surname VarChar(30) not null, Name VarChar(30) not null, Patronymic VarChar(30));
    CREATE TABLE Books (BookID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null, GenreID int FOREIGN KEY REFERENCES Genres(GenreID), AutorID int FOREIGN KEY REFERENCES Autors(AutorID), PublishID int FOREIGN KEY REFERENCES Publishs(PublishID), Year int not null, Price int not null, Count int not null);
    CREATE TABLE Baskets (UserID int FOREIGN KEY REFERENCES Users(UserID), BookID int FOREIGN KEY REFERENCES Books(BookID));
    CREATE TABLE Orders (OrderID int IDENTITY(1,1) PRIMARY KEY, UserID int FOREIGN KEY REFERENCES Users(UserID)) 
GO

CREATE PROCEDURE [dbo].[sp_SignUp]
    @Name text,
    @Password text,
	@Level int
AS
    INSERT INTO Users (Name, Password, Level) Values (@Name, @Password, @Level)
GO