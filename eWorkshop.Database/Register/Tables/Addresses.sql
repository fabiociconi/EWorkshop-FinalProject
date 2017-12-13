CREATE TABLE [Register].[Addresses] (
    [IdAddress]    UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterAddressesIdAddress] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdPerson]     UNIQUEIDENTIFIER NOT NULL,
    [Street]       VARCHAR (MAX)    NOT NULL,
    [StreetNumber] VARCHAR (300)    NOT NULL,
    [City]         VARCHAR (300)    NOT NULL,
    [PostalCode]   VARCHAR (300)    NOT NULL,
    [Type]         INT              NOT NULL,
    [Longitude]    NUMERIC (9, 6)   DEFAULT ((0)) NOT NULL,
    [Latitude]     NUMERIC (9, 6)   DEFAULT ((0)) NOT NULL,
    [Province]     VARCHAR (300)    NOT NULL,
    [Country]      VARCHAR (300)    NOT NULL,
    CONSTRAINT [PK_RegisterAddresses] PRIMARY KEY CLUSTERED ([IdAddress] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterAddressesIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson])
);









