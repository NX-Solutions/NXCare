CREATE TABLE [dbo].[Transition]
(
	[Id]                    INT                                  NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [VisitId]               INT                                  NOT NULL, 
    [LocationId]            INT                                  NOT NULL, 
    [ReferringPhysicianId]  INT                                  NULL, 
    [AdmittingPhysicianId]  INT                                  NULL, 
    [AttendingPhysicianId]  INT                                  NULL, 
    [ConsultingPhysicianId] INT                                  NULL, 
    [CreatedOn]             DATETIME2                            NOT NULL DEFAULT GETUTCDATE(), 
    [ModifiedOn]            DATETIME2                            NULL, 
    [DeletedOn]             DATETIME2                            NULL,
    CONSTRAINT              [FK_Transition_Visit]                FOREIGN KEY ([VisitId]) REFERENCES [Visit]([Id]), 
    CONSTRAINT              [FK_Transition_Referring_Physician]  FOREIGN KEY ([ReferringPhysicianId]) REFERENCES [Physician]([Id]),
    CONSTRAINT              [FK_Transition_Admitting_Physician]  FOREIGN KEY ([AdmittingPhysicianId]) REFERENCES [Physician]([Id]),
    CONSTRAINT              [FK_Transition_Attending_Physician]  FOREIGN KEY ([AttendingPhysicianId]) REFERENCES [Physician]([Id]),
    CONSTRAINT              [FK_Transition_Consulting_Physician] FOREIGN KEY ([ConsultingPhysicianId]) REFERENCES [Physician]([Id]),
)
GO
CREATE INDEX [IX_Transition_Visit] ON [dbo].[Transition] ([Id])
GO
CREATE INDEX [IX_Transition_Referring_Physician] ON [dbo].[Transition] ([ReferringPhysicianId])
GO
CREATE INDEX [IX_Transition_Admitting_Physician] ON [dbo].[Transition] ([AdmittingPhysicianId])
GO
CREATE INDEX [IX_Transition_Attending_Physician] ON [dbo].[Transition] ([AttendingPhysicianId])
GO
CREATE INDEX [IX_Transition_Consulting_Physician] ON [dbo].[Transition] ([ConsultingPhysicianId])