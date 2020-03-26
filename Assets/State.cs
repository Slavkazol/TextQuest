using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(14,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] string item;
    [SerializeField] string itemRequiered;
    public int health;

    public string GetStateStory()
    {
        return storyText;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }
    public string ItemToAdd()
        {
            return item;
        }
    public string ItemRequiered()
    {
        return itemRequiered;
    }

}
