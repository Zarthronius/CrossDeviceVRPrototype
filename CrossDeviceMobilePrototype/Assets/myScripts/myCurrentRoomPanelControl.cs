using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ubiq.Rooms;
using UnityEngine;
using UnityEngine.UI;
//using Ubiq.Rooms;

namespace Ubiq.Samples
{
    public class myCurrentRoomPanelControl : MonoBehaviour
    {
        public Text Joincode;
        public SocialMenu mainMenu;
        private string existing;

        public void Bind(RoomClient client)
        {
            Joincode.text = client.Room.JoinCode.ToUpperInvariant();
        }

        public void Bind(/*SocialMenu mainMenu*/)
        {
            Joincode.text = mainMenu.roomClient.Room.JoinCode.ToUpperInvariant();
        } 
    }
}