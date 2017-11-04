CREATE TABLE [Register].[WorkShops] (
    [IdWorkShop]  UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterWorkShopsIdWorkShop] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IdPerson]    UNIQUEIDENTIFIER NOT NULL,
    [Description] VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_RegisterWorkShops] PRIMARY KEY CLUSTERED ([IdWorkShop] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterWorkShopsIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson]),
    CONSTRAINT [UNQ_RegisterWorkShopsIdPerson] UNIQUE NONCLUSTERED ([IdPerson] ASC)
);

