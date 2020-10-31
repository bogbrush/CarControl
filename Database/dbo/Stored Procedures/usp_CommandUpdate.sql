create procedure [dbo].[usp_CommandUpdate]
(
	@Id int,
	@PayLoad nvarchar(max),
	@RequestDate datetime,
	@CompleteDate datetime
)
AS
BEGIN
	Update Command
	SET PayLoad = @PayLoad, RequestDate = @RequestDate,CompleteDate =@CompleteDate
	WHERE Id = @Id
END