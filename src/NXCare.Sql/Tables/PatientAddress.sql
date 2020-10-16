CREATE TABLE [dbo].[PatientAddress]
(
	[Id]         INT                         NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PatientId]  INT                         NOT NULL, 
    [AddressId]  INT                         NOT NULL,
    [CreatedOn]  DATETIME2                   NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn] DATETIME2                   NULL, 
    [DeletedOn]  DATETIME2                   NULL,
    CONSTRAINT   [FK_PatientAddress_Patient] FOREIGN KEY ([PatientId]) REFERENCES [Patient]([Id]), 
    CONSTRAINT   [FK_PatientAddress_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
GO
CREATE INDEX [IX_PatientAddress_Patient] ON [dbo].[PatientAddress] ([PatientId])
GO
CREATE INDEX [IX_PatientAddress_Address] ON [dbo].[PatientAddress] ([AddressId])