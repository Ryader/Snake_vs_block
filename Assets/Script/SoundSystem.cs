using UnityEngine;

internal class SoundSystem : MonoBehaviour
{
    [Header("Звук")]
    [SerializeField] private AudioClip audioHit;
    [SerializeField] private AudioClip audioScore;
    [SerializeField] private AudioClip audioDead;
    [SerializeField] private AudioClip audioVictory;
    [SerializeField] private AudioSource audioSource;

    internal void Dead() => audioSource.PlayOneShot(audioDead);
    internal void Victory() => audioSource.PlayOneShot(audioVictory);
    internal void Hit() => audioSource.PlayOneShot(audioHit);
    internal void Score() => audioSource.PlayOneShot(audioScore);
}