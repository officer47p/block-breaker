using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int totalBlocksNum = 0;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void RegisterBlock()
    {
        totalBlocksNum++;
    }

    public void RemoveBlock()
    {
        totalBlocksNum--;
        if (totalBlocksNum <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
