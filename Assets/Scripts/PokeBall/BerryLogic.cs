using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryLogic : MonoBehaviour
{
    [SerializeField] private GameObject Pokemon;
    [SerializeField] private float lerpSpeed;

    private void Awake()
    {
        Pokemon = GameObject.FindGameObjectWithTag("Pokemon");
        Debug.Log("Spwned Berry");
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Pokemon.transform.position, Time.deltaTime * lerpSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * lerpSpeed);

        if (transform.position.z >= Pokemon.transform.position.z*0.8f)
        {
            Pokemon.GetComponent<PokemonLogic>().BerryEffect = BerryTypes.NanabBerry;
            Destroy(gameObject);
        }
    }
}
