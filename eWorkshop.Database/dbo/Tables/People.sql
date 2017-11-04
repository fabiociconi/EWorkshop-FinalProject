CREATE TABLE [dbo].[People] (
    [IdPerson]   UNIQUEIDENTIFIER NOT NULL,
    [IdUser]     UNIQUEIDENTIFIER NOT NULL,
    [FirstName]  VARCHAR (50)     NOT NULL,
    [MiddleName] VARCHAR (50)     NOT NULL,
    [LastName]   VARCHAR (50)     NOT NULL,
    [Email]      VARCHAR (50)     NOT NULL,
    [Birthday]   DATE             NOT NULL,
    [DateTime]   ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([IdPerson] ASC),
    CONSTRAINT [FK_People_Users] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([IdUser])
);

