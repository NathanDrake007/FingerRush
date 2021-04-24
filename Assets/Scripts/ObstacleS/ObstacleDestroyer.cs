using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    RainBall rb;
    private void Start()
    {
        rb = GetComponentInParent<RainBall>();
    }
    private void OnBecameInvisible()
    {
        rb.Destroy();
    }
}
