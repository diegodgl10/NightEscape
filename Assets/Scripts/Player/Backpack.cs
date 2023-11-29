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

    // Start the backpack
    private void StartBackpack()
    {
        this.backpack = new List<Item>();
        Item item;
        item = new Item("Flashlight", "It will help you see in the dark.");
        this.backpack.Add(item);
        item = new Item("Fuse", "Big fuse, can withstand a lot of energy.");
        this.backpack.Add(item);
        item = new Item("First aid kit", "First aid kit.");
        this.backpack.Add(item);
        item = new Item("Sword", "Sword of Luis Ignacio Negrete Kalvillo.");
        this.backpack.Add(item);
        item = new Item("Key A", "Key with the inscription \"A\".");
        this.backpack.Add(item);
        item = new Item("Elevator III", "Key for the elevator on floor III.");
        this.backpack.Add(item);
    }
}
