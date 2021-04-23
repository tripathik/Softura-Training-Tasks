--[01]
select * from authors
select au_fname as FIRST_NAME, au_lname as LAST_NAME from authors


--[02]
select title from titles order by title desc


--[03]
select  distinct title_id,count(*) 
from titleauthor group by title_id


--[04]
select * from authors
select au_fname,au_lname, title from authors,titles


--[05]print the publisher name and the average advance for every publisher
select * from titles
select pub_name,avg(advance) AveRage from titles, publishers group by pub_name


--[06] print the publishername, author name, title name and the sale amount(qty*price)
select pub_name,au_fname as FIrstN, au_lname as Lastn, title, qty*price as SaleAmount from 
authors, publishers p join titles t on p.pub_id=t.pub_id join sales s on t.title_id=s.title_id


--[07] print the price of all that titles that have name taht ends with s
select price from titles where title like '%s'


--[08]print the title names that contain and in it
select title from titles where title like '%and%'


--[09]  print the employee name and the publisher name
select pub_name,fname from publishers join employee on
publishers.pub_id = employee.pub_id


--[10]print the publisher name and number of employees woking in it if the publisher has more than 2 employees
select pub_name,count(fname) As NumberOfEmployee from publishers P join employee E on P.pub_id=E.pub_id group by pub_name having count(fname)>2



--[11]Print the author names who have published using teh publisher name 'Algodata Infosystems'

 select au_fname from authors,publishers where pub_name='Algodata Infosystems'



--[12]Print the employees of the publisher 'Algodata Infosystems'

select fname from publishers join employee on
publishers.pub_id = employee.pub_id
where pub_name='Algodata Infosystems'

select * from publishers