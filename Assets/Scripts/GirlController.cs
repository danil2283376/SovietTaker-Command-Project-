using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirlController : MonoBehaviour
{
    public string SceneName;
    public void Push()
    {
        SceneManager.LoadScene(SceneName);
    }
}
