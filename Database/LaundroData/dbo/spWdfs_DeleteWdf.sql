﻿CREATE PROCEDURE [dbo].[spWdfs_DeleteWdf]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Wdf WHERE Id = @Id;
END
