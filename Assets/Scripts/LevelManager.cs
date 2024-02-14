using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelObject[] levelObjects;
    public Sprite goldCoin;

    public static int currentLevel;
    public static int UnlockedLevels;

    private void Start()
    {
        UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);

        for (int i = 0; i < levelObjects.Length; i++)
        {
            if(UnlockedLevels >= i)
            {
                levelObjects[i].button.interactable = true;
                int coins = PlayerPrefs.GetInt("coins" + i.ToString(), 0);
                for(int j = 0; j < coins; j++)
                {
                    levelObjects[i].coins[j].sprite = goldCoin;
                }
            }
        }
    }

    public void OnClickLevel(int lvl)
    {
        currentLevel = lvl;
        SceneManager.LoadScene(lvl);
    }
}
