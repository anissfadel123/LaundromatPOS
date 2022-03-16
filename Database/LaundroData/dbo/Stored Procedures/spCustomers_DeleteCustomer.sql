CREATE PROCEDURE [dbo].[spCustomers_DeleteCustomer]
	@Id int

AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Customers WHERE Id = @Id;
END

