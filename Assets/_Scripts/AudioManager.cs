using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    [Header("UI Sounds")]
    [SerializeField] private AudioSource buttonSound;

    //Singleton.
    private static AudioManager _instance;

    #endregion

    #region Properties

    //Singleton.
    public static AudioManager Instance => _instance;

    public AudioSource ButtonSound => buttonSound;

    #endregion

    #region Built-In Methods

    /**
     * <summary>
     * Singleton.
     * </summary>
     */
    private void Awake()
    {
        if (_instance)
        {
            Destroy(this);
        }
        _instance = this;
    }

    #endregion
}