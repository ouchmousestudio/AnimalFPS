using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{

    [SerializeField] float loadtime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(loadtime);
        StartCoroutine (FindObjectOfType<SceneLoader>().LoadLevel("Arctic"));
    }
}
