using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GameManager : MonoBehaviour
{

    [SerializeField] private FMODUnity.StudioEventEmitter audioEmitter;

    // Start is called before the first frame update
    void Start()
    {
        audioEmitter.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
