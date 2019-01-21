use cafe
go
select * from salarylist--обращение

--select supplier.title, ingredient.product from supplier 
--select * from supplier 

Create view salarylist as --создание представления
select  cafe.idcafe, AVG(post.salary) as 'средняя зп'
from cafe inner join serve on cafe.idcafe = serve.cafe_idcafe
inner join post on idserve = serve_idserve
group by cafe.idcafe

--drop view salarylist

select s.[средняя зп] from salarylist as s where s.idcafe = 101