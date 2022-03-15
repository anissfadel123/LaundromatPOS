CREATE TABLE [dbo].[Wdf]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [CustomerId] INT NOT NULL, 
    [ServiceId] INT NOT NULL, 
    [Preferences] NVARCHAR(MAX) NULL, 
    [Total] MONEY NOT NULL, 
    [ReadyBy] DATETIME2 NOT NULL, 
    [Paid] BIT NOT NULL, 
    [Status] TINYINT NOT NULL, 
    [PickedUp] BIT NOT NULL, 
    [WashMachine] NVARCHAR(MAX) NULL, 
    [DryMachine] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Wdf_ToCustomers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]), 
    CONSTRAINT [FK_Wdf_ToWdfServiceType] FOREIGN KEY ([ServiceId]) REFERENCES [WdfServiceType]([Id])
)
