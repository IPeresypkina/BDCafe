--====================================
--  Create database trigger template 
--====================================
--������� ��� ���������� ��� �� ������� ������� ������ ��� �� ���������
USE cafe
GO
CREATE TRIGGER serve_DELETE
ON serve
INSTEAD OF DELETE
AS
BEGIN 
	DECLARE @ServID int
	SELECT @ServID = idserve FROM deleted
	DELETE FROM post WHERE serve_idserve = @ServID
	DELETE FROM serve WHERE idserve = @ServID
END
--DROP TRIGGER post_DELETE
