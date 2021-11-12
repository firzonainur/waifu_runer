using UnityEngine;

public class player : MonoBehaviour
{
    private string m_currentAnimation;
    private Animator m_animator;
    private Rigidbody rigid;

    public float moveSpeed = 10f;
    public float forwardSpeed = 20f;
    public float animationSpeed = 1;
    public float jumpAmount = 10f;

    private bool isJumping = false;
    public bool canMove = true;
    public bool idle = false;

    public Transform cameraTransform;

    public Vector3 offset;

    private void ChangeAnimationState(string animation, float speed)
    {
        if (m_currentAnimation == animation) return;

        m_currentAnimation = animation;
        m_animator.Play(m_currentAnimation);
        m_animator.speed = speed;
    }

    private void moveForward(float speed)
    {
        Vector3 velocity = rigid.velocity;

        if (transform.rotation.y == 0) velocity.z = speed;
        else velocity.x = speed;

        rigid.velocity = velocity;
    }

    private void moveHorizontal(float speed)
    {
        Vector3 velocity = rigid.velocity;

        if (transform.rotation.y == 0) velocity.x = speed;
        else velocity.z = -speed;

        rigid.velocity = velocity;
    }

    private void stopHorizontal()
    {
        Vector3 velocity = rigid.velocity;
        if (transform.rotation.y == 0) velocity.x = 0;
        else velocity.z = 0;

        rigid.velocity = velocity;
    }

    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            moveForward(forwardSpeed);
            cameraTransform.position = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);

            if (Input.GetKey(KeyCode.D))
            {
                moveHorizontal(moveSpeed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveHorizontal(-moveSpeed);
            }
            else stopHorizontal();
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
