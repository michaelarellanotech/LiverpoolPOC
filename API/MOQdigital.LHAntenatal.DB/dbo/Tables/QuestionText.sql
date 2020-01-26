CREATE TABLE [dbo].[QuestionText] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [QuestionId]       INT            NOT NULL,
    [LanguageId]       INT            NOT NULL,
    [Text]             NVARCHAR (MAX) NOT NULL,
    [RowVersion]       ROWVERSION     NOT NULL,
    [CreatedById]      INT            NOT NULL,
    [CreatedDateTime]  DATETIME       CONSTRAINT [DF_QuestionText_CreatedDateTime] DEFAULT (getdate()) NOT NULL,
    [ModifiedById]     INT            NOT NULL,
    [ModifiedDateTime] DATETIME       CONSTRAINT [DF_QuestionText_ModifiedDateTime] DEFAULT (getdate()) NOT NULL,
    [IsActive]         BIT            CONSTRAINT [DF_QuestionText_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_QuestionText] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QuestionText_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

