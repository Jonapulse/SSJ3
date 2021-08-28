using UnityEngine;
using System.Collections;

public class DialogueInfo : MonoBehaviour {

    public singleDialogue[] dialogueList;

    [System.Serializable]
    public class singleDialogue
    {
        public enum neighborID { Penny, Shae, Gabe, Ezra, radio, groupChat };
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
