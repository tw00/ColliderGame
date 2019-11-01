using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public float offset = 0f;
    public Animator anim;

    void Start()
    {
      anim = GetComponent<Animator>();
      anim.SetFloat("offset", offset);
    }
}
