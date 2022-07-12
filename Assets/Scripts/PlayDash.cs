using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDash : MonoBehaviour
{
    private Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
        anim.Play("Dash");
    }
}
