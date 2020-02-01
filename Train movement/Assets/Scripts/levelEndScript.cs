using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEndScript : MonoBehaviour
{

    //General variables
    public GameObject train;

    public GameObject trainPlayerDetector;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Train enters the end of level trigger box
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == train)
        {


            ////End of level
            ///Win or loss
            //Win
            if (trainPlayerDetector.GetComponent<trainRideScript>().ridingTrain == true)
            {
                //Test
                print("Win");

                //Load next scene
                train.GetComponent<trainManagement>().addNewCarriage();

            }

            //Loss
            else if (trainPlayerDetector.GetComponent<trainRideScript>().ridingTrain == false)
            {
                //Test
                print("Loss");

                //ReloadScene
                //train.GetComponent<trainManagement>().addNewCarriage();

                //SceneManager.LoadScene("beachLevel");

            }


        }

    }

}
