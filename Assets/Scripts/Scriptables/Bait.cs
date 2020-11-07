using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new bait", menuName = "MyData/Bait")]
public class Bait : ScriptableObject
{
    [Header("Asthetics")]
    public string baitName;
    public Sprite baitSprite;
    [TextArea(10, 10)]
    public string flavorText;
    [Header("Mechanics")]
    public int baitID;
    public int value; //buy and sell value;
    //bait information will be added later
}
