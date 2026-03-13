using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] public Animation Anim;
    public void AnimationPlay()
    {
        Anim = gameObject.GetComponent<Animation>();

        Anim.Play();
    }
}
