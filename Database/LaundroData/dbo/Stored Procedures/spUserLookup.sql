﻿CREATE PROCEDURE [dbo].[spUserLookup]
	@Id NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[User]
	WHERE Id = @Id;
END