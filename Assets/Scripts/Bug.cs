using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public Points pts;
    public int val;

    private void Start()
    {
        pts = GameObject.FindObjectOfType<Points>();
    }

    public void AddPoints()
    {
        pts.points += val;
        Destroy(this.gameObject);
    }
}
