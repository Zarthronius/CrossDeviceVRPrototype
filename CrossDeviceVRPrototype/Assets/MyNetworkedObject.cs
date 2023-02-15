using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ubiq.XR;
using UnityEngine;
using Ubiq.Messaging;
using Ubiq.Spawning; //

public class MyNetworkedObject : MonoBehaviour, INetworkSpawnable, IGraspable
{
    public NetworkId NetworkId { get; set; }
    NetworkContext context;
    
    private Hand follow;
    
    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        context = NetworkScene.Register(this);
    }

    Vector3 lastPosition;

    // Update is called once per frame
    void Update()
    {
        
        if (follow != null)
        {
            body.isKinematic = true;
            transform.position = follow.transform.position;
            //transform.rotation = follow.transform.rotation;
            context.SendJson(new Message()
            {
                position = transform.localPosition
                //rotation = transform.localRotation
            });
            
        }
        //else
        //{
        //    body.isKinematic = false;
        // }
        
        
        if(lastPosition != transform.localPosition)
        {
            lastPosition = transform.localPosition;
            context.SendJson(new Message()
            {
                position = transform.localPosition
                //rotation = transform.localRotation
            });
        }
    }
    
    //
    
    public void Grasp(Hand controller)
    {
        follow = controller;
    }
    
    public void Release(Hand controller)
    {
        follow = null;
    }

    //
    
    
    private struct Message
    {
        public Vector3 position;
        //this.transform = new TransformMessage(transform);
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        // Parse the message
        var m = message.FromJson<Message>();

        // Use the message to update the Component
        //transform.localRotation = m.rotation;
        transform.localPosition = m.position;

        // Make sure the logic in Update doesn't trigger as a result of this message
        lastPosition = transform.localPosition;
    }
}