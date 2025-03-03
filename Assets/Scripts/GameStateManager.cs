using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameManager gameManager;
    public enum GameState
    {
        Menu_State,
        Game_State,
        Pause_State,
        Options_State
    }
    public GameState currentState { get; private set; }

    [SerializeField] public string currentStateDebug { get; private set; }
    [SerializeField] public string lastStateDebug { get; private set; }
    private void Start()
    {
        ChangeState(GameState.Menu_State);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Game_State)
        {
            ChangeState(GameState.Pause_State);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && currentState == GameState.Pause_State)
        {
            ChangeState(GameState.Game_State);
        }
    }
    public void ChangeState(GameState newstate)
    {
        lastStateDebug = currentState.ToString();
        currentState = newstate;
        HandleStateChange(newstate);
        currentStateDebug = currentState.ToString();
    }
    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Menu_State:
                gameManager.uiManager.EnableMenuUI();
                Time.timeScale = 0.0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case GameState.Game_State:
                gameManager.uiManager.gameUI.SetActive(true);
                gameManager.uiManager.DisableAllUI();
                Time.timeScale = 1.0f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case GameState.Pause_State:
                gameManager.uiManager.EnablePauseUI();
                Time.timeScale = 0.0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case GameState.Options_State:
                gameManager.uiManager.EnableOptionsUI();
                Time.timeScale = 0.0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
        }
    }
}
