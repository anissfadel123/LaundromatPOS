CREATE TABLE [dbo].[WdfServiceType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ServiceDescription] NVARCHAR(100) NOT NULL, 
    [PricePerPound] MONEY NOT NULL, 
    [MinimumPrice] MONEY NOT NULL, 
)
