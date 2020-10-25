using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settag : MonoBehaviour
{
    private void Awake() {
        this.gameObject.tag = "OVRHand";
    }
}
