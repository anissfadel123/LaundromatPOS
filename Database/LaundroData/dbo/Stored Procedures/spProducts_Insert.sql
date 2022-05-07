CREATE PROCEDURE [dbo].[spProducts_Insert]
	@ProductDescription nvarchar(20),
	@Price nvarchar(20),
	@Barcode nvarchar(100),
	@IsTaxable nvarchar(15),
	@TaxRate nvarchar(70),
	@ImageLocation nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Products(ProductDescription, Price, Barcode, IsTaxable, TaxRate, ImageLocation)
	VALUES (@ProductDescription, @Price, @Barcode, @IsTaxable, @TaxRate, @ImageLocation);

	SELECT CAST(SCOPE_IDENTITY() as int);
END
