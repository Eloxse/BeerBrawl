using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region Variables

    [Header("Audio Manager")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private Slider sliderGeneral;

    [Header("UI SFX")]
    [SerializeField] private AudioSource buttonSFX;

    [Header("SFX")]
    [SerializeField] private AudioSource glitchSFX;

    //Singleton.
    private static AudioManager _instance;

    #endregion

    #region Properties

    //Singleton.
    public static AudioManager Instance => _instance;

    //UI SFX.
    public AudioSource ButtonSFX => buttonSFX;
    
    //SFX.
    public AudioSource GlitchSFX => glitchSFX;

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