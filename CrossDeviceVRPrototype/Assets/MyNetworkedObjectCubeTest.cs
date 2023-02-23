using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ubiq.XR;
using UnityEngine;
using Ubiq.Messaging;
using Ubiq.Spawning; //

public class MyNetworkedObjectCubeTest : MonoBehaviour, INetworkSpawnable, IGraspable//, INetworkObject, INetworkComponent
{
    public NetworkId NetworkId { get; set; }
    private NetworkContext context;

    //NetworkId this.Id = new NetworkId(1001);
    private Hand follow;
    
    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //NetworkId networkId = NetworkId.Unique(); //
        NetworkId networkId = new NetworkId(1001); //sets fixed network id for object
        context = NetworkScene.Register(this, networkId);
        
        //context = NetworkScene.Register(this);
        //context = NetworkScene.Register(networkId);
        Debug.Log("Object NetworkID TEST: "+networkId); //
        //context = NetworkScene.Register(this, NetworkId)
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
                //position = transform.localPosition
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
                //position = transform.localPosition
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
        //public Vector3 position;
        //this.transform = new TransformMessage(transform);
        public bool messageToggleStatus;
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        // Parse the message
        var m = message.FromJson<Message>();

        // Use the message to update the Component
        //transform.localRotation = m.rotation;
        //transform.localPosition = m.position;
        gameObject.SetActive(m.messageToggleStatus);

        // Make sure the logic in Update doesn't trigger as a result of this message
        //lastPosition = transform.localPosition;
    }
}