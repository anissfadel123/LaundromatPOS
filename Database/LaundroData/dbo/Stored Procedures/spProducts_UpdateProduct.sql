CREATE PROCEDURE [dbo].[spProducts_UpdateProduct]
	@Id int,
	@ProductName nvarchar(50),
	@Price money,
	@Barcode nvarchar(30),
	@IsTaxable bit,
	@TaxRate decimal(5,2)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Products
	SET ProductName = @ProductName, Price = @Price, Barcode = @Barcode, IsTaxable = @IsTaxable, TaxRate = @TaxRate
	WHERE Id = @Id;
END