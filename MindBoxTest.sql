--создание бд
create database MindBoxSqlTestDb
go

use MindBoxSqlTestDb

--создание таблиц
create table Products
(
	ProductId int primary key,
	[Name] nvarchar(30) not null,
)

create table Categories
(
	CategoryId int primary key,
	[Name] nvarchar(30) not null,
)

-- таблица для отношения многие ко многим
create table ProductsCategories
(
	ProductsCategoriesId int not null primary key,
	CategoryId int not null foreign key references Categories(CategoryId),
	ProductId int not null foreign key references Products(ProductId)
)

--вставка данных в таблици
insert into Products values (0, N'вафли'), (1, N'торт'), (2, N'хлеб'), (3, N'пирожки'), (4, N'машина'), (5, N'топор');
insert into Categories values (0, N'сладкое'), (1, N'выпечка'), (2, N'дорогое');
insert into ProductsCategories values (0, 0, 0), (1, 0, 1), (2, 1, 1), (3, 1, 2), (4, 1, 3), (5, 2, 4);

-- выбор всех продуктов и их категорий (left join in the relation many-to-many)
select Products.Name, Categories.Name 
from Products left join ProductsCategories on Products.ProductId = ProductsCategories.ProductId 
left join Categories on Categories.CategoryId = ProductsCategories.CategoryId 