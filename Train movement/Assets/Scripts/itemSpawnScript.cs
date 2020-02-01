using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawnScript : MonoBehaviour
{
    ///General variables
    public GameObject itemTemplate;

    public GameObject train;

    public Transform trainTransform;

    public float itemSpawnTimer;

    public float timeToSpawn;


    ///Lists
    //Item names
    public List<string> beachItems;

    //Item meshes
    public List<Material> beachMeshes;


    // Start is called before the first frame update
    void Start()
    {

        trainTransform = train.transform;

    }

    // Update is called once per frame
    void Update()
    {
        ////Item spawn
        ///Timer increase every frame
        itemSpawnTimer += Time.deltaTime;

        ///Item spawning
        if(itemSpawnTimer >= timeToSpawn)
        {
            //Spawns item
            var spawnedItem = Instantiate(itemTemplate, new Vector3(trainTransform.position.x + Random.Range(4f, 15f), 1.5f, trainTransform.position.z + Random.Range(-5f, 5f)), transform.rotation);

            var itemInfo = Random.Range(0, beachItems.Count);

            //Changes item name
            spawnedItem.name = beachItems[itemInfo];
            spawnedItem.GetComponent<itemInfo>().itemName = spawnedItem.name;

            //Changes item mesh
            spawnedItem.GetComponent<MeshRenderer>().material = beachMeshes[itemInfo]; 

            //Reset timer
            itemSpawnTimer = 0;
           
        }


        
    }
}
