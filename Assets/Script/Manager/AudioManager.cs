using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    private static AudioManager Instance { get; set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var sound in sounds) {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.outputAudioMixerGroup = sound.audioMixerGroup;
        }
    }

    private void Start() {
        Play(SoundEnum.MainMenu);
    }

    public void Play(SoundEnum soundToPlay) {
        Sound sound = Array.Find(sounds, sound => sound.name == soundToPlay);
        if (!sound.audioSource.isPlaying) {
            sound.audioSource.Play();
        }
    }

    public void StopAllSounds() {
        foreach (var sound in sounds) {
            if (sound.audioSource.isPlaying) {
                sound.audioSource.Stop();
            }
        }
    }
}
