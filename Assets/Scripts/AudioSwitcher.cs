using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    public void PauseMusic()
    {
        var audio =  gameObject.GetComponent<AudioSource>();

        if (audio.isPlaying)
        {
            audio.Pause();
        }
        else audio.Play();
    }

}
