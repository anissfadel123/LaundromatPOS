CREATE PROCEDURE [dbo].[spProducts_GetProduct]
	@Id int
AS
BEGIN
	SELECT Id, ProductName, Price, Barcode, IsTaxable, TaxRate
	FROM Products
	WHERE Id = @Id
END
