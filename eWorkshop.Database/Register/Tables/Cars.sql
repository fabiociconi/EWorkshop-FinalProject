CREATE TABLE [Register].[Cars] (
    [IdCar]        UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterCarsIdCar] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdPerson]     UNIQUEIDENTIFIER NOT NULL,
    [Brand]        VARCHAR (50)     NOT NULL,
    [Color]        VARCHAR (50)     NOT NULL,
    [Year]         INT              NOT NULL,
    [Trasmission]  INT              NOT NULL,
    [LicensePlate] VARCHAR (50)     NOT NULL,
    [FuelType]     INT              NOT NULL,
    [CreateDate]   DATETIME         CONSTRAINT [DEF_RegisterCarsCreateDate] DEFAULT (getdate()) NOT NULL,
    [Model]        VARCHAR (100)    NULL,
    CONSTRAINT [PK_RegisterCars] PRIMARY KEY CLUSTERED ([IdCar] ASC),
    CONSTRAINT [FK_RegisterPeopleIdPersonRegisterCarsIdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [Register].[People] ([IdPerson])
);



