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

## Fluent API

Como o EF core trabalha
- Usar o arquivo de contexto (AppDbContext) para mapear as entidades e as tabelas
- Usar o nome das propriedades definidos nas entidades para gerar o nome dos campos nas tabelas
- As propriedades do tipo string vão ser mapeadas para tipo lontext que podem armazenar até 4GB
- As propriedades do tipo decimal vão ser mapeadas para o tipo decimal com uma precisão de 65 e uma escal de 30

### Como sobrescrever as convenções ???

##### 1. Atributos Data Annotations
##### 2. Fluent API

- Data Annotations
-- Fornece atributos de classes (usados para definir metadados) e métodos que podemos usar em nossas classes para altearr as converções padrão e definir um comportamento personalizado que pode ser usado em vários cenarios.

Estão presentes nos namespaces System.ComponentModel.DataAnnotations e 
							   System.ComponentModel.DataAnnotations.Schema
```C#
[Required(ErrorMessage="O nome do usuário é obragatório")]
[StringLength(100)]
public string Name {get;set;}

[Column(TypeName="decimal(12,2)")]
public decimal Price {get;set;}
```

##### Fluent API

É usada para configurar as classes de dominio para substituir convernções
É definida sobrescrevendo o método OnModelCreating na classe de contexto

```C#
 protected override void OnModelCreating(ModelBuilder mb)
{
        //category
        mb.Entity<Category>().HasKey(c => c.CategoryId);

        mb.Entity<Category>().
             Property(c => c.Name).
               HasMaxLength(100).
                    IsRequired();

        //Product
        mb.Entity<Product>().
           Property(c => c.Name).
             HasMaxLength(100).
               IsRequired();
	...
}
```


EF Core Migrations : Ferramenta dotnet-ef
- Instalar ferramenta EF Core Migration Tools
dotnet tool install --global dotnet-ef

- Atualizar ferramenta EF Core Migration Tools
dotnet tool update --global dotnet-ef

Uso: 

dotnet ef migrations add <nome-migracao>
dotnet ef migrations remove
dotnet ef database update


DTO - Data Transfer Object

Padrão de projeto usado para transportar dados entres diferentes componentes de um sistema, diferentes instãncias ou processos de um sistema distribuido ou diferentes camadas em um aplicativo.

AutoMapper

1 - Instalar os pacotes
 	AutoMapper.Extensions.Microsoft.DependencyInjection
 	AutoMapper

2 - Configurar os serviços na classe Program
	builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAsemblies());

3 - Definir o mapeamento entre os objetos : DTOs e Entidades (Profile) 

4 - Injetar a interface IMapper e fazer o mapeamento

Repository

"O padrão  Repository faz a mediação entre o domínio e as camadas de mapeamento de dados, agindo como uma coleção de objetos de domínio em memória....." Martin Fowler

