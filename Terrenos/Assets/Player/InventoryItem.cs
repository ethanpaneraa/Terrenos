using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public bool Places = false;
    public bool Destroys = false;
    public int HitDamage = 0;
    public Sprite Sprite;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        itemName = "none";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
