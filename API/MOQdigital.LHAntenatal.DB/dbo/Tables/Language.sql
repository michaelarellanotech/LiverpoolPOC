CREATE TABLE [dbo].[Language] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Code]             VARCHAR (50) NOT NULL,
    [Language]         VARCHAR (50) NOT NULL,
    [RTL]              BIT          NOT NULL,
    [RowVersion]       ROWVERSION   NOT NULL,
    [CreatedById]      INT          NOT NULL,
    [CreatedDateTime]  DATETIME     CONSTRAINT [DF_Language_CreatedDateTime] DEFAULT (getdate()) NOT NULL,
    [ModifiedById]     INT          NOT NULL,
    [ModifiedDateTime] DATETIME     CONSTRAINT [DF_Language_ModifiedDateTime] DEFAULT (getdate()) NOT NULL,
    [IsActive]         BIT          CONSTRAINT [DF_Language_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED ([Id] ASC)
);

