CREATE PROCEDURE [dbo].[spProducts_UpdateProduct]
	@Id int,
	@ProductDescription nvarchar(50),
	@Price money,
	@Barcode nvarchar(30),
	@IsTaxable bit,
	@TaxRate decimal(5,2),
	@ImageLocation nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Products
	SET ProductDescription = @ProductDescription, Price = @Price, Barcode = @Barcode, IsTaxable = @IsTaxable, TaxRate = @TaxRate
	WHERE Id = @Id;
END