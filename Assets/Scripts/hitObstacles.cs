using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hitObstacles : MonoBehaviour
{
    public AudioSource hitObstacle;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            hitObstacle.Play();
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
