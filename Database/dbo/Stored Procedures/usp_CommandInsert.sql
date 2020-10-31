create procedure [dbo].[usp_CommandInsert]
(
	@PayLoad nvarchar(max),
	@RequestDate datetime,
	@CompleteDate datetime
)
AS
BEGIN
	INSERT INTO Command
	VALUES (@PayLoad,@RequestDate,@CompleteDate)
END