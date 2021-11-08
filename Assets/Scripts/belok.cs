using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belok : MonoBehaviour
{
    public float belokSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float degrees = 90;
            Vector3 to = new Vector3(0, degrees, 0);

            Camera.main.transform.eulerAngles = to;
            Camera.main.transform.position = new Vector3(-5.8f, 3.8f, 717.5f);
            other.gameObject.transform.eulerAngles = to;
        }
    }
}
