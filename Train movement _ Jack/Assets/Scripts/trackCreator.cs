using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCreator : MonoBehaviour
{
    public GameObject track;

    public float disappearingSpeed;

    public bool isSpawningMore;

    public float spawningDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carriage") && isSpawningMore == true)
        {
            Vector3 previousTrackPosition = gameObject.transform.position;

            Instantiate(track, previousTrackPosition + new Vector3(0, 0, spawningDistance), Quaternion.identity);

            Destroy(track, disappearingSpeed);
        }
    }
}
