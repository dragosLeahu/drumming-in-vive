using UnityEngine;

public class InstantiateDrum : MonoBehaviour {

    public Transform instPlace;

    public GameObject snare;
    public GameObject kickTomTom;
    public GameObject floorTom;
    public GameObject hiHat;
    public GameObject leftCrash;
    public GameObject ride;

    public void InstantiateDrumPiece(string name)
    {
        switch(name)
        {
            case "snare":
                GameObject snareInst = Instantiate(snare, instPlace.position, Quaternion.identity, instPlace);
                break;
            case "kicktomtom":
                GameObject kickTomTomInst = Instantiate(kickTomTom, instPlace.position, Quaternion.identity, instPlace);
                break;
            case "floortom":
                GameObject floorInst = Instantiate(floorTom, instPlace.position, Quaternion.identity, instPlace);
                floorInst.transform.localPosition = Vector3.zero;
                break;
            case "hihat":
                GameObject hiHatInst = Instantiate(hiHat, instPlace.position, Quaternion.identity, instPlace);
                hiHatInst.transform.localPosition = Vector3.zero;
                break;
            case "leftcrash":
                GameObject leftCrashInst = Instantiate(leftCrash, instPlace.position, Quaternion.identity, instPlace);
                leftCrashInst.transform.localPosition = Vector3.zero;
                break;
            case "ride":
                GameObject rideInst = Instantiate(ride, instPlace.position, Quaternion.identity, instPlace);
                rideInst.transform.localPosition = Vector3.zero;
                break;
        }
    }
}
