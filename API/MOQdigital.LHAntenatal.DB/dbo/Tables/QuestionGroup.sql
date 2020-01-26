CREATE TABLE [dbo].[QuestionGroup] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Code]             VARCHAR (50)   NOT NULL,
    [Description]      VARCHAR (1000) NOT NULL,
    [SortOrder]        VARCHAR (50)   NOT NULL,
    [RowVersion]       ROWVERSION     NOT NULL,
    [CreatedById]      INT            NOT NULL,
    [CreatedDateTime]  DATETIME       CONSTRAINT [DF_QuestionGroup_CreatedDateTime] DEFAULT (getdate()) NOT NULL,
    [ModifiedById]     INT            NOT NULL,
    [ModifiedDateTime] DATETIME       CONSTRAINT [DF_QuestionGroup_ModifiedDateTime] DEFAULT (getdate()) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_QuestionGroup_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_QuestionGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);

