CREATE VIEW dbo.VW_GroupQuestion AS
SELECT 
	QuestionGroupId = QG.Id,
	GroupDescription = QG.[Description],
	QuestionCode = Q.Code,
	LanguageId = QT.LanguageId,
	QuestionText = QT.[Text],
	RTL = L.RTL  
FROM 
	dbo.QuestionGroup QG WITH(NOLOCK)
	INNER JOIN dbo.Question Q WITH(NOLOCK)
		ON QG.Id = Q.QuestionGroupId
	INNER JOIN dbo.QuestionText QT WITH(NOLOCK)  
		ON Q.Id = QT.QuestionId
	INNER JOIN dbo.[Language] L WITH(NOLOCK)  
		ON QT.LanguageId = L.Id