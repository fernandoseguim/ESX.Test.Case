-- docker run -d -p 1433:1433 -e sa_password=ESXT3stC4se -e ACCEPT_EULA=Y microsoft/mssql-server-windows-developer

CREATE DATABASE ESXTestCase;
GO

USE ESXTestCase;
GO

CREATE TABLE Users(
    UserID UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(20) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    PRIMARY KEY (UserID)
);
GO

CREATE TABLE Brands(
    BrandID UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(20) NOT NULL UNIQUE,
    Description VARCHAR(16),
    PRIMARY KEY (BrandID)
);
GO

CREATE TABLE Assets(
    AssetID UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(50) NOT NULL,
    Description VARCHAR(16) NULL,
    Registry VARCHAR(8) NULL,
    BrandID UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (AssetID),
    FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
);
GO


INSERT INTO Users (UserID, Name, Email, [Password]) VALUES (NEWID(), 'Fernando Seguim', 'fernando.seguim@gmail.com', 'TestCase@23');
INSERT INTO Brands (BrandID, Name) VALUES (NEWID(), 'Seguim IT');
INSERT INTO Assets (AssetID, Name, BrandID) VALUES (NEWID(), 'Notebook', (select BrandID from Brands WHERE Name = 'Seguim IT'));

SELECT * FROM Assets


