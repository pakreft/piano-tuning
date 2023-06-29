using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _inGameUI;

    private void Start()
    {
        GameManager.OnGameStart += () => { ActivatePanel(_mainMenu); };
    }

    private void ActivatePanel(GameObject panel) => panel.SetActive(true);
    private void DeactivatePanel(GameObject panel) => panel.SetActive(false);
}
