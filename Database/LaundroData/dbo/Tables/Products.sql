CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ProductName] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Barcode] NVARCHAR(30) NULL, 
    [isTaxable] BIT NOT NULL DEFAULT 1
)
