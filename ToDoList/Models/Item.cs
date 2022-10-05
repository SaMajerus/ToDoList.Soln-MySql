//using MySql.Data.MySqlClient;
//using System.Collections.Generic; 
//
namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }  

/*    
    public Item(string description)
    {
      Description = description;  
    }

    public Item(string description, int id)
    {
      Description = description; 
      ItemId = id; 
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
        bool idEquality = (this.ItemId == newItem.ItemId);
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


    public static Item Find(int id)
    {
      // We open a connection.
      MySqlConnection conn = DB.Connection();
      conn.Open();

      // We create MySqlCommand object and add a query to its CommandText property. We always need to do this to make a SQL query.
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items WHERE id = @ThisId;";

      // We have to use parameter placeholders @ThisId and a `MySqlParameter` object to prevent SQL injection attacks. This is only necessary when we are passing parameters into a query. We also did this with our Save() method.
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);

      // We use the ExecuteReader() method because our query will be returning results and we need this method to read these results. This is in contrast to the ExecuteNonQuery() method, which we use for SQL commands that don't return results like our Save() method.
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemDescription = "";
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemDescription = rdr.GetString(1);
      }
      Item foundItem = new Item(itemDescription, itemId);

      // We close the connection.
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }


    public void Save()  //Saves 'Item' objects to the database 
    { 
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;


      * Begin new code * 

      cmd.CommandText = "INSERT INTO items (description) VALUES (@ItemDescription);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ItemDescription";
      param.Value = this.Description;
      cmd.Parameters.Add(param);    
      cmd.ExecuteNonQuery();
      ItemId = (int) cmd.LastInsertedId;   //Returns an id from the Database 

      * End new code * 


      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }*/

  }
}
