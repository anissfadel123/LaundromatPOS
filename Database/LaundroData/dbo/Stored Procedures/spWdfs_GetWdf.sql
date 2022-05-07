CREATE PROCEDURE [dbo].[spWdfs_GetWdf]
	@Id int
AS
begin
	set nocount on;

	SELECT Wdf.Id, FirstName, LastName, CustomerId, ServiceId, Preferences, Total, ReadyBy,
		isPaid, [Status], isPickedUp, WashMachine, DryMachine
	FROM Wdf
	INNER JOIN Customers
	ON CustomerId = Customers.Id
	WHERE Wdf.Id=@Id;
end
