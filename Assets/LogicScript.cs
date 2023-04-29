using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerScore;
    public Text scoreText;
    public Text walletText;
    public GameObject gameOverScreen;
    public GameObject spriteShopScreen;
    public GameObject titleScreen;
    public GameObject player;
    public GameObject pipeSpawner;
    public GameObject boutonSpriteShop;
    public PlayerStats playerStats;
    public float v0;
    public float q;
    public int playerHadBonus;
    public int scoreWhenBonus;
    public int maxBonusPipeNum;

    public float Vitesse()
    {            
        int n = (int)((playerScore - scoreWhenBonus) / 10);
        float v = v0 * Mathf.Pow(q, n);
        if (gameOverScreen.activeSelf)
        {
            return v0/2;
        }
        return v;  
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString() + "/" + playerStats.highscore.ToString();
    }


    public void SavePlayerStats()
    {
        string playerStatsJson = JsonUtility.ToJson(playerStats);
        string path = Application.persistentDataPath + "/flappybird_playerStats.json";
        System.IO.File.WriteAllText(path, playerStatsJson);
        Debug.Log("Successfuly Saved at : " + path);
    }
    public void LoadPlayerStats()
    {
        string path = Application.persistentDataPath + "/flappybird_playerStats.json";
        string playerStatsJson = System.IO.File.ReadAllText(path);
        playerStats = JsonUtility.FromJson<PlayerStats>(playerStatsJson);
        Debug.Log("Successfuly Load from : " + path);
    }


    //======== CAPITALISM ===========//

    public void addCoin(int coinValue)
    {
        playerStats.wallet += coinValue;
        
    }

    public void SetPlayerSprite(Item item)
    {
        if (playerStats.spriteBought.Contains(item.spriteImage))
        { 
            playerStats.currentSprite = item.spriteImage;
            Debug.Log("The sprite has changed !");
            SavePlayerStats();
        }
        else
        {
            if (playerStats.wallet >= item.price)
            {
                playerStats.wallet -= item.price;
                playerStats.spriteBought.Add(item.spriteImage);
                playerStats.currentSprite = item.spriteImage;
                Debug.Log("New sprite bought !");
                SavePlayerStats();
            } 
        } 
    }


    public void spriteShop() 
    {
        if (!spriteShopScreen.activeSelf)
        {
            player.SetActive(false);
            pipeSpawner.SetActive(false);
            titleScreen.SetActive(false);
            spriteShopScreen.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }




    //======== GAME OVER ===========//
    public void startGame()
    {
        player.SetActive(true);
        Debug.Log("DEBUG player setActive");
        titleScreen.SetActive(false);
        pipeSpawner.SetActive(true);
    }

    public void restartGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (playerStats.highscore < playerScore) playerStats.highscore = playerScore;
        SavePlayerStats();
        player.SetActive(false);
        boutonSpriteShop.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }
        walletText.text = "$" + playerStats.wallet.ToString();
    }

    private void Start()
    {
        LoadPlayerStats();
        scoreText.text = playerScore.ToString() + "/" + playerStats.highscore.ToString();
        SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        if (playerStats.currentSprite == null)
        {
            playerStats.currentSprite = playerSpriteRenderer.sprite;
            playerStats.spriteBought.Add(playerStats.currentSprite);
            Debug.Log("DEBUG current sprite == null");
        }
        else
        {
            playerSpriteRenderer.sprite = playerStats.currentSprite;
            Debug.Log("DEBUG on a bien transmis le current sprite");
        }
    }
}







[System.Serializable]
public class PlayerStats
{
    public int wallet;
    public int highscore;
    public List<Sprite> spriteBought = new List<Sprite>();
    public Sprite currentSprite;
}

