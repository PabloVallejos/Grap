using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text[] txt;
    public Button bot;
    public Controller cnt;
    public int points = 0;
    public bool done = false;
    float timer;

    private void Start()
    {
        cnt = GameObject.FindObjectOfType<Controller>();
    }

    private void FixedUpdate()
    {
        txt[0].text = points.ToString();
        txt[1].text = cnt.health.ToString();
        txt[2].text = timer.ToString("0");
        if (cnt == null)
        {
            //FindObjectOfType<WLButton>().YouWinLose(0);
            done = true;
            bot.gameObject.SetActive(true);
            //txt[3].text = "Perdiste :(";
        }
        /*else
        {
            timer += Time.deltaTime;
        }*/
        if (!done)
        {
            timer += Time.deltaTime;
        }
    }
}
