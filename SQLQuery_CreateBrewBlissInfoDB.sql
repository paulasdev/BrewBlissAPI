CREATE DATABASE BrewBlissInfoDB;
GO

USE BrewBlissInfoDB;
GO

CREATE TABLE CategoryInfo (
    Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    CategoryInfoName NVARCHAR(100) NOT NULL
);


CREATE TABLE MenuItemDetails (
    Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    NameItem NVARCHAR(100) NOT NULL,
    Ingredients NVARCHAR(255),
    Calories INT,
    Vegan BIT
);


INSERT INTO CategoryInfo VALUES ('Hot drinks'), ('Cold drinks'), ('Pastries and bakery items');
INSERT INTO MenuItemDetails 
VALUES 
('Green Tea', 'Green tea leaves, water', 0, 1),
('Blueberry Muffin', 'Flour, blueberries, sugar', 350, 0),
('Coffee Bliss', 'Espresso, milk, sugar', 120, 0);
('Iced Coffee', 'Coffee, ice, sugar syrup', 100, 0),
('Latte Charm', 'Espresso, steamed milk', 150, 0),
('Cappuccino', 'Espresso, milk foam', 130, 0);
('Macchiato Marvel', 'Espresso, milk, caramel', 160, 0);


