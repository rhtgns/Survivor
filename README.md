This project is a Web API application for managing Survivor competitors and categories with CRUD operations using Entity Framework Core. The application defines two main entities:

Competitor: Represents a contestant in the Survivor competition, containing properties like FirstName, LastName, and a CategoryId for its category.
Category: Represents the category a competitor belongs to, such as "Celebrities" or "Volunteers", and has a one-to-many relationship with competitors (one category can have many competitors).
We have two controllers:

CompetitorController: Handles operations like listing all competitors, getting competitors by ID, filtering competitors by category, creating, updating, and deleting competitors.
CategoryController: Manages category operations, such as listing all categories, getting a specific category by ID, and performing create, update, and delete operations on categories.
Additionally, the BaseEntity class is used for shared properties like Id, CreatedDate, ModifiedDate, and IsDeleted. Dependency Injection is used to inject the DbContext for database interactions.

The API endpoints are designed to perform the following CRUD operations and are tested via tools like Postman or Swagger.
