using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>


[System.Serializable]
public class Stat
{
    [SerializeField]
    public int baseValue;

    [SerializeField]
    public int finalValue;

    List<int> modifiers = new List<int>();
    public int GetValue()
    {
        finalValue = baseValue;
        foreach(int x in modifiers)
        {
            finalValue += x;
        }
        // modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
