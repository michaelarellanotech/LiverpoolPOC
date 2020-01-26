CREATE TABLE [dbo].[Question] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [QuestionGroupId]  INT            NULL,
    [Code]             VARCHAR (50)   NOT NULL,
    [Description]      VARCHAR (1000) NULL,
    [SortOrder]        VARCHAR (50)   NULL,
    [ResponseType]     VARCHAR (50)   NULL,
    [RowVersion]       ROWVERSION     NOT NULL,
    [CreatedById]      INT            NOT NULL,
    [CreatedDateTime]  DATETIME       CONSTRAINT [DF_QuestionHeader_CreatedDateTime] DEFAULT (getdate()) NOT NULL,
    [ModifiedById]     INT            NOT NULL,
    [ModifiedDateTime] DATETIME       CONSTRAINT [DF_QuestionHeader_ModifiedDateTime] DEFAULT (getdate()) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_Question_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_QuestionHeader] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Question_QuestionGroup] FOREIGN KEY ([QuestionGroupId]) REFERENCES [dbo].[QuestionGroup] ([Id])
);

