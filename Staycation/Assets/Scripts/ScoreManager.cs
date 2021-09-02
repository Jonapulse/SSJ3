using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;
    public int matchBonus = 7;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void RecalculateScore()
    {
        List<DraggableItem> collection = GameStateManager.Instance.gridManager.GetCollection();

        List<int> catList = new List<int>();
        List<int> plantList = new List<int>();
        List<int> relicList = new List<int>();

        foreach(DraggableItem item in collection)
        {
            List<int> checkList = null;
            switch (item.type)
            {
                case (DraggableItem.collection_type.Cats):
                    checkList = catList;
                    break;
                case (DraggableItem.collection_type.Plants):
                    checkList = plantList;
                    break;
                case (DraggableItem.collection_type.Relics):
                    checkList = relicList;
                    break;
            }

            if (!checkList.Contains(item.ID))
                checkList.Add(item.ID);
        }

        int catCount = catList.Count;
        int catPoints = (int)Mathf.Pow(catCount, 2);
        int plantCount = plantList.Count;
        int plantPoints = (int)Mathf.Pow(plantCount, 2);
        int relicCount = relicList.Count;
        int relicPoints = (int)Mathf.Pow(relicCount, 2);

        int matchCount = Mathf.Min(new int[] { catList.Count, plantList.Count, relicList.Count });
        int matchPoints = matchCount * matchBonus;

        int totalScore = catPoints + plantPoints + relicPoints + matchPoints;
        score = totalScore;
        scoreText.text = "Reggie Rating: " + totalScore + "\n<size=60%>" + catCount + " cats for " + catPoints + "points\n" + plantCount + " plants for " + plantPoints + "points\n" + relicCount + " priceless artifacts for " + relicPoints + "points\n" + matchCount + " set" + (matchCount != 1 ? "s" : "") + " from each for " + matchPoints + " points</size>";
    }

    public int GetScore()
    {
        return score;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            RecalculateScore();

    }
}
