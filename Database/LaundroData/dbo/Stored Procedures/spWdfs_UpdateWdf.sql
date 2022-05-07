CREATE PROCEDURE [dbo].[spWdfs_UpdateWdf]
	@Id INT, 
    @CustomerId INT, 
    @ServiceId INT, 
    @Preferences NVARCHAR, 
    @Total MONEY, 
    @ReadyBy SMALLDATETIME,
    @IsPaid BIT, 
    @Status TINYINT, 
    @PickedUp BIT, 
    @WashMachine NVARCHAR, 
    @DryMachine NVARCHAR

AS
BEGIN
	SET NOCOUNT ON;
    UPDATE Wdf
    SET CustomerId = @CustomerId, ServiceId = @ServiceId, Preferences = @Preferences, 
    Total = @Total, ReadyBy = @ReadyBy, IsPaid = @IsPaid,
    [Status] = @Status, IsPickedUp = @PickedUp, WashMachine = @WashMachine, DryMachine = @DryMachine
    WHERE Id = @Id;
END
