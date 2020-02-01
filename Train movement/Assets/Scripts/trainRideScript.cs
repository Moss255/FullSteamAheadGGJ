using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainRideScript : MonoBehaviour
{
    //General variables
    public GameObject player;

    public GameObject train;




    //Train riding variables
    public bool ridingTrain = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Player in trigger sphere around train
    private void OnTriggerStay(Collider other)
    {

        ////Train riding
        ///On and off train toggle
        if(other.gameObject == player)
        {


            //Toggles on
            if (Input.GetMouseButtonDown(0) && ridingTrain == false)
            {

                ridingTrain = true;

                //Changes player position
                player.transform.position = train.transform.position + new Vector3(0, 1, 1.5f);

                //Makes player child of train
                player.transform.parent = train.transform;

                



            }

            //Toggles off
            else if (Input.GetMouseButtonDown(0) && ridingTrain == true)
            {

                ridingTrain = false;

                //Changes player position
                player.transform.position = train.transform.position + new Vector3(1, 0 ,1);

                //Makes player child of train
                player.transform.parent = null;



            }

        }
        


    }
    
}
