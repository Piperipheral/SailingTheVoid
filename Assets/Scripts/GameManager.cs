using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour
{
    public Spaceship curShip;
    public bool resetFuelOnStart;
    [Header("GameSettings")]
    public int fuelDepleteThreshold;
    private int counter;

    [Header("Inventory")]
    public Bait defaultBait;
    public FishingRod DefaultRod;
    public void Start()
    {
        counter = 0;
        if (resetFuelOnStart) curShip.restart();
    }
    public void depleteFuel()
    {
        counter++;
        if (counter > fuelDepleteThreshold)
        {
            curShip.curFuel -= curShip.fuelDecreseRate;
            counter = 0;
        }

    }
    public void FixedUpdate()
    {
        if (curShip.isEngineOn) depleteFuel();
    }

    public void useRod() {
        //if rod is durabiliity < 0; equip default rod
        //get the fishing minigame open
    }
}
