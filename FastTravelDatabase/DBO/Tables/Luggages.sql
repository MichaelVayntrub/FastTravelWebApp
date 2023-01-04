CREATE TABLE [dbo].[Luggages]
(
	[luggageID] INT NOT NULL PRIMARY KEY, 
    [luggageType] NVARCHAR(50) NOT NULL, 
    [maxWeight] DECIMAL(18, 2) NOT NULL, 
    [luggagePrice] DECIMAL(18, 2) NOT NULL
)