using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _sceneNum;

    public void SceneLoad()
    {
        SceneManager.LoadScene(_sceneNum);
    }
}
