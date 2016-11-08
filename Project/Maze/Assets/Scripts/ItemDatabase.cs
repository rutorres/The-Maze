using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;
	// Use this for initialization
	void Start () {
      //  Item item = new Item(2,"info 3");
      //  database.Add(item);
      //  Debug.Log 
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssests/item.json"));
		ConstructItemDatabase();
	}

	public Item FetchItemByID(int id)
	{
		for (int i = 0; i < database.Count; i++) 

			if(database[i].ID==id)
				return database[i];
		return null;
	}

    void ConstructItemDatabase()
    {
        for (int i= 0; i<itemData.Count;i++)
        {
			database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["description"].ToString(), itemData[i]["slug"].ToString()));
        }  
    }
}


public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
	public string Desc { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

	public Item(int id, string title, string desc, string slug)
    {
        this.ID = id;
        this.Title = title;
		this.Desc = desc;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

	public Item()
	{
		this.ID = -1;
	}
}
