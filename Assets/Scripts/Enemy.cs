using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] dest;
    public float speed;
    private int count = 0;
    private float minD = 0.2f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, dest[count].position, speed * Time.deltaTime);
        if ((transform.position - dest[count].position).sqrMagnitude <= minD/* * minD*/)
        {
            if (count < dest.Length)
            {
                count++;
            }
            if (count >= dest.Length)
            {
                count = 0;
            }
        }
    }
}
