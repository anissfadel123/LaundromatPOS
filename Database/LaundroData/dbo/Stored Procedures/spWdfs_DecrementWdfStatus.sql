CREATE PROCEDURE [dbo].[spWdfs_DecrementWdfStatus]
	@Id int
AS
BEGIN
	Update Wdf
	SET Status = Status-1
	WHERE Id = @Id;
END