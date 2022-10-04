using MySql.Data.MySqlClient;
using System.Collections.Generic; 

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; set; }  
    
    public Item(string description)
    {
      Description = description;  
    }

    public Item(string description, int id)
    {
      Description = description; 
      Id = id; 
    }

    public override bool Equals(System.Object otherItem)  //Special method to Override Built-In methods (for "...when we want our app to know when we want two objects to be considered the same".  -Lsn 11) 
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool idEquality = (this.Id == newItem.Id);
        bool descriptionEquality = (this.Description == newItem.Description);
        return (idEquality && descriptionEquality);
      }
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


    public void Save()  //Saves 'Item' objects to the database 
    { 
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;


      /* Begin new code */ 

      cmd.CommandText = "INSERT INTO items (description) VALUES (@ItemDescription);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ItemDescription";
      param.Value = this.Description;
      cmd.Parameters.Add(param);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;   //Returns an id from the Database 

      /* End new code */ 


      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
