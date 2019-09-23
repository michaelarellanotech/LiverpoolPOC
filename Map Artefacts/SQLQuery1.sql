INSERT INTO MapPolygon (Longitude, Latitude, Geopoint) VALUES (	151.075484,	-33.909572,	geography::STPointFromText('POINT(151.075484 -33.909572)', 4326)
)

DECLARE @g geography; 

Select geography::STGeomFromText('POINT(151.075484 -33.909572)', 4326);  

select geography::STGeomFromText('LINESTRING(-33.909572, 151.075484)', 4326);  

select @g
SELECT @g.Lat;  
SELECT @g.Long;  

DECLARE @g geography;  
select geography::STGeomFromText('LINESTRING(151.075484 -33.909572)', 4326);  
SELECT @g.ToString();

DECLARE @g geography;  
SElect geography::STGeomFromText('LINESTRING(-122.360 47.656, -122.343 47.656)', 4326);  
SELECT @g.ToString();

Truncate Table MapPolygon



="INSERT INTO MapPolygon (Longitude, Latitude, Geopoint) VALUES ("&A2&","&B2&",	geography::STPointFromText('POINT("&A2&" "&B2&")', 4326)"

"INSERT INTO MapPolygon (Longitude, Latitude, Geopoint) VALUES (151.075484,-33.909572,	geography::STPointFromText('POINT(151.075484 -33.909572)', 4326)"
INSERT INTO MapPolygon (Longitude, Latitude, Geopoint) VALUES (151.075484, -33.909572, geography::STPointFromText('POINT(151.075484-33.909572)', 4326)

SET @g = geography::STPolyFromText