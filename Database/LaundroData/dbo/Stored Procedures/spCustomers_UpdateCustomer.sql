CREATE PROCEDURE [dbo].[spCustomers_UpdateCustomer]
	@Id int,
	@FirstName nvarchar(20), 
	@LastName nvarchar(20), 
	@Address nvarchar(100), 
	@Phone nvarchar(15), 
	@Email nvarchar(70),
	@CreatedDate datetime2, 
	@Points int

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Customers 
	SET FirstName = @FirstName, LastName = @LastName, [Address] = @Address, 
		Phone = @Phone, Email = @Email, CreatedDate = @CreatedDate, Points = @Points
	WHERE Id = @Id;
END
