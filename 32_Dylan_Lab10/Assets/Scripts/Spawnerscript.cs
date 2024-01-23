using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerscript : MonoBehaviour
{
    public GameObject RedObj;
    public GameObject BrownObj;
    public GameObject GreenObj;
    float RedPositionY;
    float BrownPositionY;
    float GreenPositionY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Red", 1, 1);
        InvokeRepeating("Brown", 2, 3);
        InvokeRepeating("Green", 3, 5);
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    void Red()
    {
        RedPositionY = Random.Range(4, -4f);
        this.transform.position = new Vector3(transform.position.x, RedPositionY, transform.position.z);
        Instantiate(RedObj, transform.position, transform.rotation);
    }
    void Brown()
    {
        BrownPositionY = Random.Range(6, -6f);
        this.transform.position = new Vector3(transform.position.x, BrownPositionY, transform.position.z);
        Instantiate(BrownObj, transform.position, transform.rotation);
    }
    void Green()
    {
        GreenPositionY = Random.Range(3, -3f);
        this.transform.position = new Vector3(transform.position.x, GreenPositionY, transform.position.z);
        Instantiate(GreenObj, transform.position, transform.rotation);
    }
}
