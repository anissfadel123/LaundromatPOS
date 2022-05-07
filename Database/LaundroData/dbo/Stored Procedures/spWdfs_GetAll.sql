CREATE PROCEDURE [dbo].[spWdfs_GetAll]
	
AS
begin
	set nocount on;
	SELECT Wdf.Id, FirstName, LastName, CustomerId, ServiceId, Preferences, Total, ReadyBy,
	IsPaid, [Status], IsPickedUp, WashMachine, DryMachine
	FROM Wdf
	INNER JOIN Customers
	ON CustomerId = Customers.Id;
end
