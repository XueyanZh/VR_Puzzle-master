using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Confirmed()
    {
        print("Button clicked");
        SceneManager.LoadScene("Scene2");
    }
}
