using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ubiq.Messaging;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class NetworkRenderToggleMultiple : MonoBehaviour
{
    NetworkContext context;
    private bool startStatus;
    
    //public Toggle renderToggle;

    // Start is called before the first frame update
    void Start()
    {
        startStatus = false;
        //Renderers[] renderers = GetComponentsInChildren<Renderers>();
        context = NetworkScene.Register(this);
        lastRendered = startStatus;
    }

    //flag
    private bool lastRendered;
    
    //toggle render status
    public void toggleLastRendered()
    {
        // change render status
        this.lastRendered = !this.lastRendered;

        // send message to other objects of new status
        context.SendJson(new Message()
        {
            isRendered = lastRendered
        });
        
    }
    
    //set specific render status
    public void setLastRendered(bool state)
    {
        // change render status
        //this.lastRendered = !this.lastRendered;

        this.lastRendered = state;
        // send message to other objects of new status

        
        context.SendJson(new Message()
        {
            isRendered = state
        });
    }

    // Update is called once per frame
    private void Update()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (renderers.Length > 0)
        {
            foreach (Renderer childRenderer in renderers)
            {
                // If a renderer component is found
                try
                {
                    if (childRenderer.enabled != lastRendered)
                    {
                        childRenderer.enabled = lastRendered;
                    }
                }
                catch
                {
                    Debug.LogWarning(
                        "No renderer component found for " + GetComponent<Renderer>().gameObject.name + ".");
                }
            }

        }
    }

    private struct Message
    {
        public bool isRendered;
    }

    public void ProcessMessage(ReferenceCountedSceneGraphMessage message)
    {
        var m = message.FromJson<Message>();
        lastRendered = m.isRendered;

        // Update the renderer status of all child objects that have a renderer component
        foreach (Renderer childRenderer in GetComponentsInChildren<Renderer>())
        {
            try
            {
                if (childRenderer != lastRendered)
                {
                    childRenderer.enabled = lastRendered;
                }
            }
            catch
            {
                Debug.LogWarning("No renderer component found for " + GetComponent<Renderer>().gameObject.name + ".");
            }
        }

        //Debug.Log(r.enabled);
    }
}