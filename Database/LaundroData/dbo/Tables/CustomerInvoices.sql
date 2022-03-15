CREATE TABLE [dbo].[CustomerInvoices]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CustomerID] INT NULL, 
    [SubTotal] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL, 
    [GrandTotal] MONEY NOT NULL, 
    [InvoiceStatus] TINYINT NOT NULL, 
    [DateTime] SMALLDATETIME NULL, 
    CONSTRAINT [FK_CustomerInvoices_ToCustomers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
