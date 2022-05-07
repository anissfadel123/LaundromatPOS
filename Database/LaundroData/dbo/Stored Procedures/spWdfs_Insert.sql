CREATE PROCEDURE [dbo].[spWdfs_Insert]
	@CustomerId int,
	@ServiceId int,
	@Preferences nvarchar(max),
	@Total money,
	@ReadyBy smalldatetime,
	@Status tinyint,
	@IsPaid bit
AS
begin
	set nocount on;
	INSERT INTO Wdf(CustomerId, ServiceId, Preferences, Total, ReadyBy, [Status], IsPaid) 
	VALUES (@CustomerId, @ServiceId, @Preferences, @Total, @ReadyBy, @Status, @IsPaid)

	SELECT CAST(SCOPE_IDENTITY() as int);
end
