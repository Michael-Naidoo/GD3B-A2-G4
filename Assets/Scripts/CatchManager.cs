using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchManager : MonoBehaviour
{
    public static CatchManager Instance { get; private set; }
    public Queue<IEnumerator> animationQueue = new Queue<IEnumerator>();
    [Tooltip("GUI of pokemon")] public GameObject pokemon_GUI;
    [Tooltip("GameObject of pokemon")] public GameObject pokemon;
    [Tooltip("GUI of pokeball")] public GameObject pokeball_GUI;
    [Tooltip("GameObject of pokeball")] public GameObject pokeball;


    private void Awake()
    {
        Instance = this;
    }

    public void CatchSuccess()
    {
        animationQueue.Enqueue(Capture());
        animationQueue.Enqueue(Tick(3, 1));
        animationQueue.Enqueue(Success(2));

        StartCoroutine(PlayAnimationQueue());
    }

    public void CatchFail()
    {
        animationQueue.Enqueue(Capture());
        animationQueue.Enqueue(Tick(Random.Range(1, 2), 1));
        animationQueue.Enqueue(Fail());

        StartCoroutine(PlayAnimationQueue());
    }

    private IEnumerator PlayAnimationQueue()
    {
        while (animationQueue.Count > 0)
        {
            yield return StartCoroutine(animationQueue.Dequeue());
        }
    }

    private IEnumerator Capture()
    {
        yield return new WaitForSeconds(0.5f);

        pokeball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pokeball.GetComponent<Rigidbody>().drag = 10;

        while (true)
        {
            pokemon_GUI.transform.position = Vector3.Lerp(pokemon_GUI.transform.position, pokeball_GUI.transform.position, 0.05f);
            pokemon_GUI.transform.localScale = Vector3.Lerp(pokemon_GUI.transform.localScale, Vector3.zero, 0.05f);

            if (Vector3.Distance(pokemon_GUI.transform.position, pokeball_GUI.transform.position) <= 0.01)
            {
                Debug.Log("Finished Capture");
                break;
            }
            yield return null;
        }

        pokeball.GetComponent<Rigidbody>().drag = 0;
    }

    private IEnumerator Tick(int numberOfTicks, float animationDuration)
    {
        for (int i = 0; i < numberOfTicks; i++)
        {
            // play tick animation here
            Debug.Log("Tick " + i);
            yield return new WaitForSeconds(animationDuration);
        }
    }

    private IEnumerator Success(float animaitonDuration)
    {
        // play animation
        yield return new WaitForSeconds(animaitonDuration);
        Debug.Log("Catch SUCCESSSSSSSSSS");
    }
    private IEnumerator Fail()
    {
        // play animation

        while (true)
        {
            pokemon_GUI.transform.position = Vector3.Lerp(pokemon_GUI.transform.position, pokemon.GetComponent<PokemonLogic>().GUI_pos, 0.05f);
            pokemon_GUI.transform.localScale = Vector3.Lerp(pokemon_GUI.transform.localScale, Vector3.one, 0.05f);

            if (Vector3.Distance(pokemon_GUI.transform.position, pokemon.GetComponent<PokemonLogic>().GUI_pos) <= 0.01)
            {
                Debug.Log("Finished Escape");
                pokemon_GUI.transform.position = pokemon.GetComponent<PokemonLogic>().GUI_pos;
                pokemon_GUI.transform.localScale = Vector3.one;
                break;
            }
            yield return null;
        }
    }

}
