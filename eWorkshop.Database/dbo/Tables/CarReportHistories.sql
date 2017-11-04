CREATE TABLE [dbo].[CarReportHistories] (
    [IdCarReportHistory] UNIQUEIDENTIFIER NOT NULL,
    [Type]               INT              NOT NULL,
    [Decription]         VARBINARY (50)   NOT NULL,
    [DateTime]           ROWVERSION       NOT NULL,
    [IdCar]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CarReportHistories] PRIMARY KEY CLUSTERED ([IdCarReportHistory] ASC),
    CONSTRAINT [FK_CarReportHistories_Cars] FOREIGN KEY ([IdCar]) REFERENCES [dbo].[Cars] ([IdCar])
);

