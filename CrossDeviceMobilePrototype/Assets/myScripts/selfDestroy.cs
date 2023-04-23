using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    //specify lifetime for object

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Sets object as active and hides after timer elapsed
    public void createAndDestroy(int time)
    {
        //Set active
        gameObject.SetActive(true);
        //Set inactive after timer
        Invoke("destroyObject", time);
    }

    void destroyObject()
    {
        //sets inactive
        gameObject.SetActive(false);
    }
}
