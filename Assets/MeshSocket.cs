using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{
    public GameObject HandSocket;
    public MeshSockets.SocketId socketId;
    Transform attachPoint;
    // Start is called before the first frame update
    void Start()
    {
        attachPoint = HandSocket.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attach(Transform objectTransform)
    {
        objectTransform.SetParent(attachPoint, false);
    }
}
