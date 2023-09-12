using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    public GameObject hasil;
    public GameObject rewards;

    public AudioClip audioClip; // Reference to the audio clip you want to play
    private AudioSource audioSource;

       void Start()
    {

        // Add an AudioSource component to the GameObject if it doesn't exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource
        audioSource.clip = audioClip;
    }

    public void IncrementScore()
    {
        score++;
    }
    // Update is called once per frame
    void Update()
    {

        if (score == 13)
        {
            hasil.SetActive(true);
            audioSource.Play();
        }
    }

    public void GetReward()
    {
        Destroy(hasil);
        rewards.SetActive(true);
    }
}
