using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject crackedWindow;
    public GameObject parent;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            GameObject clone = Instantiate(crackedWindow, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }


}
