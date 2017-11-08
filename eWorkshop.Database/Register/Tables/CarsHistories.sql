CREATE TABLE [Register].[CarsHistories] (
    [IdCarReportHistory] UNIQUEIDENTIFIER CONSTRAINT [DEF_RegisterCarsHistoriesIdCarReportHistory] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [IdCar]              UNIQUEIDENTIFIER NOT NULL,
    [Type]               INT              NOT NULL,
    [CreateDate]         DATETIME         CONSTRAINT [DEF_RegisterCarsHistoriesCreateDate] DEFAULT (getdate()) NOT NULL,
    [Decription]         VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_RegisterCarsHistories] PRIMARY KEY CLUSTERED ([IdCarReportHistory] ASC),
    CONSTRAINT [FK_RegisterCarsIdCarRegisterCarsHistoriesIdCar] FOREIGN KEY ([IdCar]) REFERENCES [Register].[Cars] ([IdCar])
);



