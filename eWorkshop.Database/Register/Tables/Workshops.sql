CREATE TABLE [Register].[Workshops] (
    [IdWorkshop]  UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterWorkshopsIdWorkshop] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdPerson]    UNIQUEIDENTIFIER NOT NULL,
    [Description] VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_RegisterWorkshops] PRIMARY KEY CLUSTERED ([IdWorkshop] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterWorkshopsIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson]),
    CONSTRAINT [UNQ_RegisterWorkshopsIdPerson] UNIQUE NONCLUSTERED ([IdPerson] ASC)
);

