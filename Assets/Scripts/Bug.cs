using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public Points pts;
    public Transform[] dest;
    public bool mov;
    public int val;
    public float speed;
    private int count = 0;
    private float minD = 0.2f;

    private void Start()
    {
        pts = GameObject.FindObjectOfType<Points>();
    }

    private void FixedUpdate()
    {
        if (mov)
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

    public void AddPoints()
    {
        pts.points += val;
        Destroy(this.gameObject);
    }
}
