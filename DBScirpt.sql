IF (db_id(N'DDD_Dropshipping') IS NOT NULL)
	DROP DATABASE [DDD_Dropshipping]
GO

CREATE DATABASE [DDD_Dropshipping]
GO

USE [DDD_Dropshipping];
GO

--SELECT [SCHEMA_NAME] FROM [INFORMATION_SCHEMA].[SCHEMATA]
IF (SCHEMA_ID(N'Ordering') IS NOT NULL)
	DROP SCHEMA [Ordering]
GO

CREATE SCHEMA [Ordering]
GO

IF (OBJECT_ID(N'Ordering.Address', N'U') IS NOT NULL)
	DROP TABLE [Ordering].[Address]
GO

-- TODO: refactore
CREATE TABLE [Ordering].[Address] (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[Country] NVARCHAR(40) NOT NULL,
	[City] NVARCHAR(60) NOT NULL,
	[PostalCode] NVARCHAR(15) NOT NULL,
	[Street] NVARCHAR(50) NULL,
	[StreetNumber] NVARCHAR(10) NULL,
	[ApartmentNumber] NVARCHAR(5) NULL
)

IF (OBJECT_ID(N'Ordering.Order', N'U') IS NOT NULL)
	DROP TABLE [Ordering].[Order]
GO

CREATE TABLE [Ordering].[Order] (
	[Id] UNIQUEIDENTIFIER PRIMARY KEY,
	[Date] DATETIME NOT NULL,
	[BillingAddressId] UNIQUEIDENTIFIER NOT NULL,
	[ShippingAddressId] UNIQUEIDENTIFIER NOT NULL,
	[State] TINYINT NOT NULL,
	[PeymentMethod] TINYINT NOT NULL,
	[ValueInUSD] DECIMAL(19,4) NOT NULL
)
 