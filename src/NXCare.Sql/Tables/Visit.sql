CREATE TABLE [dbo].[Visit]
(
	[Id]                   INT                  NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PublicId]             UNIQUEIDENTIFIER     NOT NULL DEFAULT NEWID(), 
    [ExternalId]           NVARCHAR(50)         NOT NULL, 
    [AdmissionType]        INT                  NOT NULL, 
    [AdmissionDate]        DATETIME2            NOT NULL, 
    [DischargeDate]        DATETIME2            NULL,
    [AdmittingPhysicianId] INT                  NOT NULL, 
    [CreatedOn]            DATETIME2            NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn]           DATETIME2            NULL, 
    [DeletedOn]            DATETIME2            NULL,
    CONSTRAINT             [FK_Visit_Physician] FOREIGN KEY ([AdmittingPhysicianId]) REFERENCES [Physician]([Id])
)
GO
CREATE INDEX [IX_Visit_AdmittingPhysicianId] ON [dbo].[Visit] ([AdmittingPhysicianId])