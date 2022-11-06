--�������� ��
create database MindBoxSqlTestDb
go

use MindBoxSqlTestDb

--�������� ������
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

-- ������� ��� ��������� ������ �� ������
create table ProductsCategories
(
	ProductsCategoriesId int not null primary key,
	CategoryId int not null foreign key references Categories(CategoryId),
	ProductId int not null foreign key references Products(ProductId)
)

--������� ������ � �������
insert into Products values (0, N'�����'), (1, N'����'), (2, N'����'), (3, N'�������'), (4, N'������'), (5, N'�����');
insert into Categories values (0, N'�������'), (1, N'�������'), (2, N'�������');
insert into ProductsCategories values (0, 0, 0), (1, 0, 1), (2, 1, 1), (3, 1, 2), (4, 1, 3), (5, 2, 4);

-- ����� ���� ��������� � �� ��������� (left join in the relation many-to-many)
select Products.Name, Categories.Name 
from Products left join ProductsCategories on Products.ProductId = ProductsCategories.ProductId 
left join Categories on Categories.CategoryId = ProductsCategories.CategoryId 