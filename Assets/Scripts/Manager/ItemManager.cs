using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;
    public static ItemManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ItemManager)) as ItemManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public TextAsset itemFile;
    public List<Item> itemDictionary = new List<Item>();
    public List<Sprite> itemSprites = new List<Sprite>();

    public TextAsset manufactureItemFile;
    public List<ManufactureTable> manufactureTable = new List<ManufactureTable>();

    //인벤토리. 배열로 해야겠다...!
    public List<Item> public_Items = new List<Item>();
    public Item[] explore_Items;
    public Item[] player_Items;

    void Start()
    {
        string[] item_Rows = itemFile.text.Substring(0, itemFile.text.Length - 1).Split('\n');

        for (int i = 0; i < item_Rows.Length; i++)
        {
            string[] row = item_Rows[i].Split('\t');
            itemDictionary.Add(new Item(row[0], row[1], row[2], row[3], row[4], row[5], row[6], itemSprites[0]));
        }

        string[] manufactureItem_Rows = manufactureItemFile.text.Substring(0, manufactureItemFile.text.Length - 1).Split('\n');

        for (int i = 0; i < manufactureItem_Rows.Length; i++)
        {
            string[] row = manufactureItem_Rows[i].Split('\t');
            manufactureTable.Add(new ManufactureTable(row[0], row[1], row[2], row[3], row[4], row[5]));
        }
    }

    public Item GetItem(int id)
    {
        Item newItem = itemDictionary[id];
        return newItem;
    }

    public void MoveItems()
    {
        for (int i = 0; i < explore_Items.Length; i++)    
        {
            if(explore_Items[i] != null)
            {
                public_Items.Add((Item)explore_Items[i]);
                explore_Items[i] = null;
            }
        }
    }
}
