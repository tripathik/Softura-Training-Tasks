
--1) Print the city name and the count of authors from every city
select * from authors

select city,count(*) as Count from authors group by city


--2) Print the authors who are not from the city in which the publisher 'New Moon Books' is from.

select distinct city,au_fname,au_lname from authors where city 
not in(select city from publishers where pub_name = 'New Moon Books')


--3) Create a procudure that will take the author first name and last name and new price. The procedure should update teh price of the books written 
--by the author with the give name 
create proc proc_PriceUpdate(@au_fname varchar(20),@au_lname varchar(40),@price float)
as 
begin
update titles set price = @price
select au_fname,au_lname,price,title from authors,titles where au_fname = @au_fname
end

exec proc_PriceUpdate Ann,Dull,200




--4) Create a function that will calculate tax for the sale of every book
--If quantity <10 tax is 2%
--10 -20 tax is 5%
--20 - 50 tax is 6%
--above 30 tax is 7.5%
--The fuction should take quantity and return tax

select * from sales 
select title,qty from titles t join sales s on t.title_id=s.title_id

--Function----

alter function fun_BookTax(@quantity varchar(10))
returns @TaxTable table(title_id varchar(10),tax varchar(10))
as
begin
declare 
@count int,
@tax varchar(10),
@t_id varchar(15)
set @count=(select distinct qty from sales where ord_num=@quantity)
	if(@count<10)
		set @tax='2%'
	else if(@count>10 and @count<20)	
		set @tax='5%'
	else if(@count>20 and @count<50)	
		set @tax='6%'
	else if(@count >=50)	
		set @tax='7.5%'
	set @t_id=(select title_id from sales where ord_num=@quantity)
	insert into @TaxTable values(@t_id,@tax) 
	return
end
select title_id,tax from dbo.fun_BookTax('QQ2299')

