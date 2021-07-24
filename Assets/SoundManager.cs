using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audio;

    public static SoundManager instance;
    private void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }   
    }
    public void FireWork()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
