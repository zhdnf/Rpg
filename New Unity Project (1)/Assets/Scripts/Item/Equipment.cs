﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

[CreateAssetMenu(fileName ="New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;


    public override void Use()
    {
        base.Use();
        //Euquip thie item
        EquipmentManager.instance.Equip(this);
        //Remove it from the Inventory 
        RemoveFromInventory();
    }


}

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Shield,
    Feet
}
