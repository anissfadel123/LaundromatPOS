CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ProductName] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Barcode] NCHAR(10) NULL, 
    [isTaxable] BIT NOT NULL DEFAULT 1
)
