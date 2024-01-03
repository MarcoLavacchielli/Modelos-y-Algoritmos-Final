using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charview : MonoBehaviour
{
    private Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponentInChildren<Animator>();
    }

    public void Isrunning(bool running)
    {
        myAnim.SetBool("isrunning", running);
    }
    public void Isjumping(bool jumping)
    {
        myAnim.SetBool("isjumping", jumping);
    }
    public void Iskicking(bool kicking)
    {
        myAnim.SetBool("iskicking", kicking);
    }
}