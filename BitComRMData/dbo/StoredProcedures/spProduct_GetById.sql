CREATE PROCEDURE [dbo].[spProduct_GetById]
	@Id int 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
	Id, ProductName, Decription, RetailPrice, QuantitiyInStock, isTaxable
	FROM dbo.Product WHERE Id = @Id;
END
