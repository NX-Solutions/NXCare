CREATE TABLE [dbo].[Patient]
(
    [Id]            INT                   NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PublicId]      UNIQUEIDENTIFIER      NOT NULL DEFAULT NEWID(),
    [NationalId]    NVARCHAR(50)          NULL,
    [LastName]      NVARCHAR(50)          NOT NULL,
    [MiddleName]    NVARCHAR(50)          NULL,
    [FirstName]     NVARCHAR(50)          NOT NULL,
    [BirthDate]     DATETIME2             NULL,
    [NationalityId] INT                   NULL,
    [LanguageId]    INT                   NULL,
    [Sex]           INT                   NULL,
    [ExternalId]    NVARCHAR(50)          NULL,
    [CreatedOn]     DATETIME2             NOT NULL DEFAULT GETUTCDATE(),
    [ModifiedOn]    DATETIME2             NULL,
    [DeletedOn]     DATETIME2             NULL,
    CONSTRAINT      [FK_Patient_Country]  FOREIGN KEY ([NationalityId]) REFERENCES [Country]([Id]),
    CONSTRAINT      [FK_Patient_Language] FOREIGN KEY ([LanguageId]) REFERENCES [Language]([Id]),
)
GO
CREATE INDEX [IX_Patient_Country] ON [dbo].[Patient] ([NationalityId])
GO
CREATE INDEX [IX_Patient_Language] ON [dbo].[Patient] ([LanguageId])
GO
CREATE UNIQUE INDEX [IX_Patient_ExternalId] ON [dbo].[Patient] ([ExternalId])
GO
CREATE INDEX [IX_Patient_PublicId] ON [dbo].[Patient] ([PublicId])
