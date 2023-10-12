using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeS : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void ChangeScene(string next)
    {
        SceneManager.LoadScene(next);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
