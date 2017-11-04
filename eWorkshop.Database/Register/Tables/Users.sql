CREATE TABLE [Register].[Users] (
    [IdUser]   UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterUsersIdUser] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IdPerson] UNIQUEIDENTIFIER NOT NULL,
    [Password] VARCHAR (100)    NOT NULL,
    [Role]     INT              CONSTRAINT [DEF_RegisterUsersRole] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RegisterUsers] PRIMARY KEY CLUSTERED ([IdUser] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterUsersIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson]),
    CONSTRAINT [UNQ_RegisterUsersIdPerson] UNIQUE NONCLUSTERED ([IdPerson] ASC)
);

