using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new rod", menuName = "MyData/FishingRod")]
public class FishingRod : ScriptableObject
{
    [Header("Asthetics")]
    public string rodName;
    public Sprite rodSprite;
    [TextArea(10, 10)]
    public string flavorText;
    [Header("Mechanics")]
    public int rodID;
    public int durability;//default fishing rod should have -1 durability, meaning it's infinite
    public int value; //buy and sell value

}
