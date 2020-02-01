using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    //Item object variables
    public int ID;

    public string itemName;

    //Collection variables
    public bool isCollected;

    // Start is called before the first frame update
    void Start()
    {

        ////ID setting for items
        switch (itemName)
        {

            case "Bucket":
                ID = 0;
                break;

            case "BucketWrong":
                ID = 1;
                break;

            //case "BeachBall":
            //    ID = 0;
            //    break;

            //case "BeachBallWrong":
            //    ID = 1;
            //    break;

            //case "Bucket":
            //    ID = 2;
            //    break;

            //case "BucketWrong":
            //    ID = 3;
            //    break;

            //case "Sunglasses":
            //    ID = 4;
            //    break;

            //case "SunglassesWrong":
            //    ID = 5;
            //    break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


}
