--Если удаляем кафе то удаляем все что с ним связанно 
USE cafe
GO
CREATE TRIGGER cafe_DELETE
ON cafe
INSTEAD OF DELETE
AS
BEGIN 
	DECLARE @cafeID int
	SELECT @cafeID = idcafe FROM deleted
	DELETE FROM supplier WHERE supplier.cafe_idcafe = @cafeID
	DELETE FROM serve WHERE serve.cafe_idcafe = @cafeID
	DELETE FROM cafe WHERE idcafe = @cafeID
END
--DROP TRIGGER post_DELETE