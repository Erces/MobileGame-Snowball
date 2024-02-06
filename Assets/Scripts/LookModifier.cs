using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookModifier : MonoBehaviour
{
    public static LookModifier instance;
    public List<GameObject> rocks,bottles;
    public int rockCount,bottleCount;
    public bool rockSet,bottleSet;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(rockCount == 5 && !rockSet)
        {
            setRockLook();
        }
        else if(bottleCount == 3 && !bottleSet)
        {
            setBottleLook();
        }
    }
    public void setRockLook()
    {
        rockSet = true;
        foreach (var item in rocks)
        {
            item.SetActive(true);
        }

    }
    public void setBottleLook()
    {
        bottleSet = true;
        foreach (var item in bottles)
        {
            item.SetActive(true);
        }
    }
}
