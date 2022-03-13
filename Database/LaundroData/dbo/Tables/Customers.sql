CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] NVARCHAR(20) NOT NULL, 
    [LastName] NVARCHAR(20) NOT NULL, 
    [Address] NVARCHAR(100) NULL, 
    [Phone] NVARCHAR(15) NULL, 
    [Email] NVARCHAR(70) NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Points] INT NULL DEFAULT 0,
)
