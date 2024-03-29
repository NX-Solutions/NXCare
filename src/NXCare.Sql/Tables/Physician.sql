﻿CREATE TABLE [dbo].[Physician]
(
	[Id]               INT                     NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PublicId]         UNIQUEIDENTIFIER        NOT NULL DEFAULT NEWID(),
    [NationalId]       NVARCHAR(50)            NULL,
    [LastName]         NVARCHAR(50)            NOT NULL,
    [MiddleName]       NVARCHAR(50)            NULL,
    [FirstName]        NVARCHAR(50)            NOT NULL,
    [BirthDate]        DATETIME2               NULL,
    [NationalityId]    INT                     NULL,
    [LanguageId]       INT                     NULL,
    [Sex]              INT                     NULL,
    [MedicalLicenseId] NVARCHAR(50)            NOT NULL,
    [SpecialityId]     INT                     NULL,
    [CreatedOn]        DATETIME2               NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedOn]       DATETIME2               NULL,
    [DeletedOn]        DATETIME2               NULL,
    [ExternalId] NVARCHAR(50) NULL,
    CONSTRAINT         [FK_Physician_Country]  FOREIGN KEY ([NationalityId]) REFERENCES [Country]([Id]),
    CONSTRAINT         [FK_Physician_Language] FOREIGN KEY ([LanguageId]) REFERENCES [Language]([Id]),
)

GO
CREATE UNIQUE INDEX [IX_Physician_PublicId] on [dbo].[Physician] ([PublicId])
GO
CREATE INDEX [IX_Physician_Country] ON [dbo].[Physician] ([NationalityId])
GO
CREATE INDEX [IX_Physician_Language] ON [dbo].[Physician] ([LanguageId])