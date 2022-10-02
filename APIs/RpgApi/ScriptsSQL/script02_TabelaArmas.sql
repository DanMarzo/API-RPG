BEGIN TRANSACTION;
GO

ALTER TABLE [personagens] DROP CONSTRAINT [PK_personagens];
GO

EXEC sp_rename N'[personagens]', N'Personagens';
GO

ALTER TABLE [Personagens] ADD CONSTRAINT [PK_Personagens] PRIMARY KEY ([Id]);
GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome])
VALUES (1, 48, N'Cajado Assis'),
(2, 58, N'Espada Z'),
(3, 55, N'Machado Leviatã'),
(4, 30, N'Glimorio Tinhoso'),
(5, 20, N'Espada Comum'),
(6, 10, N'Varinha Azkan'),
(7, 25, N'Livro de invocação');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220926231114_MigracaoArma', N'6.0.9');
GO

COMMIT;
GO

