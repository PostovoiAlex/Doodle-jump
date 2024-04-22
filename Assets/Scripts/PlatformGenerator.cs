using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefabs;

    [SerializeField] List<Platform> platforms;

    private void Start()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            platforms[i].OnDestoyed += OnPlatformDestroyed;
        }
    }
    private void OnPlatformDestroyed(Platform platform)
    {
        Transform t = platform.gameObject.transform;
        t.position += new Vector3(0, Random.Range(6, 7), 0);

        t.localScale = new Vector3(Random.Range(2, 5), t.localScale.y, t.localScale.z) ;
    }
}
