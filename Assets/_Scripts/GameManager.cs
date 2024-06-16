using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("Manager")]
    [SerializeField] private float timeBeforeLoad = 0.2f;

    [Header("Scenes")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject levelSelection;

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
    public void LoadLevelSelection()
    {
        StartCoroutine(DelayLevelSelection());
    }

    private IEnumerator DelayLevelSelection()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        mainMenu.SetActive(false);
        levelSelection.SetActive(true);
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

    #region Settings Manager

    /**
     * <summary>
     * Button menu load menu scene.
     * </summary>
     */
    public void LoadMenu()
    {
        StartCoroutine(DelayMenu());
    }

    private IEnumerator DelayMenu()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        settings.SetActive(false);
        mainMenu.SetActive(true);
        _audioManager.GlitchSFX.Play();
    }

    #endregion

    #region Level Selection

    /**
     * <summary>
     * These button load different games.
     * </summary>
     */
    public void LoadDartsGame()
    {
        StartCoroutine(DelayDarts());
    }

    private IEnumerator DelayDarts()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        SceneManager.LoadScene("Darts", LoadSceneMode.Single);
    }

    public void LoadPoolGame()
    {
        StartCoroutine(DelayPool());
    }

    private IEnumerator DelayPool()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        SceneManager.LoadScene("Pool", LoadSceneMode.Single);
    }

    public void LoadBarGame()
    {
        StartCoroutine(DelayBar());
    }

    private IEnumerator DelayBar()
    {
        _audioManager.ButtonSFX.Play();
        yield return new WaitForSeconds(timeBeforeLoad);

        SceneManager.LoadScene("Bar", LoadSceneMode.Single);
    }
    #endregion
}