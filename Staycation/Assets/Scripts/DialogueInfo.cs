using UnityEngine;
using System.Collections;

public class DialogueInfo : MonoBehaviour {

    public singleDialogue[] dialogueList;

    [System.Serializable]
    public class singleDialogue
    {
        public string name;
        public enum neighborID { Penny, Shae, Gabe, Ezra, radio, groupChat, player };
        public neighborID chatOwner;
        public int chatOrder;
        public chatInformation[] dialogue;

        [System.Serializable]
        public class chatInformation
        {
            public neighborID whoIsSpeaking;
            public string whatIsSaid;
        }
    }
    

	
}
