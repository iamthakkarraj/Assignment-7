CREATE DATABASE [CSharpAssignment]
GO

USE [CSharpAssignment]
GO

CREATE TABLE [Country] ([CountryId] INT PRIMARY KEY IDENTITY(1,1),
							[Name] NVARCHAR(56))
GO

CREATE TABLE [State] ([StateId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(56),
						[CountryId] INT FOREIGN KEY REFERENCES [Country]([CountryId]))
GO

CREATE TABLE [City] ([CityId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(56),
						[StateId] INT FOREIGN KEY REFERENCES [State]([StateId]))
GO

CREATE TABLE [User] ([UserId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(88) NOT NULL,
						[Email] NVARCHAR(88) UNIQUE NOT NULL,
						[ContactNumber] NVARCHAR(14) UNIQUE NOT NULL,
						[Address] NVARCHAR(256) NOT NULL,
						[CityId] INT FOREIGN KEY REFERENCES [City]([CityId]),
						[ZipCode] INT NOT NULL,
						[Password] NVARCHAR(18) NOT NULL)
GO

CREATE TABLE [ProductCategory] ([CategoryId] INT PRIMARY KEY IDENTITY(1,1),
									[Name] NVARCHAR(56) NOT NULL)
GO

CREATE TABLE [Product] ([ProductId] INT PRIMARY KEY IDENTITY(1,1),
							[Name] NVARCHAR(56) NOT NULL,
							[CategoryId] INT FOREIGN KEY REFERENCES [ProductCategory]([CategoryId]) NOT NULL,
							[Code] INT NOT NULL,
							[Price] DECIMAL(10,2) NOT NULL,
							[Description] NVARCHAR(MAX) NOT NULL,
							[Status] BIT DEFAULT 1,
							[Discount] INT DEFAULT 0,
							[ImagePath] NVARCHAR(MAX) NULL,
							[CreatedBy] INT FOREIGN KEY REFERENCES [User]([UserId]),
							[CreatedDate] DATETIME DEFAULT SYSDATETIME(),
							[ModifiedDate] DATETIME NULL)
GO

