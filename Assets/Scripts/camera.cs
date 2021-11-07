using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float shotForce = 1000f; //kekuatan tembakan
    public float moveSpeed = 10f; //kecepatan gerak

    //variable untuk mouse pointer
    private Vector3 offset;
    [Range(0f, 10f)]
    public float turnSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // h dan v adalah kendali dari  keyboard untuk AIM penembakan bola
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; //gerak kiri kanan
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed; // gerak maju mundur

        //update lokasi kamera untuk kendali AIM
        transform.Translate(new Vector3(h, 0f, v)); // gerak mouse

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        transform.LookAt(transform.position + offset);
    }
}
