using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum tipRequired
{
    pickup,
    deposit,
    enter,
    exit
}
public class playerTips : MonoBehaviour
{
    public tipRequired tip;

    public List<Sprite> popUps;

    public GameObject tipArea;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        tipArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tipArea.GetComponent<SpriteRenderer>().sprite = popUps[(int)tip];

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            tipArea.SetActive(true);
        }
        else
        {
            tipArea.SetActive(false);
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // Am I interacting with an Item?
        if (other.gameObject.CompareTag("Item"))
        {
            tipArea.SetActive(true);

            tip = tipRequired.pickup;
        }

        // Am I interacting with the carriage?
        if (other.gameObject.CompareTag("Carriage") && gameObject.GetComponent<playerMovementScript>().itemHeld)
        {
            tipArea.SetActive(true);

            tip = tipRequired.deposit;
        }

        timer = 3;
    }

    private void OnTriggerStay(Collider other)
    {
        timer = 3;

        if (other.gameObject.CompareTag("Train"))
        {
            tipArea.SetActive(true);

            tip = tipRequired.enter;
        }

        if (gameObject.GetComponent<playerMovementScript>().train.GetComponentInChildren<trainRideScript>().ridingTrain)
        {
            tipArea.SetActive(true);

            tip = tipRequired.exit;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tipArea.SetActive(false);
    }
}
