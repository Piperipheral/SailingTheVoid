using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FishMan", menuName = "MyData/FishType")]
public class Fishes : ScriptableObject
{
    float id;
    string fishName;
    Sprite sprite;
    string flavorText;
}
