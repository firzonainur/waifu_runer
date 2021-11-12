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
            StartCoroutine(WaitForSceneLoad());
        }
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");

    }


}
