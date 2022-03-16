CREATE PROCEDURE [dbo].[spProducts_Insert]
	@ProductName nvarchar(20),
	@Price nvarchar(20),
	@Barcode nvarchar(100),
	@IsTaxable nvarchar(15),
	@TaxRate nvarchar(70)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Products(ProductName, Price, Barcode, IsTaxable, TaxRate)
	VALUES (@ProductName, @Price, @Barcode, @IsTaxable, @TaxRate);

	SELECT CAST(SCOPE_IDENTITY() as int);
END
