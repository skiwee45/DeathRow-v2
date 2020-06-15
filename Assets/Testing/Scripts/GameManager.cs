using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels = new GameObject[7];
    private int currentNumber;
    private GameObject currentLevel;
    public PanelFader fader;
    public Transform player;
    public Transform resetPlayerDestination;
    public AstarPath pathfinder;
    public int score;
    public Text records;
    private bool levelsDone;

    private void Start()
    {
        currentNumber = 0;
        currentLevel = Instantiate(levels[currentNumber]);
        pathfinder.Scan();
        score = 0;
        levelsDone = false;
    }
    public void loadNextLevel() //when next level must be loaded
    {
        Debug.Log("NextLevel");
        //count evidences
        addScore();
        if (!levelsDone)
        {
            //delete current from game
            Destroy(currentLevel);
            //black screen in and out
            StartCoroutine(fadeINOUT());
        } else
        {
            bossLoad();
            Debug.Log("Boss Level");
        }
        
    }
    private IEnumerator fadeINOUT()
    {
        fader.FadeIn();
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);
        fader.FadeOut();
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);
        //pick random next
        CreateNextLevel();
        //re-scan map for enemies
        pathfinder.Scan();
        //reset player
        player.position = resetPlayerDestination.position;
    }

    private void CreateNextLevel()
    {
        currentNumber = Random.Range(1, 7);
        currentLevel = Instantiate(levels[currentNumber]);
    }

    private void addScore()
    {
        if (levelsDone == false)
        {
            score++;
            records.text = "" + score;
            if (score == 4)
            {
                levelsDone = true;
            }
        }
    }

    private void bossLoad()
    {
        Debug.Log("boss loaded");
    }
}
