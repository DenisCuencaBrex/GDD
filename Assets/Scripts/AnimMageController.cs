using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMageController : MonoBehaviour {
    public Animator atack;

    void Start()
    {
        atack = GetComponent<Animator>();
    }
    public void AttackAnim(int var)
    {
        if (var == 1)
        {
            atack.SetBool("attack", true);
        }
        else if (var == 0)
        {
            atack.SetBool("attack", false);
        }
    }
}
