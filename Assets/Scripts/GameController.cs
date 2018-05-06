using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject instantiatior;

    // Use this for initialization
    void Start () {
        GameObject cameraRig = GameObject.FindGameObjectWithTag("CameraRig");

        // Deactivate drum stick models at the start of the game
        cameraRig.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        cameraRig.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
	}

    public void LockDrumPieces()
    {
        int children = instantiatior.transform.childCount;

        for(int i = 0; i < children; i++)
        {
            Rigidbody drumPieceRb = instantiatior.transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
            drumPieceRb.isKinematic = true;
        }
    }

    public void UnlockDrumPieces()
    {
        int children = instantiatior.transform.childCount;

        for (int i = 0; i < children; i++)
        {
            Rigidbody drumPieceRb = instantiatior.transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
            drumPieceRb.isKinematic = false;
        }
    }
}