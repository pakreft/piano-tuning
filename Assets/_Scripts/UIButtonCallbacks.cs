using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonCallbacks : MonoBehaviour
{
    public static UIButtonCallbacks I { get; set; }

    
    private void Awake()
    {
        if (I != null)
        {
            Destroy(this);
            return;
        }
        
        I = this;
        Debug.Log("UIButtonCallbacks initialized", this);
    }
    
    // ----- Main Menu Buttons -----
    public void OnTrainingModeBtn()
    {
        Loader.I.LoadTrainingMode();
    }

    public void OnDemoModeBtn()
    {
        Loader.I.LoadDemoMode();
    }
    
    public void OnExitBtn()
    {
        Application.Quit();
    }
    
    // ----- In-Game Buttons -----
    public void OnInGameMenuBtn()
    {
        bool s = !UIManager.I.inGameMenuUI.activeSelf;
        UIManager.I.inGameMenuUI.SetActive(s);
    }
    
    public void OnShowHintBtn()
    { 
        if (TaskManager.I.hintUsed == false)
        {
            //TODO: Sound
            TaskManager.I.hintCounter++;
            UIManager.I.SetHintCounter(TaskManager.I.hintCounter);
            TaskManager.I.hintUsed = true;
        }
        
        UIManager.I.SetInfoText(TaskManager.I.CurrentTask.hintMsg);
        UIManager.I.backToInstructionMsgBtn.gameObject.SetActive(true);
    }
    
    public void OnBackToInstructionMsgBtn()
    {
        //TODO: little sound
        UIManager.I.SetInfoText(TaskManager.I.CurrentTask.instructionsMsg);
        UIManager.I.backToInstructionMsgBtn.gameObject.SetActive(false);
    }
    
    public void OnRestartBtn()
    {
        Debug.Log("restart");
        Loader.I = null;
        TaskManager.I = null;
        I = null;
        UIManager.I = null;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.sceneLoaded += Loader.I.OnSceneLoaded;
    }

    public void OnBackToMainMenuBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // ----- Demo Mode Specific Buttons -----
    public void OnStepForwardBtn()
    {
        UIManager.I.stepBackwardBtn.gameObject.SetActive(true);
        TaskManager.I.TaskCompleted();
    }

    public void OnStepBackwardsBtn()
    {
        TaskManager.I.index--;
        
        if (TaskManager.I.index == 0)
            UIManager.I.stepBackwardBtn.gameObject.SetActive(false);
        else
            UIManager.I.stepBackwardBtn.gameObject.SetActive(true);

        TaskManager.I.CurrentTask = TaskManager.I.tasks[TaskManager.I.index];
        TaskManager.I.SetupCurrentTask();
    }
}