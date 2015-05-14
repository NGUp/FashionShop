-- usp_searchProducts 1, 'ad512225', ''

CREATE Procedure [dbo].[usp_searchProducts](@page int, @id varchar(50), @name nvarchar(50))
As
Begin
	SELECT  *
	FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY ID ) AS RowNum, *
			  FROM      Product
			) AS RowConstrainedResult
	WHERE   RowNum >= ((@page - 1) * 10)
		AND RowNum < (@page * 10 + 1)
		And (ID = @id Or Name = @name)
		And State = 1
	ORDER BY RowNum
End