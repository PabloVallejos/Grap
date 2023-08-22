using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeS : MonoBehaviour
{
    public void ChangeScene(string next)
    {
        SceneManager.LoadScene(next);
    }
}
