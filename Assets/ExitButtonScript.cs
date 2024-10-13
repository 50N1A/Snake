using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public string Scene; // ��� �����, ������� ����� ���������

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