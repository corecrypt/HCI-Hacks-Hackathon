using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnT : MonoBehaviour
{
    public GameObject AnimatedObject;
    void OnTriggerEnter(Collider other)
    {
        AnimatedObject.GetComponent<Animation>().CrossFade("Fire");
        AnimatedObject.GetComponent<AudioSource>().Play();
    }
}
