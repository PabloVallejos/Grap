using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Win : MonoBehaviour
{
    public Button but;
    public Controller cnt;
    public Grapple grp;
    AudioSource snd;
    public AudioSource bgm;

    private void Start()
    {
        but.gameObject.SetActive(false);
        cnt = GameObject.FindObjectOfType<Controller>();
        grp = GameObject.FindObjectOfType<Grapple>();
        snd = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.FindObjectOfType<WLButton>().YouWinLose(1);
        but.gameObject.SetActive(true);
        bgm.Stop();
        snd.Play();
        cnt.GetComponent<Rigidbody2D>().isKinematic = true;
        cnt.GetComponent<Grapple>().enabled = false;
        cnt.enabled = false;
        //grp.enabled = false;
    }
}
