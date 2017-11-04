CREATE TABLE [Register].[People] (
    [IdPerson]  UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterPeopleIdPerson] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [FirstName] VARCHAR (200)    NOT NULL,
    [LastName]  VARCHAR (200)    NOT NULL,
    [Telephone] VARCHAR (200)    NULL,
    [Email]     VARCHAR (200)    NOT NULL,
    CONSTRAINT [PK_RegisterPeople] PRIMARY KEY CLUSTERED ([IdPerson] ASC)
);

