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
        //Get render component
        r = GetComponent<Renderer>();
        //Register object
        context = NetworkScene.Register(this);
    }

    //flag
    bool lastRendered;

    // Update is called once per frame
    void Update()
    {
        // if flag isn't new status
        if (lastRendered != r.enabled)
        {
            //update flag
            lastRendered = r.enabled;

            //send message of new status
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
        // parse message
        var m = message.FromJson<Message>();
        
        //renderer status changed to message value
        r.enabled = m.isRendered;
        //bool flag changed to render status
        lastRendered = r.enabled;
        Debug.Log(r.enabled);
    }
}