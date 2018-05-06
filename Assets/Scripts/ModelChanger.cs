using UnityEngine;

/// <summary>
/// Script used to change from DrumStick to Vive Controller model
/// </summary>
public class ModelChanger : MonoBehaviour {
    private SteamVR_TrackedController _controller;
    private Transform _drumStickModel;
    private Transform _viveControllerModel;
    private GameObject[] _laserPointers;


    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.PadClicked += HandlePadClicked;
    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        // Change controller model on pad up press
        if (e.padY > 0)
        {
            ChangeControllerModel();
        }
    }

    private void OnDisable()
    {
        _controller.PadClicked -= HandlePadClicked;
    }

    private void Start()
    {
        _laserPointers = GameObject.FindGameObjectsWithTag("Laser");

        _drumStickModel = gameObject.transform.GetChild(0);
        _viveControllerModel = gameObject.transform.GetChild(1);

        _drumStickModel.gameObject.SetActive(false);
    }

    void ChangeControllerModel()
    {
        if(_drumStickModel.gameObject.activeSelf == true)
        {
            _drumStickModel.gameObject.SetActive(false);
            _viveControllerModel.gameObject.SetActive(true);

            EnableLaserPointer();
        }
        else
        {
            _viveControllerModel.gameObject.SetActive(false);
            _drumStickModel.gameObject.SetActive(true);

            StopLaserPointer();
        }
    }

    void StopLaserPointer()
    {
        for(int i = 0; i < _laserPointers.Length; i++)
        {
            _laserPointers[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void EnableLaserPointer()
    {
        for (int i = 0; i < _laserPointers.Length; i++)
        {
            _laserPointers[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
