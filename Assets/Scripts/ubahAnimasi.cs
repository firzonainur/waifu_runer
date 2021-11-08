using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ubahAnimasi : MonoBehaviour
{
    private string m_currentAnimation;
    public Animator m_animator;
    public GameObject playerObject;

    public float animationSpeed = 1;
    public string animationName = "";

    private void ChangeAnimationState(string animation, float speed)
    {
        if (m_currentAnimation == animation) return;

        m_currentAnimation = animation;
        m_animator.Play(m_currentAnimation);
        m_animator.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimationState(animationName, animationSpeed);
    }
}
