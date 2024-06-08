# BookStoreAPI

## Описание

BookStoreAPI - это RESTful API для управления книжным магазином, включая книги, авторов и категории.

## Требования

Для запуска этого проекта вам понадобятся следующие инструменты:

- [.NET Core SDK](https://dotnet.microsoft.com/download) версии 8.0 
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) или другой поддерживаемый сервер баз данных
- [Visual Studio](https://visualstudio.microsoft.com/) или [Visual Studio Code](https://code.visualstudio.com/)

## Настройка проекта

1. **Клонирование репозитория**

    ```bash
    git clone https://github.com/yourusername/BookStoreAPI.git
    cd BookStoreAPI
    ```

2. **Настройка базы данных**

    Откройте файл `appsettings.json` и настройте строку подключения к вашей базе данных. Пример:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=BookStoreDb;User Id=your_user;Password=your_password;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*"
    }
    ```

3. **Применение миграций и создание базы данных**

    Выполните команды в терминале, чтобы создать базу данных и применить миграции:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

## Запуск приложения

1. **Запуск проекта**

    В терминале выполните команду для запуска проекта:

    ```bash
    dotnet run
    ```

    Или запустите проект через Visual Studio, нажав кнопку "Start" (или F5).

2. **Доступ к API**

    API будет доступно по адресу: `https://localhost:5001/api/[controller]` или `http://localhost:5000/api/[controller]`.

    Например:
    - `GET https://localhost:5001/api/books`
    - `GET https://localhost:5001/api/authors`
    - `GET https://localhost:5001/api/categories`

## Структура проекта
- **Controllers**: содержит контроллеры API.
- **Services**: содержит бизнес-логику.
- **Repositories**: содержит код для взаимодействия с базой данных.
- **Models**: содержит модели данных.
- **Data**: содержит контекст базы данных и конфигурации.
## Примеры API запросов
 Получение всех книг
```http
GET /api/books
Добавление новой книги
POST /api/books
Content-Type: application/json

{
  "title": "New Book",
  "price": 19.99,
  "categoryId": 1,
  "bookAuthors": [
    {
      "authorId": 1
    }
  ]
}
Обновление книги
PUT /api/books/{id}
Content-Type: application/json

{
  "id": 1,
  "title": "Updated Book",
  "price": 29.99,
  "categoryId": 1,
  "bookAuthors": [
    {
      "authorId": 1
    }
  ]
}
Удаление книги
DELETE /api/books/{id}
