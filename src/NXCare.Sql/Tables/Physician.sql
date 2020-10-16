CREATE TABLE [dbo].[Physician]
(
	[Id]               INT                     NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PublicId]         UNIQUEIDENTIFIER        NOT NULL DEFAULT NEWID(), 
    [NationalId]       NVARCHAR(50)            NOT NULL, 
    [LastName]         NVARCHAR(50)            NOT NULL, 
    [MiddleName]       NVARCHAR(50)            NOT NULL, 
    [FirstName]        NVARCHAR(50)            NOT NULL, 
    [BirthDate]        DATETIME2               NOT NULL, 
    [NationalityId]    INT                     NOT NULL, 
    [LanguageId]       INT                     NOT NULL, 
    [Sex]              INT                     NOT NULL, 
    [MedicalLicenseId] NVARCHAR(50)            NOT NULL, 
    [SpecialityId]     INT                     NOT NULL,
    [CreatedOn]        DATETIME2               NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn]       DATETIME2               NULL, 
    [DeletedOn]        DATETIME2               NULL,
    CONSTRAINT         [FK_Physician_Country]  FOREIGN KEY ([NationalityId]) REFERENCES [Country]([Id]), 
    CONSTRAINT         [FK_Physician_Language] FOREIGN KEY ([LanguageId]) REFERENCES [Language]([Id]), 
)

GO
CREATE INDEX [IX_Physician_Country] ON [dbo].[Patient] ([NationalityId])
GO
CREATE INDEX [IX_Physician_Language] ON [dbo].[Patient] ([LanguageId])