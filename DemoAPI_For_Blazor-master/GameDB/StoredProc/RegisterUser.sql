CREATE PROCEDURE [dbo].[RegisterUser]
	@email VARCHAR(150),
	@pwd VARCHAR(100)

AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @hashKey VARCHAR(100)
	SET @hashKey = dbo.GetSecret()

	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @hashKey, @pwd, @salt))

	INSERT INTO Users (Email, Pwd, Salt) VALUES (@email, @pwdHash, @salt)
END
