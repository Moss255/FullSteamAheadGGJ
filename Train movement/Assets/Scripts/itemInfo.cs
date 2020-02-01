using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    public int ID;

    public string itemName;

    public bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        switch (itemName)
        {
            case "Wood":
                ID = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


}
