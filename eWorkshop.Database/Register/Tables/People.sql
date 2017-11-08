CREATE TABLE [Register].[People] (
    [IdPerson]   UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterPeopleIdPerson] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [FirstName]  VARCHAR (200)    NOT NULL,
    [LastName]   VARCHAR (200)    NOT NULL,
    [Telephone]  VARCHAR (200)    NULL,
    [Email]      VARCHAR (200)    NOT NULL,
    [CreateDate] DATETIME         CONSTRAINT [DEF_RegisterPeopleCreateDate] DEFAULT (getdate()) NOT NULL,
    [ChangeDate] DATETIME         CONSTRAINT [DEF_RegisterPeopleChangeDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_RegisterPeople] PRIMARY KEY CLUSTERED ([IdPerson] ASC)
);

