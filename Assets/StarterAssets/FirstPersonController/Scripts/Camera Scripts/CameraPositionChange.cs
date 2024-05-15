using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChange : MonoBehaviour
{
    // Start is called before the first frame update

    private int changeCount = 0;
    public GameObject Camera;

    public void OnTriggerEnter(Collider collider)
    {
        

        if (collider != null && changeCount < 1)
        {
            Camera.transform.position = new Vector3(12.54f, 9.6f, -14.22f);
            Camera.transform.rotation = Quaternion.Euler(30f, -55, 0);
            changeCount++;
        }
    }
}
