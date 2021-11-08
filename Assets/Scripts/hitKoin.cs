using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitKoin : MonoBehaviour
{
    public AudioSource hitVoice;
    public TextMesh scoreMesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        hitVoice = Instantiate(hitVoice);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "koin")
        {
            hitVoice.Play();
            scoreMesh.GetComponent<skor>().m_skor += 1;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
