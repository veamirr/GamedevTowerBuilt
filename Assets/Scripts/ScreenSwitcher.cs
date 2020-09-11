using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public void playGame()//из стартового меню в игру
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//к текущему адресы сцены +1, и загружаем следующую сцену
    }
    public void pauseGame()//остановить игру
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void resumeGame()//продолжить игру
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void openGame()//вернуться в стартовое меню
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
