using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

    }
    public void Run(bool run)
    {
        anim.SetBool(AnimationTags.RUN, run);
    }
    public void Victory(bool victory) {
        anim.SetBool(AnimationTags.VICTORY, victory);
    }
}
