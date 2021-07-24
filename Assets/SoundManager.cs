using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    [System.Serializable]
    public struct audioclip
    {
        public string Name;
        public AudioClip[] audio;
    }

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
