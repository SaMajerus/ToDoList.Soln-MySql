using MySql.Data.MySqlClient;
using System.Collections.Generic; 

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; }  //"Read-only" property
    
    public Item(string description)
    {
      Description = description;  
    }

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

    //**Refactored in Wk10, Lsn 10 [https://www.learnhowtoprogram.com/c-and-net/database-basics/deleting-objects-in-the-database]
    public static void ClearAll()  
    {
      MySqlConnection conn = DB.Connection();
      conn.Open(); 
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM items;";  //SQL statement 'DELETE FROM items;' clears the entire 'items' table in our given database. 
      cmd.ExecuteNonQuery(); //"SQL statements that modify data instead of querying and returning data are executed with [this method]." 
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Item Find(int searchId)
    {
      // Temporarily returning placeholder item to get beyond compiler errors until we refactor to work with database.
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }

  }
}
