CREATE TABLE [dbo].[MapPolygon] (
    [Id]             INT               IDENTITY (1, 1) NOT NULL,
    [LHDGeographyId] INT               NULL,
    [Longitude]      VARCHAR (50)      NOT NULL,
    [Latitude]       VARCHAR (50)      NOT NULL,
    [GeoPoint]       [sys].[geography] NOT NULL,
    CONSTRAINT [PK_MapPolygon] PRIMARY KEY CLUSTERED ([Id] ASC)
);

