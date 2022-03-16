CREATE PROCEDURE [dbo].[spCustomers_GetAll]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, FirstName, LastName, [Address],  Phone, Email, CreatedDate, Points FROM Customers;
END
