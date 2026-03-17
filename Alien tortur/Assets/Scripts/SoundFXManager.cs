using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Afspil en valgt lyd
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Instantier dit "Game Object" "audioSource" som vil afspille lyden
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Giv dit "Game Object" "audioSource" et lydklip, som det kan afspille
        audioSource.clip = audioClip;

        //Giv lydklippet en volumen
        audioSource.volume = volume;

        //Afspil lydklippet
        audioSource.Play();

        //Mål længden på lydklippet
        float clipLength = audioSource.clip.length;

        //Fjern dit "Game Object" efter lyden er færdig med at afspille
        Destroy(audioSource.gameObject, clipLength);

    }

    //Afspil en random lyd ved at vælge mellem en "array" af lydklip
    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //Vælg et tilfældigt/random "index"
        int rand = Random.Range(0, audioClip.Length);

        //Instantier dit "Game Object" "audioSource" som vil afspille lyden
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Giv dit "Game Object" "audioSource" et lydklip, som det kan afspille
        audioSource.clip = audioClip[rand];

        //Giv lydklippet en volumen
        audioSource.volume = volume;

        //Afspil lydklippet
        audioSource.Play();

        //Mål længden på lydklippet
        float clipLength = audioSource.clip.length;

        //Fjern dit "Game Object" efter lyden er færdig med at afspille
        Destroy(audioSource.gameObject, clipLength);

    }
}