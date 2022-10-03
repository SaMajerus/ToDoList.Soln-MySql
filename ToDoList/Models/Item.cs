using MySql.Data.MySqlClient;
using System.Collections.Generic; 

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; }  //"Read-only" property
    
    public Item(string description, int id)
    {
      Description = description; 
      Id = id; 
    }

    //Returns all records from the Database 
    public static List<Item> GetAll()
    {
        List<Item> allItems = new List<Item> { };
        MySqlConnection conn = DB.Connection();
        conn.Open();  //1.) Opens a database connection

        //Constructs an SQL query
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = "SELECT * FROM items;";

        //Returns the query results from the database
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader; 
        while (rdr.Read()) 
        {
            int itemId = rdr.GetInt32(0);
            string itemDescription = rdr.GetString(1);
            Item newItem = new Item(itemDescription, itemId);
            allItems.Add(newItem);
        }

        //Closes the connection [to the database] 
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allItems;
    }

    public static void ClearAll()
    {
    }

    public static Item Find(int searchId)
    {
      // Temporarily returning placeholder item to get beyond compiler errors until we refactor to work with database.
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }

  }
}
