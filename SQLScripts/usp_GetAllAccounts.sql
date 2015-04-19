-- execute usp_GetAllAccounts 1

Create Procedure usp_GetAllAccounts(@page int)
As
Begin
	SELECT  *
	FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY ID ) AS RowNum, *
			  FROM      Account
			) AS RowConstrainedResult
	WHERE   RowNum >= @page
		AND RowNum < (@page * 10 + 1)
	ORDER BY RowNum
End