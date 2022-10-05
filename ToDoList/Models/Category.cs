using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public Category()
    {
      this.Items = new HashSet<Item>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Item> Items { get; set; }  //'virtual' keyword "[allows] Entity to use lazy loading to load only the necessary resources from the database" (Lsn 33). 
  }
}