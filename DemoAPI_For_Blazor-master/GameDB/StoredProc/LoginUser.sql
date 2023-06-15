CREATE PROCEDURE [dbo].[LoginUser]
	@email VARCHAR(150),
	@pwd VARCHAR(100)
AS
BEGIN
	DECLARE @salt VARCHAR(100)
	SELECT @salt = Salt FROM Users WHERE Email = @email

	DECLARE @hashKey VARCHAR(100)
	SET @hashKey = dbo.GetSecret()

	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @hashKey, @pwd, @salt))

	SELECT * FROM Users WHERE Email = @email AND Pwd = @pwdHash
END
