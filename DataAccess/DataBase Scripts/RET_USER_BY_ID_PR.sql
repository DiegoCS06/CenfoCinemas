CREATE PROCEDURE [dbo.RET_USER_BY_ID_PR]
@P_Id INT
AS
BEGIN

	SELECT Id, Created, Updated, UserCode, Name, Email, Passowrd, BirthDate, Status
	FROM TBL_User
	WHERE Id = @P_Id;
END