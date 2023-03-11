
# Proje Açıklaması

Bir haber sitesi sistemi için gerekli olan temel api projesi. Haber, Kategori ve User için temel CRUD işlemlerini EF ile gerçekleştiriyor. 

# EF Migration 

```
dotnet ef migrations add InitialMig --project ./DataAccess/DataAccess.csproj
```
```
dotnet ef database update --project ./DataAccess/DataAccess.csproj

```
## API Kullanımı

#### Token üretimini sağlayan login işlemi

```http
  POST /api/Auth/login
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `userName` | `string` | **Gerekli**. Kullanıcı Adı |
| `password` | `string` |**Gerekli**.  Şifre |


#### Kullanıcı Kaydı

```http
  POST /api/Auth/signup
```

| Parametre | Tip     | Açıklama                       |
| :-------- | :------- | :-------------------------------- |
| `userName`      | `string` | **Gerekli**. kullanıcı adı |
| `password`      | `string` | **Gerekli**. Şifre |
| `email`      | `string` | **Gerekli**. E-Mail |



  
## Kullanılan Teknolojiler

* .Net 
* JWT
* EntityFramework 
* AutoMapper 
  
