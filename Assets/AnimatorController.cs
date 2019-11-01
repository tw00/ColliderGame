using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public float offset = 0f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      anim.SetFloat("offset", offset);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
