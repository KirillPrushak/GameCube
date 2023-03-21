using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public void Move()
    {
        gameObject.transform.position += new Vector3(Time.deltaTime * -0.5f, 0, Time.deltaTime * -0.5f);
    }
}