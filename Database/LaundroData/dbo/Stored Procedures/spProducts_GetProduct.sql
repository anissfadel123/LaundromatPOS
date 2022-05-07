CREATE PROCEDURE [dbo].[spProducts_GetProduct]
	@Id int
AS
BEGIN
	SELECT Id, ProductDescription, Price, Barcode, IsTaxable, TaxRate, ImageLocation
	FROM Products
	WHERE Id = @Id
END
