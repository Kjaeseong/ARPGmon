using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> _inventory = new List<Item>();

    private Item _firstSlot;

    private void Start() 
    {
        _firstSlot.Num = 1;
    }

}
