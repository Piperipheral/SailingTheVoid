using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spaceship", menuName = "MyData/Spaceship")]
public class Spaceship : ScriptableObject
{
    public int maxFuel;
    public int curFuel;
    public int fuelDecreseRate;
    public bool isEngineOn;
    [Header("Inventory")]
    public Bait equippedBait;
    public FishingRod equippedRod;
    public Fishes[] inTank = new Fishes[10];
    public void restart()
    {
        curFuel = maxFuel;
        isEngineOn = false;
    }
}
