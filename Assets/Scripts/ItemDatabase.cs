using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public List<Item> itemDB = new List<Item>();
    public TextAsset ItemFile;
    public List<Item> ItemList;

    private void Awake()
    {
        instance = this;
    }

    
    void Start()
    {
        string[] item_Rows = ItemFile.text.Substring(0, ItemFile.text.Length - 1).Split('\n');
        for (int i = 0; i < item_Rows.Length; i++)
        {
            string[] row = item_Rows[i].Split('\t');

            ItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4], row[5], row[6],
                row[7], row[8], row[9], row[10]));
        }
    }

    void Update()
    {
        
    }
}
