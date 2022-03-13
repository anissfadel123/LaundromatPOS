CREATE TABLE [dbo].[CustomerInvoiceItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [InvoiceID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Discount] MONEY NULL, 
    [Price] MONEY NULL,
)
