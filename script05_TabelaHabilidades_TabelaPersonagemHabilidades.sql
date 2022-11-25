BEGIN TRANSACTION;
GO

ALTER TABLE [Personagens] ADD [Derrotas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Disputas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Vitorias] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Habilidade] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidade] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidade_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidade] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidade]'))
    SET IDENTITY_INSERT [Habilidade] ON;
INSERT INTO [Habilidade] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidade]'))
    SET IDENTITY_INSERT [Habilidade] OFF;
GO

UPDATE [Usuarios] SET [Email] = N'seuEmail@gmail.com', [Latitude] = -23.520024100000001E0, [Longitude] = -46.596497999999997E0, [PasswordHash] = 0x1D9065901ECA025BA91AE65E3D9A308F28DE910F36BF66DA5B567D4EF25AEA48C288A4381F53BB9C89CBA06FB43D0A76327BE635D5DBEEEB39CC54EEEE1EB896, [PasswordSalt] = 0x3BC4DD9D0637C2FB10A8A591D8C13623E43ABDC2FD40116BEB532BA5B004972DFFE97CAC3528FD3E0029AF46134F55479B29E886C01CDA6CB3BB568FC4FE41F7F4AD0E97661584DBD6424DABBA926ABD620FD37170D44ADB3832774917FB8BFDC7400058B7CD04611CC66B8A90F868EF4BA112401C18EEF7438F13965C5924C9
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(2, 1),
(2, 2),
(2, 3),
(3, 3),
(3, 4),
(1, 5),
(2, 6),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221017232406_MigracaoMuitosParaMuitos', N'6.0.10');
GO

COMMIT;
GO

