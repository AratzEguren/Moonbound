using UnityEngine;

public class MusicLevel2 : MonoBehaviour
{
    public AudioSource audioLevel2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(audioLevel2 == null)
        {
            audioLevel2 = GetComponent<AudioSource>();
        }
        audioLevel2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
