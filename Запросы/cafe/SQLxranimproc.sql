--�������� ���������
--���������� ���������� �������� ������������� ������� ���������
USE cafe
GO
CREATE PROCEDURE CountServe(@id int)
AS
BEGIN     
     SELECT COUNT(*) AS '�����������'
     FROM cafe INNER JOIN serve ON idcafe = serve.cafe_idcafe
     WHERE cafe.idcafe = @id;
END

--EXEC CountServe 103
--DROP PROCEDURE CountServe