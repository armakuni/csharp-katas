# Overview:
Create a generic repository pattern for data access in C#. You will define a repository class that works with entities of different types using generics. The repository should support common CRUD (Create, Read, Update, Delete) operations.

Three classes exist, which are examples of data which will need to be inserted into the repository - User, Product, and Order.

# Instructions:
1. Define a generic repository class that can work with any entity type. You can call it Repository<T>, where T represents the entity type.
2. Implement an in-memory data store or use a simple collection (e.g., List) to hold the data within the repository.
3. Create methods for common data operations, such as Add, Get, Update, and Delete, within the generic repository class.
   1. Add should add a single data item to the repository
   2. Get should return a specific item from the reposity, matching on ```Id```
   3. Update should update (replace) an item in the repository, matching on ```Id```, and return a result indicating whether it was successful or not
   4. Delete should remove an item from the repository, matching on ```Id```, and return a result indicating whether it was successful or not
4. Ensure that the generic repository can handle different entity types (e.g., User, Product, Order) without duplicating code.
5. Test the generic repository with different entity types to make sure it works correctly.

You can add to the data classes if required provided they retain their initial properties.