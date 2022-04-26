# VShop
## Descrição do projeto

loja virtual usando o conceito de microsserviços no ambiente do .NET 6 com ASP .NET Core, EF Core e MySQL e Fluent API

checklist de atividades

	1. dotnet --version
	2. dotnet new --list
	3. mkdir LojaVirtual
	4. dotnet new sln --name VShop
	5. dotnet new webapi -o VShop.ProductApi -au none
	6. dotnet sln add VShop.ProductApi\
	7. dotnet add package Pomelo.EntityFrameworkCore.MySql
	8. dotnet add package Microsoft.EntityFrameworkCore.Design
	9. dotnet tool install --global dotnet-ef
	10. dotnet tool update --global dotnet-ef
	11. Add na models uma classe chamada Product e Category e definir relacionamento de 1:N entre category e Product
	12. Add classe AppDbContext
	13. Na appsettings.json add DefaultConnection
	14. Na Program.cs add builder.Configuration
