using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayed : MonoBehaviour {

    private bool _isPlayed;
    private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
        _isPlayed = false;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DrumStick")
        {
            if (!_isPlayed)
            {
                PlaySnare();
            }
        }
    }

    void PlaySnare()
    {
        _audioSource.Play();
    }
}
