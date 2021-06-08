using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateApple : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0 , 40 * Time.deltaTime);
    }
}
