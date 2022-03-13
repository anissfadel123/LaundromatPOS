CREATE TABLE [dbo].[Wdf]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CustomerId] INT NOT NULL, 
    [ServiceDescriptionId] INT NOT NULL, 
    [Preferences] NVARCHAR(MAX) NULL, 
    [total] MONEY NOT NULL, 
    [readyBy] DATETIME2 NOT NULL, 
    [paid] BIT NOT NULL, 
    [isReady] BIT NOT NULL, 
    [pickedUp] BIT NOT NULL
)
