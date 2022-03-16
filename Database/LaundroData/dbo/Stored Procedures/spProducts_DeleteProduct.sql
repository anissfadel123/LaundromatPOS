CREATE PROCEDURE [dbo].[spProducts_DeleteProduct]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Products WHERE Id = @Id;
END

