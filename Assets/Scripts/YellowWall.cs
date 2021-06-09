using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SnakeMain")
        {
            other.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
