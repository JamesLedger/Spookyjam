using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class LerpController : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void Activate()
    {
        anim.SetBool("Up", true);
    }
    public void DeActivate()
    {
        anim.SetBool("Up", false);
    }
    IEnumerator<float> _FlipUp(Quaternion endValue, Quaternion startValue, float time, float duration)
    {
        yield return Timing.WaitForOneFrame;
    }
    IEnumerator<float> _FlipDown(Quaternion endValue, Quaternion startValue, float time, float duration)
    {
        yield return Timing.WaitForOneFrame;
    }

}
