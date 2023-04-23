using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ubiq.Rooms;
using UnityEngine;
using UnityEngine.UI;

//Script to update menu with new join code on room creation

namespace Ubiq.Samples
{
    public class JoinCodeUpdater : MonoBehaviour
    {
        public Text joinCodeMenu;
        public SocialMenu mainMenu;

        //Update menu join code
        public void UpdateJoinCodeMenu()
        {
            StartCoroutine(UpdateJoinCodeMenuDelayed());
        }

        // coroutine used to perform function after delay
        private IEnumerator UpdateJoinCodeMenuDelayed()
        {
            // wait for 0.1 seconds for object to initialise
            // Note: not ideal solution. Ideal solution would use listener
            yield return new WaitForSeconds(0.1f);
            
            // Gets generated joincode from roomClient object
            string joincode = mainMenu.roomClient.Room.JoinCode;
            
            // formats to uppercase and updats UI
            string joincodeUpper = joincode.ToUpper();
            joinCodeMenu.text = "Join Code: "+joincodeUpper;
        }
    }
}