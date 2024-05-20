using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("Manager")]
    [SerializeField] private float timeBeforeLoad = 0.2f;

    [Header("Scenes")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settings;

    //Singleton.
    private AudioManager _audioManager;

    #endregion

    #region Built-In Methods

    private void Start()
    {
        //Singleton.
        _audioManager = AudioManager.Instance;
    }

    #endregion

    #region Menu Manager

    /**
     * <summary>
     * Button play load the waiting room.
     * </summary>
     */
    public void LoadWaitingRoom()
    {
        StartCoroutine(DelayWaitingRoom());
    }

    private IEnumerator DelayWaitingRoom()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        mainMenu.SetActive(false);
    }

    /**
     * <summary>
     * Button settings load settings scene.
     * </summary>
     */
    public void LoadSettings()
    {
        StartCoroutine(DelaySettings());
    }

    private IEnumerator DelaySettings()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        mainMenu.SetActive(false);
        settings.SetActive(true);
        _audioManager.GlitchSFX.Stop();
    }

    /**
     * <summary>
     * Exit the game.
     * </summary>
     */
    public void ExitGame()
    {
        StartCoroutine(DelayExitGame());
    }

    private IEnumerator DelayExitGame()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        Application.Quit();
    }

    #endregion
}