CREATE TABLE [dbo].[PhysicianAddress]
(
	[Id]          INT                           NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [AddressId]   INT                           NOT NULL, 
    [PhysicianId] INT                           NOT NULL, 
    [AddressType] INT                           NOT NULL, 
    [CreatedOn]   DATETIME2                     NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn]  DATETIME2                     NULL, 
    [DeletedOn]   DATETIME2                     NULL,
    CONSTRAINT    [FK_PhysicianAddress_Patient] FOREIGN KEY ([PhysicianId]) REFERENCES [Physician]([Id]), 
    CONSTRAINT    [FK_PhysicianAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
GO
CREATE INDEX [IX_PhysicianAddress_Patient] ON [dbo].[PhysicianAddress] ([PhysicianId])
GO
CREATE INDEX [IX_PhysicianAddress_Address] ON [dbo].[PhysicianAddress] ([AddressId])