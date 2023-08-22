using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Win : MonoBehaviour
{
    public Button but;
    public Controller cnt;
    public Grapple grp;

    private void Start()
    {
        but.gameObject.SetActive(false);
        cnt = GameObject.FindObjectOfType<Controller>();
        grp = GameObject.FindObjectOfType<Grapple>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        but.gameObject.SetActive(true);
        cnt.enabled = false;
        grp.enabled = false;
    }
}
