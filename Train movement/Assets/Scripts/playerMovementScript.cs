using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{
    //General variables
    public GameObject player;

    public GameObject train;

    public GameObject trainPlayerdetector;

    public GameObject itemHeld;

    public bool followPlayer;

    public Vector3 itemDirection;



    //Movement variables
    public float playerSpeed;


    




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (itemHeld && followPlayer)
        {
            //player.transform.Rotate(new Vector3(0, 45, 0));

            itemDirection = new Vector3(Input.GetAxis("Horizontal") * 2, 0, Input.GetAxis("Vertical") * 2);

            itemHeld.transform.position = player.transform.position + itemDirection;

            
        }










        ////Movement

        ///When player isn't riding on the train
        if (trainPlayerdetector.GetComponent<trainRideScript>().ridingTrain == false)
        {

            ///Up
            if (Input.GetKey(KeyCode.W))
            {

                //Moves player up on Z axis
                player.transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0, playerSpeed * Time.deltaTime);

            }


            ///Down
            else if (Input.GetKey(KeyCode.S))
            {

                //Moves player down on Z axis
                player.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, -playerSpeed * Time.deltaTime);

            }


            ///Left
            if (Input.GetKey(KeyCode.A))
            {

                //Moves player down on X axis
                player.transform.position += new Vector3(-playerSpeed * Time.deltaTime, 0, -playerSpeed * Time.deltaTime);

            }


            ///Right
            else if (Input.GetKey(KeyCode.D))
            {

                //Moves player up on X axis
                player.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, playerSpeed * Time.deltaTime);

            }


        }
        


    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (!itemHeld)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    other.gameObject.GetComponent<itemInfo>().isCollected = true;
                    itemHeld = other.gameObject;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                itemHeld.GetComponent<Rigidbody>().AddForce(itemDirection);
                itemHeld = null;
            }


        }
    }




}
