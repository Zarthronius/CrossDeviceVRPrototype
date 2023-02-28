using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ubiq.Messaging;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class NetworkRenderToggle : MonoBehaviour
{
    NetworkContext context;
    public Renderer r;
    
    //public Toggle renderToggle;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        context = NetworkScene.Register(this);
        //NetworkId networkIdSquare = new NetworkId(1001); //
        //context = new NetworkContext(); //
    }

    bool lastRendered;
    
    // Update is called once per frame
    void Update()
    {
        if (lastRendered != r.enabled)
        {
            lastRendered = r.enabled;
            Debug.Log(lastRendered);

            context.SendJson(new Message()
            {
                isRendered = lastRendered
            });
        }
    }

    /*public void IsVisible()
    {
        r.enabled = !r.enabled;
        //visible = r.enabled;
        Debug.Log(visible);

        context.SendJson(new Message()
        {
            isRendered = r.enabled
        });
        //Debug.Log("visible value sent: "+visible);
    }*/

    private struct Message
    {
        public bool isRendered;
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        var m = message.FromJson<Message>();
        r.enabled = m.isRendered;
        lastRendered = r.enabled;
        Debug.Log(r.enabled);
    }
}