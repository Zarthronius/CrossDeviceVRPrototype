//CODE ADAPTED FROM RoomClient.cs
/*
using System;
using System.Collections.Generic;
using System.Linq;
using Ubiq.Dictionaries;
using Ubiq.Messaging;
using Ubiq.Networking;
using Ubiq.Rooms.Messages;
using Ubiq.XR.Notifications;
using UnityEngine;

namespace Ubiq.Rooms
{
    public class RoomClientTest : MonoBehaviour
    {
        private Dictionary<string, Action<string>> blobCallbacks = new Dictionary<string, Action<string>>();
        private List<Action> actions = new List<Action>();
        
        public void Join(string name, bool publish)
        {
            actions.Add(() =>
            {
                SendToServerSync("Join", new JoinArgs()
                {
                    name = name,
                    publish = publish,
                    peer = me.GetPeerInfo()
                });
                me.log.Clear(); // Already sent server up-to-date properties
            });
        }

        public void Join(string joincode)
        {
            actions.Add(() =>
            {
                SendToServerSync("Join", new JoinArgs()
                {
                    joincode = joincode,
                    peer = me.GetPeerInfo()
                });
                me.log.Clear(); // Already sent server up-to-date properties
            });
        }

        public void CreateRoom(string name, bool publish)
        {
            Join(name, publish);
        }
    }
}*/