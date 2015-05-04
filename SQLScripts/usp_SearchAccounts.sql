-- usp_searchAccounts 1, 'asda', 'admin'

Create Procedure usp_searchAccounts(@page int, @id varchar(50), @user varchar(50))
As
Begin
	SELECT  *
	FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY ID ) AS RowNum, *
			  FROM      Account
			) AS RowConstrainedResult
	WHERE   RowNum >= ((@page - 1) * 10)
		AND RowNum < (@page * 10 + 1)
		And (ID = @id Or Username = @user)
	ORDER BY RowNum
End