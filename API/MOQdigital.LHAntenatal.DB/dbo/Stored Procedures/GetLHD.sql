
CREATE PROCEDURE [dbo].[GetLHD] 
	@longitude VARCHAR(20), 
	@latitude VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @g geography, @point geography;

	SELECT @g = geography from LHDGeography where id = 2;
	
	SET @point = geography::STGeomFromText('POINT (' + @longitude + ' ' + @latitude + ')', 4326)

	SELECT CASE
		WHEN @point.STIntersection(@g).ToString() = 'GEOMETRYCOLLECTION EMPTY' 
			THEN 0 
		ELSE 1 
	END
END