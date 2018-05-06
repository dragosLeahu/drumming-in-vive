using UnityEngine;

public class ObjectPickup : MonoBehaviour {

    [SerializeField] private GameObject obj;

    private SteamVR_TrackedController _controller;
    private FixedJoint _fJoint;

    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += HandleTriggerClicked;
        _controller.TriggerUnclicked += HandleTriggerUnclicked;
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        PickUpObj();
    }

    private void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        DropObj();
    }

    private void OnDisable()
    {
        _controller.TriggerClicked -= HandleTriggerClicked;
        _controller.TriggerUnclicked -= HandleTriggerUnclicked;
    }

    // Use this for initialization
    void Start () {
        _fJoint = GetComponent<FixedJoint>();
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Pickupable"))
        {
            obj = other.gameObject;
        }
    }

    void PickUpObj()
    {
        if(obj != null)
        {
            _fJoint.connectedBody = obj.GetComponent<Rigidbody>();
        } else
        {
            _fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        if(_fJoint.connectedBody != null)
        {
            _fJoint.connectedBody = null;
        }
    }
}
