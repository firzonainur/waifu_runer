using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitObstacles : MonoBehaviour
{
    public AudioSource hitObstacle;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        hitObstacle = Instantiate(hitObstacle);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            hitObstacle.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
