using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchManager : MonoBehaviour
{
    public static CatchManager Instance { get; private set; }
    public Queue<IEnumerator> animationQueue = new Queue<IEnumerator>();
    [Tooltip("GUI of pokemon")] public GameObject pokemon;
    [Tooltip("GUI of pokeball")] public GameObject pokeball_GUI; 
    [Tooltip("GameObject of pokeball")] public GameObject pokeball;


    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator Capture()
    {
        yield return new WaitForSeconds(0.5f);

        pokeball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pokeball.GetComponent <Rigidbody>().drag = 10;

        while (true)
        {
            pokemon.transform.position = Vector3.Lerp(pokemon.transform.position, pokeball_GUI.transform.position, 0.05f);
            pokemon.transform.localScale = Vector3.Lerp(pokemon.transform.localScale, Vector3.zero, 0.05f);

            if (Vector3.Distance(pokemon.transform.position, pokeball_GUI.transform.position) <= 0.01)
            {
                Debug.Log("Finished Capture");
                break;
            }
            yield return null;
        }

        pokeball.GetComponent<Rigidbody>().drag = 0;
    }
}
