create procedure [dbo].[usp_CommandSelect]
(
	@Id int = null
)
AS
BEGIN
	IF (@Id is null)
	BEGIN
		select * from command
	END
	ELSE
	BEGIN
		select * from command
		WHERE Id = @Id 
	END

END