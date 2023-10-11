using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Repository<T>
{
    private List<T> data = new List<T>();

    public void Add(T entity)
    {
        data.Add(entity);
    }

    public T Get(int id)
    {
        // Implement logic to retrieve an entity by ID
        return data.FirstOrDefault(); // Replace with actual logic
    }

    public void Update(T entity)
    {
        // Implement logic to update an entity
    }

    public void Delete(int id)
    {
        // Implement logic to delete an entity by ID
    }
}
