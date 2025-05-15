using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxSource;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(string clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>($"SFX/{clipName}");

        if(clip == null)
        {
            Debug.LogError($"[AudioManager] AudioClip '{clipName}' not found in Resources/SFX");
            return;
        }

        sfxSource.PlayOneShot(clip);
    }
}
