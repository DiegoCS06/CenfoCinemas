CREATE PROCEDURE RET_ALL_MOVIES_PR
    @P_Title NVARCHAR(75),
    @P_Description NVARCHAR(250),
    @P_ReleaseDate DATETIME,
    @P_Genre NVARCHAR(20),
    @P_Director NVARCHAR(50)
AS
BEGIN
    INSERT INTO TBL_Movie (Created,Title,Description,ReleaseDate,Genre,Director)
    VALUES (GETDATE(),@P_Title,@P_Description,@P_ReleaseDate,@P_Genre,@P_Director
    )
END