IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Trainers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Specialization] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Trainers] PRIMARY KEY ([Id])
);

CREATE TABLE [TrainingPrograms] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [TrainerId] int NOT NULL,
    CONSTRAINT [PK_TrainingPrograms] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TrainingPrograms_Trainers_TrainerId] FOREIGN KEY ([TrainerId]) REFERENCES [Trainers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Participants] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Department] nvarchar(max) NOT NULL,
    [TrainingProgramId] int NOT NULL,
    CONSTRAINT [PK_Participants] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Participants_TrainingPrograms_TrainingProgramId] FOREIGN KEY ([TrainingProgramId]) REFERENCES [TrainingPrograms] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Participants_TrainingProgramId] ON [Participants] ([TrainingProgramId]);

CREATE INDEX [IX_TrainingPrograms_TrainerId] ON [TrainingPrograms] ([TrainerId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251008074635_InitialCreate', N'9.0.9');

COMMIT;
GO

