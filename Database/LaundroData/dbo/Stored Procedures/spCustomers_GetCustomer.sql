CREATE PROCEDURE [dbo].[spCustomers_GetCustomer]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;	
	SELECT Id, FirstName, LastName, [Address], Phone, Email, CreatedDate, Points From Customers
	WHERE Id = @Id;
END
