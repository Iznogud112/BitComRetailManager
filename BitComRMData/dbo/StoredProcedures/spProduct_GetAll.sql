CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
	Id, ProductName, Decription, RetailPrice, QuantitiyInStock
	FROM dbo.Product ORDER BY ProductName;
END
