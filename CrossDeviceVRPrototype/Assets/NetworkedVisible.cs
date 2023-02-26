/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ubiq.XR;
using UnityEngine;
using Ubiq.Messaging;
using Ubiq.Samples.Bots.Messaging;
using Ubiq.Spawning; //


public class NetworkedVisible : MonoBehaviour, INetworkSpawnable
{
    public NetworkId NetworkId { get; set; }
    private NetworkContext context;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        context = NetworkScene.Register(this, NetworkId);
    }

    bool toggled; 
    
    // Update is called once per frame
    void Update()
    {
        test = GetComponent<MeshRenderer>();
        bool enabled = test.enabled;
        if (toggled != false)
        {
            ContextMenu.sendJson(new Message(bool enabled)
            {
                enabled = status.enabled
            })
            toggled = false;
        }
    }

    private struct Message
    {
        public bool isEnabled;
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        var m = message.fromJson<Message>();
        r = GetComponent<Renderer>();
        r.enabled = m.isEnabled;
    }
}
*/