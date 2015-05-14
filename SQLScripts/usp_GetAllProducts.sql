Create Procedure [dbo].[usp_GetAllProducts](@page int)
As
Begin
	SELECT  *
	FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY Time ) AS RowNum, *
			  FROM      Product
			) AS RowConstrainedResult
	WHERE   RowNum >= ((@page - 1) * 20)
		AND RowNum < (@page * 20 + 1)
		And State = 1
	ORDER BY RowNum
End