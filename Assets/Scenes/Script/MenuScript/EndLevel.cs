using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public int scene_index;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MaybeEndLevel", 2.0f, 1.0f);
    }

    void MaybeEndLevel()
    {
        Debug.Log("Essa");
        if (FindObjectsOfType<EnemySpawner>().Length == 0 && FindObjectsOfType<PlayerAwarenessController>().Length == 0) {
            SceneManager.LoadSceneAsync(scene_index);
        }
    }
}
