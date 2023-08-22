using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappable : MonoBehaviour
{
    public Grapple grp;

    private void Start()
    {
        grp = GameObject.FindObjectOfType<Grapple>();
    }

    private void OnMouseDown()
    {
        grp.obj = this.gameObject;
    }

    private void OnMouseUp()
    {
        grp.obj = null;
    }

    private void OnMouseExit()
    {
        grp.obj = null;
    }
}
