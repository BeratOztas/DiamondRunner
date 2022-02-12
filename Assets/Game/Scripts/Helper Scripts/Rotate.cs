using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotate_Speed = 10f;

    void Update()
    {
        rotate();

    }
    void rotate()
    {
        transform.Rotate(0, rotate_Speed, 0);
    }
}
