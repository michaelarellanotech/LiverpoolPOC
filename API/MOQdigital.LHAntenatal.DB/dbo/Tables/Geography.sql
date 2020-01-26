CREATE TABLE [dbo].[Geography] (
    [Id]               INT               NOT NULL,
    [ParentId]         INT               NULL,
    [GeographyType]    VARCHAR (50)      NULL,
    [Code]             VARCHAR (50)      NULL,
    [Description]      VARCHAR (250)     NOT NULL,
    [Geography]        [sys].[geography] NULL,
    [RowVersion]       ROWVERSION        NOT NULL,
    [CreatedById]      INT               NOT NULL,
    [CreatedDateTime]  DATETIME          CONSTRAINT [DF_LHDGeography_CreatedDateTime] DEFAULT (getdate()) NOT NULL,
    [ModifiedById]     INT               NOT NULL,
    [ModifiedDateTime] DATETIME          CONSTRAINT [DF_LHDGeography_ModifiedDateTime] DEFAULT (getdate()) NOT NULL,
    [IsActive]         BIT               CONSTRAINT [DF_LHDGeography_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_LHDGeography] PRIMARY KEY CLUSTERED ([Id] ASC)
);

