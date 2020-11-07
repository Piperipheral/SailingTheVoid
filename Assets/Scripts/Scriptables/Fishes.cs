using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FishMan", menuName = "MyData/FishType")]
public class Fishes : ScriptableObject
{
    [Header("Asthetics")]
    public string fishName;
    public Sprite sprite;
    [TextArea(10, 10)]
    public string flavorText;
    [Header("Mechanics")]
    public float id;
    public Bait favoriteBait;
    public int fishStregth;
}
