using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public BoxSpawner box_Spawner;

    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    public Text scoreText;
    public int currentScore = 0;


    private void Awake()
    {
        if (instance == null)//????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 2f);
    }

    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;

        if (moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }

        currentScore++;
        scoreText.text = currentScore.ToString();


    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
