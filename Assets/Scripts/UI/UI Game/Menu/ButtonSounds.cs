using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    public Text textVolume;
    public AudioMixerGroup audioMixerGroup;

    private int counterVolume = 0;
    private string[] arrayVolume = new string[4] { "Mute", "Low", "Medium", "High" };
    private float volume;

    private void Start()
    {
        // загружаю настройки звука
        counterVolume = PlayerPrefs.GetInt(audioMixerGroup.name, 0);
        // меняю настройки на загружанные
        ChangeVolumeSoundsOnTextAndSaveSettings(counterVolume);
        // устанавлию громкость звука на загруженные
        ChangeVolumeInAudioMixer();
    }

    private void Update()
    {
        if (EventSystem.current != null)
        {
            if (gameObject == EventSystem.current.currentSelectedGameObject)
            {
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    MoveArrayWithVolumeOnLeft();
                    ChangeVolumeSoundsOnTextAndSaveSettings(counterVolume);
                    ChangeVolumeInAudioMixer();
                }

                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    MoveArrayWithVolumeOnRight();
                    ChangeVolumeSoundsOnTextAndSaveSettings(counterVolume);
                    ChangeVolumeInAudioMixer();
                }
            }
        }
    }
    // меняю звук и текст соответсвенно, и сразу сохраняю
    public void ChangeVolumeSoundsOnTextAndSaveSettings(int _counterVolume)
    {
        PlayerPrefs.SetInt(audioMixerGroup.name, _counterVolume); // сохраняю настройки
        switch (_counterVolume)
        {
            case 0:
                textVolume.text = arrayVolume[0];
                volume = -80f; // Mute
                break;
            case 1:
                textVolume.text = arrayVolume[1];
                volume = -30f; // Low
                break;
            case 2:
                textVolume.text = arrayVolume[2];
                volume = -10f; // Medium
                break;
            case 3:
                textVolume.text = arrayVolume[3];
                volume = 0f; // High
                break;
            default:
                textVolume.text = arrayVolume[3];
                volume = 0f; // High
                break;
        }
        //PlayerPrefs.SetFloat(audioMixerGroup.name, volume);
    }

    public void ChangeVolumeInAudioMixer()
    {
        audioMixerGroup.audioMixer.SetFloat(audioMixerGroup.name, volume);
    }

    // отчерчиваю абстрактные границы слева
    private void MoveArrayWithVolumeOnLeft()
    {
        counterVolume--;

        if (counterVolume < 0)
        {
            counterVolume = 3;
        }
    }
    // отчерчиваю абстрактные границы справа
    private void MoveArrayWithVolumeOnRight()
    {
        counterVolume++;
        if (counterVolume > 3)
        {
            counterVolume = 0;
        }
    }
}
