using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ubiq.Messaging;

public class NetworkRenderToggle : MonoBehaviour
{
    NetworkContext context;
    public Renderer r;
    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        context = NetworkScene.Register(this);
    }

    bool visible;
    
    // Update is called once per frame
    void Update()
    {
        visible = r.enabled;
        Debug.Log(visible);
        
        context.SendJson(new Message()
        {
            isRendered = visible
        });
    }

    private struct Message
    {
        public bool isRendered;
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        var m = message.FromJson<Message>();
        r.enabled = m.isRendered;
    }
}
