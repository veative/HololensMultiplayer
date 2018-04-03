using UnityEngine;
using UnityEngine.Networking;
using HoloToolkit.Unity.InputModule;

public class CubeController : NetworkBehaviour, IInputClickHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (isLocalPlayer)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 100.0f, Physics.DefaultRaycastLayers))
            {
                // If the Raycast has succeeded and hit a hologram
                // hitInfo's point represents the position being gazed at
                // hitInfo's collider GameObject represents the hologram being gazed at
                Debug.Log("-------------" + eventData.selectedObject.name);
                if (hitInfo.transform.tag == "SharedCube")
                {
                    Debug.Log("------- Hit----------");
                    CmdFire();
                }
            }
        }
    }
    [Command]
    void CmdFire()
    {
        GameObject cubObj = GameObject.FindGameObjectWithTag("SharedCube");
        cubObj.transform.Rotate(0, 45, 0);
    }
}
