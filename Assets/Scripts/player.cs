using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float shotForce = 1000f; //kekuatan tembakan
    public float moveSpeed = 10f; //kecepatan gerak horisontal
    public float forwardSpeed = 10f; //kecepatan gerak maju

    public bool canMove = true;
    public bool idle = false;

    private string m_currentAnimation;
    private Animator m_animator;

    public float animationSpeed = 1;

    public Transform cameraTransform;

    //variable untuk mouse pointer
    [Range(0f, 10f)]
    public float turnSpeed = 1f;

    private bool isJumping = false;

    private Rigidbody rigid;
    public float jumpAmount;

    private void ChangeAnimationState(string animation, float speed)
    {
        if (m_currentAnimation == animation) return;

        m_currentAnimation = animation;
        m_animator.Play(m_currentAnimation);
        m_animator.speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // h dan v adalah kendali dari  keyboard untuk AIM penembakan bola
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; //gerak kiri kanan
        float v = Time.deltaTime * forwardSpeed; // gerak maju mundur

        //update lokasi kamera untuk kendali AIM
        if (canMove)
        {
            transform.Translate(new Vector3(h, 0f, v)); // gerak mouse
            cameraTransform.Translate(new Vector3(h, 0f, v));
        }

        if (idle)
        {
            ChangeAnimationState("idle", animationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            ChangeAnimationState("jump", animationSpeed);
            rigid.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
            Camera.main.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jalan")
        {
            isJumping = false;
            ChangeAnimationState("Slow Run", animationSpeed);
        }
    }
}
