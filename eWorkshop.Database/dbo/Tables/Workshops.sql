CREATE TABLE [dbo].[Workshops] (
    [IdWorkshop] UNIQUEIDENTIFIER NOT NULL,
    [Name]       NCHAR (10)       NOT NULL,
    [Comments]   NCHAR (10)       NOT NULL,
    [DateTime]   ROWVERSION       NOT NULL,
    CONSTRAINT [PK_Workshops] PRIMARY KEY CLUSTERED ([IdWorkshop] ASC)
);

