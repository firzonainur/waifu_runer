using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skor : MonoBehaviour
{
    public int m_skor = 0;
    public AudioSource hitVoice;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMesh>().text = m_skor.ToString();
    }
}
