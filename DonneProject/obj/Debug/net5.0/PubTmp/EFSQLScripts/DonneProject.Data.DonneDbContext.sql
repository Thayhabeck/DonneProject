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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE TABLE [Atuacao] (
        [Id] int NOT NULL IDENTITY,
        [NomeArea] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Atuacao] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE TABLE [Contato] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Mensagem] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Contato] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE TABLE [Funcao] (
        [Id] int NOT NULL IDENTITY,
        [NomeFuncao] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Funcao] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE TABLE [Parceiro] (
        [Id] int NOT NULL IDENTITY,
        [RZsocial] nvarchar(max) NOT NULL,
        [Nome] nvarchar(max) NOT NULL,
        [cnpj] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [NomeAreaId] int NOT NULL,
        CONSTRAINT [PK_Parceiro] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Parceiro_Atuacao_NomeAreaId] FOREIGN KEY ([NomeAreaId]) REFERENCES [Atuacao] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE TABLE [Sobrevivente] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NOT NULL,
        [cpf] nvarchar(max) NOT NULL,
        [endereco] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [NomeFuncaoId] int NOT NULL,
        CONSTRAINT [PK_Sobrevivente] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sobrevivente_Funcao_NomeFuncaoId] FOREIGN KEY ([NomeFuncaoId]) REFERENCES [Funcao] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE INDEX [IX_Parceiro_NomeAreaId] ON [Parceiro] ([NomeAreaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    CREATE INDEX [IX_Sobrevivente_NomeFuncaoId] ON [Sobrevivente] ([NomeFuncaoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220110020050_Inicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220110020050_Inicial', N'5.0.12');
END;
GO

COMMIT;
GO

