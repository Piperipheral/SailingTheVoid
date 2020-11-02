using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [Header("Intensity")]
    public float myInterval = 100;
    public float range = 1f;
    public float offset = 0;
    /*
    [Header("Range")]
    public float myInterval_Range = .1f;
    public float range_Range = 1f;
    public float offset_Range = 0;
    */

    private Light myLight;
    private float maxLight;
    private float minLight;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        myLight = gameObject.GetComponent<Light>();
        myLight.intensity += offset;
        maxLight = myLight.intensity + range;
        minLight = Mathf.Max(myLight.intensity - range, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (direction)
        {
            myLight.intensity += myInterval;
        }
        else
        {
            myLight.intensity -= myInterval;
        }
        if (myLight.intensity >= maxLight || myLight.intensity <= minLight)
            direction = !direction;
            
        if (direction_Range)
        {
            myLight.range += myInterval_Range;
        }
        else
        {
            myLight.range -= myInterval_Range;
        }
        if (myLight.range >= maxLight_Range || myLight.range <= minLight_Range)
            direction_Range = !direction_Range;
            */
        if (counter++ > myInterval)
        {
            counter = 0;
            GetComponent<Light>().intensity = (Random.Range(minLight, maxLight));
        }

    }
}
