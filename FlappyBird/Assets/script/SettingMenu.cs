using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audio_mixer;
    public Dropdown resolution_dropdown;
    Resolution[] resolutions;

    public Toggle toggle;
    private void Start()
    {
        // known Resolution that has on the running computer
        resolutions = Screen.resolutions;
        // clear the options in game and then create a new one based on above
        resolution_dropdown.ClearOptions();

        List<string> temp = new List<string>();
        int curReso = 0;
       for(int i = 0; i < resolutions.Length; i++)
        {
            int width = (int)resolutions[i].height / 16 * 9;
            string op = width + " x " + resolutions[i].height;
            temp.Add(op);

            if (resolutions[i].height == Screen.currentResolution.height)
            {
                curReso = i;
            }
        }

        resolution_dropdown.AddOptions(temp);
        // change the tick in the dropdown menu to current resolution
        resolution_dropdown.value = curReso;
        resolution_dropdown.RefreshShownValue();

        // set the init value of fullScreen Toggle
        toggle.isOn = Screen.fullScreen;
    }

    public void SetResolution(int value)
    {
        Resolution curReso = resolutions[value];
        Screen.SetResolution((int)curReso.height / 16 * 9, curReso.height, Screen.fullScreen);
    }

    public void SetVolumn(float value)
    {
        audio_mixer.SetFloat("master_volume", value);
    }

    //value: 0,1,2,3,4,5
    public void SetQuality(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }

    public void SetFullScreeen(bool value)
    {
        Screen.fullScreen = value;
    }
}
