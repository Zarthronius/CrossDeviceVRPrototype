/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ubiq.Messaging;

public class MyNetworkedObjectButtonTest : MonoBehaviour
{
    private NetworkContext context;
    public bool toggleStatus;
    



    // Start is called before the first frame update
    void Start()
    {
        NetworkId networkIdSquare = new NetworkId(1001); //
        NetworkContext networkContextSquare = new NetworkContext(); //
        context = NetworkScene.Register(this);
        toggleStatus = false;
        networkContextSquare.Id = networkIdSquare; //
    }
    
    private struct Message
    {
        //public Vector3 position;
        public bool messageToggleStatus;
    }

    void toggleActive()
    {
        toggleStatus = !toggleStatus;
    }

    public void test()
    {
        toggleActive();
        Debug.Log("ts: " + toggleStatus);
        //Debug.Log("mts: "+Message.messageToggleStatus);
        /*context.SendJson(new Message()
        {
            //messageToggleStatus = toggleBoolStatus
            messageToggleStatus = true
        });
        Message m = new Message()
        {
            messageToggleStatus = toggleStatus
        };
        networkContextSquare.SendJson(m);
    }
}*/