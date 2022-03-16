CREATE PROCEDURE [dbo].[spCustomers_Insert]
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@Address nvarchar(100),
	@Phone nvarchar(15),
	@Email nvarchar(70)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Customers(FirstName, LastName, [Address], Phone, Email)
	VALUES (@FirstName, @LastName, @Address, @Phone, @Email);

	SELECT CAST(SCOPE_IDENTITY() as int);
END
