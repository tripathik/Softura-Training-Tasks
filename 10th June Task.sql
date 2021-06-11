
------------------------------------------------------------------------------------------TASK-1
select * from Production.Product

select ProductId, Name,Color,DaysToManufacture 
from Production.Product 
where DaysToManufacture =
(select DaysToManufacture  from Production.Product where name='Blade')

------------------------------------------------------------------------------------------TASK-2
select ProductId,ProductModelID,name,Color,Weight
from Production.Product
where Weight >ANY
(select Max(Weight) 
from Production.Product
Group by ProductModelID)

select ProductId,ProductModelID,name,Color,Weight
from Production.Product
where Weight >=ANY
(select Max(Weight) 
from Production.Product
Group by ProductModelID)

select ProductId,ProductModelID,name,Color,Weight
from Production.Product
where Weight <=ANY
(select Max(Weight) 
from Production.Product
Group by ProductModelID)

select ProductId,ProductModelID,name,Color,Weight
from Production.Product
where Weight <=ALL
(select Max(Weight) 
from Production.Product
Group by ProductModelID)

select ProductId,ProductModelID,name,Color,Weight
from Production.Product
where Weight >650
(select Max(Weight) 
from Production.Product
Group by ProductModelID)

-------------------------------------------------------------------------------------------------------TASK-3
--3.Sub Query
--Use the following tables:
--Sales.SalesPerson, Sales.SalesTerritory, Person.Person
--FInd the FirstName, Lastname, Territory name, Region of the person doing maximum sales per territory

select p.FirstName,P.LastName,st.Name,st.CountryRegionCode as Region,st.SalesLastYear as MaximumSales 
from Person.Person p join Sales.SalesPerson sp on p.BusinessEntityID=sp.BusinessEntityID
join Sales.SalesTerritory st on st.TerritoryID=sp.TerritoryID 
where st.SalesLastYear 
in(select max(SalesLastYear) from Sales.SalesTerritory)


--4. Correlated SUbquery
--Use the following tables:
--HumanResources.Employee, PersonPerson, Sales.SalesPerson
--inner table - sales.salesPerson.(select the appropriate outer table to do the join)
--Get the field SalesQuota
--Fetch FirstName, Lastname of the salesPerson who has achieved the SalesQuota of 25000
select p.FirstName,p.LastName
from Person.Person p
join HumanResources.Employee e
on e.BusinessEntityID=p.BusinessEntityID
where 250000 in
(select SalesQuota from Sales.SalesPerson sp
where sp.BusinessEntityID=e.BusinessEntityID)