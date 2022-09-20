USE master;
GO

IF DB_ID('MindboxTestDB') IS NOT NULL
	DROP DATABASE MindboxTestDB;
GO

CREATE DATABASE MindboxTestDB;
GO

BEGIN TRANSACTION;

USE MindboxTestDB;
GO

CREATE TABLE Categories(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name varchar(30) NOT NULL,
	UNIQUE(Name)
);
CREATE NONCLUSTERED INDEX IX_Categories_Name
ON Categories(Name ASC);
GO

CREATE TABLE Products(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name varchar(30) NOT NULL,
	UNIQUE(Id, Name)
);
CREATE NONCLUSTERED INDEX IX_Products_Name
ON Products(Name ASC);
GO

CREATE TABLE CategoriesProducts(
	CategoryId int,
	ProductId int,
	PRIMARY KEY(CategoryId, ProductId),
	CONSTRAINT FK_CATEGORIES FOREIGN KEY(CategoryId) 
		REFERENCES Categories (Id) ON DELETE CASCADE,
	CONSTRAINT FK_PRODUCTS FOREIGN KEY(ProductId) 
		REFERENCES Products (Id) ON DELETE CASCADE,
);

SET IDENTITY_INSERT Categories ON
INSERT INTO Categories
	(Id, Name)
VALUES
	(1, 'Electronics'),
	(2, 'Kids toys'),
	(3, 'Shoes'),
	(4, 'Clothes'),
	(5, 'Appliances'),
	(6, 'Fruits and vegetables'),
	(7, 'Furniture'),
	(8, 'Baby')
SET IDENTITY_INSERT Categories OFF

SET IDENTITY_INSERT Products ON
INSERT INTO Products
	(Id, Name)
VALUES
	(1, 'Gameboy'),
	(2, 'Pink booties'),
	(3, 'Blue booties'),
	(4, 'Romper'),
	(5, 'Apples'),
	(6, 'Peares'),
	(7, 'Tomatoes'),
	(8, 'Bread'),
	(9, 'Oven'),
	(10, 'Fridge')
SET IDENTITY_INSERT Products OFF

INSERT INTO CategoriesProducts
	(CategoryId, ProductId)
VALUES
	(1, 1),
	(2, 1),
	(3, 2),
	(3, 3),
	(4, 4),
	(5, 9),
	(5, 10),
	(6, 5),
	(6, 6),
	(6, 7),
	(8, 2),
	(8, 3);

COMMIT;

SELECT p.Name 'Product', c.Name 'Category'
FROM Products p
LEFT JOIN CategoriesProducts cp on p.Id = cp.ProductId
LEFT JOIN Categories c on c.Id = cp.CategoryId