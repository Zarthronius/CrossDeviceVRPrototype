using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ubiq.Rooms;
//using UnityEditor.PackageManager;
using System.Threading.Tasks;

namespace Ubiq.Samples
{
    public class myNewRoomButton : MonoBehaviour
    {
        public SocialMenu mainMenu;
        public Text nameText;
        public bool publish;

        // Expected to be called by a UI element
        public async void NewRoom()
        {
            await createRoom();
            Debug.Log(mainMenu.roomClient.Room.JoinCode);
        }

        async Task createRoom()
        {
            await Task.Run(() =>
            {
                mainMenu.roomClient.Join(
                    name: nameText.text,
                    publish: publish);
            });
        }
    }
}