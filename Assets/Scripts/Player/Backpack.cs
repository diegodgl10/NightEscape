using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    /**
     * Class for an item
     */
    public class Item
    {
        // Item name
        private string name;
        // Indicates the quantity of objects of the same type
        private int quantity;
        // Indicates if the item has been picked up
        private string description;
        
        public Item(string name, int quantity, string description)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
        }

        public Item(string name, string description)
        {
            this.name = name;
            this.quantity = 0;
            this.description = description;
        }

        public Item()
        {
        }

        /**
         * Returns the name of the item
         */
        public string GetName()
        {
            return this.name;
        }

        /**
         * Returns the quantity of the item
         */
        public int GetQuantity()
        {
            return this.quantity;
        }

        /**
         * Returns the item quantity
         */
        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        /**
         * Increases the quantity of the item
         */
        public void Increase()
        {
            this.quantity++;
        }

        /**
         * Decreases the quantity of the item
         */
        public void Decrease()
        {
            this.quantity = (this.quantity-1 < 0) ? 0 : this.quantity-1;
        }

        /**
         * Returns the item description
         */
        public string GetDescription()
        {
            return this.description;
        }
    }
    
    // List of items
    List<Item> backpack;

    // Start is called before the first frame update
    void Start()
    {
        StartBackpack();
    }

    /**
    * Increases the quantity of the item
    */
    public void AddItem(string itemName)
    {
        foreach(Item item in this.backpack){
            if (item.GetName() == itemName)
            {
                item.Increase();
            }
        }
    }

    /**
    * Decreases the quantity of the item
    */
    public void SubtractItem(string itemName)
    {
        foreach (Item item in this.backpack)
        {
            if (item.GetName() == itemName)
            {
                item.Decrease();
            }
        }
    }

    /**
     * Returns the number of items
     */
    public int ItemQuantity(string itemName)
    {
        foreach (Item item in this.backpack)
        {
            if (item.GetName() == itemName)
            {
                return item.GetQuantity();
            }
        }
        return -1;
    }

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();
        foreach (Item item in this.backpack)
        {
            if (item.GetQuantity() < 0)
            {
                items.Add(item);
            }
        }
        return items;
    }

    // Start the backpack
    private void StartBackpack()
    {
        this.backpack = new List<Item>();
        Item item;
        item = new Item("First aid", "First aid kit.");
        this.backpack.Add(item);
        item = new Item("Flashlight", "It will help you see in the dark.");
        this.backpack.Add(item);
        item = new Item("Fuse", "Big fuse, can withstand a lot of energy.");
        this.backpack.Add(item);
        item = new Item("Sword", "Sword of Luis Ignacio Negrete Kalvillo.");
        this.backpack.Add(item);
        item = new Item("Key A", "Key with the inscription \"A\".");
        this.backpack.Add(item);
        item = new Item("Elevator I", "Key for the elevator on floor I.");
        this.backpack.Add(item);
        item = new Item("Elevator II", "Key for the elevator on floor II.");
        this.backpack.Add(item);
        item = new Item("Elevator III", "Key for the elevator on floor III.");
        this.backpack.Add(item);
        item = new Item("USB", "A simple usb.");
        this.backpack.Add(item);

        AddNotes();
    }

    private void AddNotes()
    {
        string note1 = "From: Lucas, \n Something bad has happened, get out of here!";
        string note2 = "From: Emma, \n The security mechanisms are broken, we have to turn everything back on.";
        string note3 = "From: Emma, \n Why did this happen? We just wanted to stop the bedbugs and help the world.";
        string note4 = "From: Rebecca, \n before all this happened, I saw Professor Roberto very nervous in the hallways.";

        Item item;
        item = new Item("Note 1", note1);
        this.backpack.Add(item);
        item = new Item("Note 2", note2);
        this.backpack.Add(item);
        item = new Item("Note 3", note3);
        this.backpack.Add(item);
        item = new Item("Note 4", note4);
        this.backpack.Add(item);
    }
}
