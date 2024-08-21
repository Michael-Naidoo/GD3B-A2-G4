using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationdestroys : MonoBehaviour
{
    public float secondsToDestruct;
    void Start()
    {
        StartCoroutine(animationSelfDes(secondsToDestruct));
    }

    public IEnumerator animationSelfDes(float secs)
    {
        yield return new WaitForSecondsRealtime(secs);
        Destroy(gameObject);
    }
}
