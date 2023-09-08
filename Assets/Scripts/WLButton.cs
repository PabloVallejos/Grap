using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WLButton : MonoBehaviour
{
    public Image img;
    public Sprite[] spr;
    public AudioClip[] ac;
    public AudioSource ase;

    private void Awake()
    {
        ase = GetComponent<AudioSource>();
    }

    public void YouWinLose(int i)
    {
        img.sprite = spr[i];
        ase.loop = false;
        ase.clip = ac[i];
        ase.Play();
    }
}
