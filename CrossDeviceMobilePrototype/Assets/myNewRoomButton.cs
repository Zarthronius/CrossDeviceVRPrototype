//TODO: Joincode is being taken BEFORE room is initialised. ONLY take join code AFTER initialisation.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ubiq.Rooms;
using UnityEditor.PackageManager;
using System.Threading.Tasks;

namespace Ubiq.Samples
{
    public class myNewRoomButton : MonoBehaviour
    {
        public SocialMenu mainMenu;
        public Text nameText;
        public bool publish;
        //public string joinCode;
		
		public Text Joincode;

        // Expected to be called by a UI element
        public async void NewRoom()
        {
            await createRoom();
            //joinCode = mainMenu.roomClient.Room.JoinCode;
            //Debug.Log("Shouldn't be first");
            //Debug.Log("joinCode2: " + joinCode);
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
            //while (mainMenu.roomClient.Room.JoinCode == null)
            //{
            //    Debug.Log("here");
           // }
            Debug.Log(mainMenu.roomClient.Room.JoinCode);
            //Debug.Log("should be first");
        }
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ubiq.Rooms;
using UnityEditor.PackageManager;

//
using System.Threading.Tasks;

namespace Ubiq.Samples
{
    public class NewRoomButton : MonoBehaviour
    {
        public SocialMenu mainMenu;
        public Text nameText;
        public bool publish;
        public string joinCode;

        // Expected to be called by a UI element
        public async void NewRoom()
        {
            await Task.Run(() => createRoom());
            joinCode = mainMenu.roomClient.Room.JoinCode;
            Debug.Log("joinCode: " + joinCode);

        }

        void createRoom()
        {
            mainMenu.roomClient.Join(
                name: nameText.text,
                publish: publish);
        }
    }
}*/