CREATE TABLE [Register].[PeopleAddresses] (
    [IdAddress] UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterPeopleAddressesIdAddress] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [IdPerson]  UNIQUEIDENTIFIER NOT NULL,
    [Street]    VARCHAR (300)    NOT NULL,
    [City]      VARCHAR (250)    NOT NULL,
    [ZipCode]   VARCHAR (10)     NOT NULL,
    [Type]      INT              CONSTRAINT [DEF_RegisterPeopleAddressesType] DEFAULT ((0)) NOT NULL,
    [Longitude] NUMERIC (10, 6)  CONSTRAINT [DEF_RegisterPeopleAddressesLongitude] DEFAULT ((0)) NOT NULL,
    [Latitude]  NUMERIC (10, 6)  CONSTRAINT [DEF_RegisterPeopleAddressesLatitude] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RegisterPeopleAddresses] PRIMARY KEY CLUSTERED ([IdAddress] ASC),
    CONSTRAINT [CHECK_RegisterPeopleAddressesLatitude] CHECK ([Latitude]>=(0)),
    CONSTRAINT [CHECK_RegisterPeopleAddressesLongitude] CHECK ([Longitude]>=(0)),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterPeopleAddressesIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson])
);

