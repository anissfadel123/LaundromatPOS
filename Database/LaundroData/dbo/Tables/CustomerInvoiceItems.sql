CREATE TABLE [dbo].[CustomerInvoiceItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [InvoiceID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Discount] MONEY NULL, 
    [Price] MONEY NULL, 
    CONSTRAINT [FK_CustomerInvoiceItems_ToProduct] FOREIGN KEY ([ProductID]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_CustomerInvoiceItems_ToInvoice] FOREIGN KEY ([InvoiceID]) REFERENCES [CustomerInvoices]([Id]),
)
