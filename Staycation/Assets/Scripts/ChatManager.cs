using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ChatManager : MonoBehaviour
{
    /// <summary>
    /// Sets up the background bubbles automatically
    /// Clicking will bring the next message or complete a typing message
    /// Ends with a button for Trade
    /// Also handle portraits (though you can skip them if no portrait, like radio or if portraits are late.)
    /// </summary>

    public Transform phoneChatSpawn;
    public Transform apartmentChatSpawn;
    public GameObject phoneLinePrefab;
    public GameObject apartmentLinePrefab;
    public int youSpeakingNudge = 75;
    public int textBoxSeparation = 50;
    public float newChatSpeed = 0.25f;

    public void StartChat(DialogueInfo.singleDialogue.neighborID partnerID, int chatNumber, bool isPhone)
    {
        //TODO: setup portrait

        StartCoroutine(RunChat(GameStateManager.Instance.dialogueInfo.GetDialogue(partnerID, chatNumber).dialogue, isPhone));
    }

    IEnumerator RunChat(DialogueInfo.singleDialogue.chatInformation[] lines, bool isPhone)
    {
        int dialogueInd = 0;
        GameObject chatAnchor = new GameObject("chat anchor");
        Transform spawn = isPhone ? phoneChatSpawn : apartmentChatSpawn;
        chatAnchor.transform.position = spawn.position;
        chatAnchor.transform.SetParent(spawn);

        while(dialogueInd < lines.Length)
        {
            GameObject newLine = GameObject.Instantiate(isPhone ? phoneLinePrefab : apartmentLinePrefab);
            TextMeshProUGUI textPro = newLine.GetComponentInChildren<TextMeshProUGUI>();
            textPro.text = lines[dialogueInd].whatIsSaid;
            newLine.transform.position = spawn.position + Vector3.right * (lines[dialogueInd].whoIsSpeaking == DialogueInfo.singleDialogue.neighborID.player ? youSpeakingNudge : 0);
            newLine.transform.SetParent(chatAnchor.transform);

            while(!Input.GetMouseButtonDown(0))
                yield return null;

            if(dialogueInd != lines.Length - 1)
                chatAnchor.transform.DOMoveY(chatAnchor.transform.position.y + textPro.renderedHeight + textBoxSeparation, newChatSpeed);

            dialogueInd++;
            yield return new WaitForSeconds(newChatSpeed);
        }
        GameStateManager.Instance.ChangeState(GameStateManager.stateType.phoneTrade);
    }
}
