using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public string Scene; // Имя сцены, которую нужно загрузить

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(DoGameExit);
    }

    void DoGameExit()
    {
        Application.Quit();
    }
}