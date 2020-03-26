using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] Text healthInteger;
    [SerializeField] State startingState;
    [SerializeField] State gameOver;
    [SerializeField] Text inventoryContent;
    int health;
    string inventoryList;
    private List<string> inventory = new List<string>();

    State currentState;
    State[] nextStates;






    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
        healthInteger.text = "3";
        

    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }


    private void ManageState()
    {
        inventoryContent.text = inventoryList;
        nextStates = currentState.GetNextStates();
        string itemRequirement = currentState.ItemRequiered();
        if (health > 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetState(0);
                //GetItem();
                UpdateInventory();
                //currentState = nextStates[0];
                // health -= currentState.health;
                // Debug.Log(health);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetState(1);
                // GetItem();
                UpdateInventory();
                //currentState = nextStates[1];
                // health -= currentState.health;
                // Debug.Log(health);

            }
            else if (inventory.Contains(itemRequirement) && Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetState(2);
                RemoveFromInventory();
                UpdateInventory();

            }

            textComponent.text = currentState.GetStateStory();


        }
        else
        {
            currentState = gameOver;
            textComponent.text = currentState.GetStateStory();
            if (Input.anyKeyDown)
            {
                ClearInventory();
                Start();
            }
        }
    }

    private void SetState(int i)
    {
        currentState = nextStates[i];
        health -= currentState.health;
        healthInteger.text = Convert.ToString(health);
        GetItem();
        Debug.Log(health);
    }

    private void GetItem()
    {
        string itemToAdd = currentState.ItemToAdd();
        if (string.IsNullOrEmpty(itemToAdd))
        {
            Debug.Log("String is empty");
        }
        
        else
        {
            bool itemExist = inventory.Contains(itemToAdd);
            if (itemExist == false)
                {
                    inventory.Add(itemToAdd);

                }
        }

    }
    private string UpdateInventory()
    {
        inventoryList = "";
        for (int i = 0; i < inventory.Count; i++)
        {
            string item = inventory[i];
            inventoryList += item + "\n";
           
        }
        return inventoryList;
    }

    private void RemoveFromInventory()
    {
        string itemToRemove = currentState.ItemRequiered();
        if (string.IsNullOrEmpty(itemToRemove))
        {
            Debug.Log("String is empty");
        }
        else
        {
            bool itemExist = inventory.Contains(itemToRemove);
            if (itemExist == true)
            {
                inventory.Remove(itemToRemove);
            }
        }
    }

    private void ClearInventory()
    {
        inventoryList = "";
        inventory.Clear();
    }


}
