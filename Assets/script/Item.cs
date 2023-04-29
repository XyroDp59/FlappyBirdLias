using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite spriteImage;
    public int price;
}
