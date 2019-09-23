CREATE TABLE [dbo].[LHDGeography] (
    [Id]          INT               NOT NULL,
    [Description] VARCHAR (250)     NOT NULL,
    [Geography]   [sys].[geography] NULL,
    CONSTRAINT [PK_LHDGeography] PRIMARY KEY CLUSTERED ([Id] ASC)
);

