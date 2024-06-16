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

    private void Start()
    {
        //Save player preferences.
        VolumePreferences();
    }

    #endregion

    #region Volume Settings

    /**
      * <summary>
      * Access sounds volume through settings pannel.
      * </summary>
      */
    public void SetGeneralVolume()
    {
        float volume = sliderGeneral.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("GeneralVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sliderSFX.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = sliderMusic.value;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    /**
      * <summary>
      * Save player preferences volume settings.
      * </summary>
      */
    private void VolumePreferences()
    {
        if (PlayerPrefs.HasKey("GeneralVolume"))
        {
            LoadGeneralVolume();
        }
        else
        {
            SetGeneralVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetSFXVolume();
        }

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    /**
      * <summary>
      * Save volume value.
      * </summary>
      */
    private void LoadGeneralVolume()
    {
        sliderGeneral.value = PlayerPrefs.GetFloat("GeneralVolume");
        SetGeneralVolume();
    }

    private void LoadSFXVolume()
    {
        sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
    }

    private void LoadMusicVolume()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();
    }

    #endregion
}