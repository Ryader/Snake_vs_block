using UnityEngine;

[RequireComponent(typeof(AudioSource))]

internal class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip audioHit;
    [SerializeField] private AudioClip audioDead;
    [SerializeField] private AudioClip audioScore;
    [SerializeField] private AudioClip audioVictory;
    [SerializeField] private AudioSource audioSource;

    private void Start() => audioSource = GetComponent<AudioSource>();
    internal void Hit() => audioSource.PlayOneShot(audioHit);
    internal void Dead() => audioSource.PlayOneShot(audioDead);
    internal void Score() => audioSource.PlayOneShot(audioScore);
    internal void Victory() => audioSource.PlayOneShot(audioVictory);
}