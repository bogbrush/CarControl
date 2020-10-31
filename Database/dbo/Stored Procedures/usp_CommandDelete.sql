create procedure [dbo].[usp_CommandDelete]
(
	@Id int = null
)
AS
BEGIN
	IF (@Id is null)
	BEGIN
		delete from command
	END
	ELSE
	BEGIN
		delete from command
		WHERE Id = @Id 
	END

END