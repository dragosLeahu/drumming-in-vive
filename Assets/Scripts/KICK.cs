using UnityEngine;

public class KICK : MonoBehaviour
{
    private GameObject _controllerLeft;
    private AudioSource _audioSource;
    private SteamVR_TrackedController _controller;
    
    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    private void OnEnable()
    {
        _controllerLeft = GameObject.FindGameObjectWithTag("CameraRig").transform.GetChild(0).gameObject;

        _controller = _controllerLeft.GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += HandleTriggerClicked;
    }

    private void OnDisable()
    {
        _controller.TriggerClicked -= HandleTriggerClicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        // Check if the Drum Stick is active
        if(_controllerLeft.transform.GetChild(0).gameObject.activeSelf == true)
        {
            PlayDumSound();
        }
    }

    private void PlayDumSound()
    {
        _audioSource.Play();
    }
}
