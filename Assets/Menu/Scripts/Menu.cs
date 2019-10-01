/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.SceneManagement;

//Функционал меню
public class Menu : MonoBehaviour
{
    [SerializeField] private LoadingManager _loadingManager;

    //Перезагружает активный уровень
    public void RestartLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    //Загрузить уровень по имени
    public void LoadLevelByName(string sceneName)
    {
        if (_loadingManager != null)
        {
            _loadingManager.loadingWindow.SetActive(true);
            _loadingManager.async = SceneManager.LoadSceneAsync(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }

        gameObject.SetActive(false);
    }

    //Загрузить уровень по имени
    public void LoadLevelByIndex(int sceneIndex)
    {
        if (_loadingManager != null)
        {
            _loadingManager.loadingWindow.SetActive(true);
            _loadingManager.async = SceneManager.LoadSceneAsync(sceneIndex);
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }

        gameObject.SetActive(false);
    }

    //Показать объект
    public void Show(GameObject target)
    {
        target.SetActive(true);
    }

    //Скрыть объект
    public void Hide(GameObject target)
    {
        target.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }
}
