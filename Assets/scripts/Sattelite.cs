using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sattelite : MonoBehaviour {

    private bool _isUsed;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "command" && !_isUsed && !InfoGodControl.instance.isMouseDrag)
        {
            other.transform.parent = transform;
            other.transform.localPosition = new Vector3(0, 0.55f, 0);
            //transform.parent.GetComponent<CmdStorageBehaviour>().addCommand(new Command(other.GetComponent<CommandObj>().symbol, 10));
            transform.parent.GetComponent<CmdStorageBehaviour>().addCommand(other.GetComponent<CommandObj>());
            //other.GetComponent<CommandObj>().setInLine(false);
            other.GetComponent<Rigidbody>().isKinematic = true;
            _isUsed = true;
        }
    }

    public bool isUsed
    {
        get
        {
            return _isUsed;
        }
        set
        {
            _isUsed = value;
        }
    }
}
