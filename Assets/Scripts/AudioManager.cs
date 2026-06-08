using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceReal;
    public AudioClip clickSound;

    private Button botones;

    void Start()
    {
       botones = GetComponent<Button>();

        if (botones != null)
        {
            botones.onClick.AddListener(PlaySound);
        }
    }

    void PlaySound()
    {
        if (audioSourceReal != null && clickSound != null)
        {
            if (!audioSourceReal.gameObject.activeInHierarchy) audioSourceReal.gameObject.SetActive(true);
            if (!audioSourceReal.enabled) audioSourceReal.enabled = true;

            audioSourceReal.PlayOneShot(clickSound);
        }
    }
}
