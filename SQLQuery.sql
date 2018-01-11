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
    SELECT SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[sp_DeleteBook]
	@BookID int
AS
    UPDATE Books SET Count = 0 WHERE BookID = @BookID
GO

CREATE PROCEDURE [dbo].[sp_BuyBook]
	@UserID int,
	@BookID int
AS
    UPDATE Books SET Count = Count - 1 WHERE BookID = @BookID
	INSERT INTO Baskets (UserID, BookID) Values (@UserID, @BookID)
GO

CREATE PROCEDURE [dbo].[sp_InsertStartToTable]
AS
    INSERT INTO Users (Name, Password, Level) Values ('admin', 'AOc8Pb2btBm2VxOZpQq0Zef3D3mRkRuG/sanq/yHcPMI9c2bPM07PxBkbMg+xT9Ibg==', 1);
	INSERT INTO Genres (Name) Values ('Фантастика');
	INSERT INTO Publishs (Name) Values ('Глобус');
	INSERT INTO Autors (Surname, Name, Patronymic) Values ('Пушкин', 'Александр', 'Сергеевич')
GO

CREATE PROCEDURE [dbo].[sp_InsertBook]
	@Name text,
	@GenreID int,
	@AutorID int,
	@Year int,
	@PublishID int,
	@Price int,
	@Count int
AS
    Insert into Books (Name, GenreID, AutorID, Year, PublishID, Price, Count) Values (@Name, @GenreID, @AutorID, @Year, @PublishID, @Price, @Count)
GO

CREATE PROCEDURE [dbo].[sp_InsertAutor]
	@Surname text,
	@Name text,
	@Patronymic text
AS
    Insert into Autors (Surname, Name, Patronymic) Values (@Surname, @Name, @Patronymic)
GO

CREATE PROCEDURE [dbo].[sp_InsertGenre]
	@Name text
AS
    Insert into Genres (Name) Values (@Name)
GO

CREATE PROCEDURE [dbo].[sp_InsertPublish]
	@Name text
AS
    Insert into Publishs (Name) Values (@Name)
GO

CREATE PROCEDURE [dbo].[sp_BasketSelect]
	@UserID int
AS
    SELECT Books.Name FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID
GO

CREATE PROCEDURE [dbo].[sp_BookTableSelect]
AS
    SELECT BookID as ID, Books.Name as Название, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') as Автор, Year as Год, Genres.Name as Жанр, Publishs.Name as Издательство, Books.Price as Стоимость, Books.Count as Количество FROM Books INNER JOIN Autors ON Books.AutorID = Autors.AutorID INNER JOIN Genres ON Books.GenreID=Genres.GenreID INNER JOIN Publishs ON Publishs.PublishID=Books.PublishID
GO

CREATE PROCEDURE [dbo].[sp_EditBook]
	@Name text,
	@GenreID int,
	@AutorID int,
	@Year int,
	@PublishID int,
	@Price int,
	@Count int,
	@BookID int
AS
    UPDATE Books SET Name = @Name, GenreID = @GenreID, AutorID = @AutorID, Year = @Year, PublishID = @PublishID, Price = @Price, Count = @Count WHERE BookID = @BookID
GO

CREATE PROCEDURE [dbo].[sp_EditAutor]
	@Name text,
	@Surname text,
	@Patronymic text,
	@AutorID int
AS
    UPDATE Autors SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic WHERE AutorID = @AutorID
GO

CREATE PROCEDURE [dbo].[sp_EditGenre]
	@Name text,
	@GenreID int
AS
    UPDATE Genres SET Name = @Name WHERE GenreID = @GenreID
GO

CREATE PROCEDURE [dbo].[sp_EditPublish]
	@Name text,
	@PublishID int
AS
    UPDATE Publishs SET Name = @Name WHERE PublishID = @PublishID
GO