using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngine : MonoBehaviour {

    public AudioSource Channel1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Channel1.isPlaying==true) {
			print ("Is playing");
			print (Channel1.time);
		}
    }
    public void PlayAudio(AudioData data)
    {
        if (data.ChannelName!=null)
        {
            switch (data.ChannelName.ToLower())
            {
                case "background":
                    SetChannelData(Channel1,data);
                    break;
            }
        }
        else
        {
            switch (data.ChannelNumber)
            {
                case 1:
                    SetChannelData(Channel1, data);
                    break;
            }
        }
    }
    public void SetChannelData(AudioSource chan,AudioData data)
    {
		print ("Setting Audio Data");
        chan.loop = data.CanLoop;
		chan.volume = data.ChannelVolume;
        if (data.ChannelPriority != -1)
        {
			chan.priority = data.ChannelPriority;
        }
		chan.clip = data.Clip;
		print("Data Clip: "+data.Clip);
		chan.time = (float)data.StartTime;
		chan.Play ();
		chan.SetScheduledEndTime (AudioSettings.dspTime + (data.EndTime - data.StartTime));
	}
    public void PlayBackgroundSound(AudioClip clip)
    {
        PlaySound(Channel1, clip);
    }
		
    void PlaySound(AudioSource audio, AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
public class AudioData
{
    public AudioData() { }
    
    public AudioData(string channelName,AudioClip clip)
    {
		Clip = clip;
        ChannelName = channelName;
        StartTime = 0;
        EndTime = clip.length;
        CanLoop = false;
        ChannelVolume = 1.0f;
        ChannelPriority = -1;
    }
    public AudioData(int channelNum,AudioClip clip)
    {
		Clip = clip;
        ChannelNumber = channelNum;
        StartTime = 0;
        EndTime = clip.length;
        CanLoop = false;
        ChannelVolume = 1.0f;
        ChannelPriority = -1;
    }
    public AudioData(int channelNum,AudioClip clip,double startTime,double endTime,bool canLoop,float channelVolume,int channelPriority)
    {
		Clip = clip;
        ChannelNumber = channelNum;
		StartTime = startTime;
		EndTime = endTime;
        CanLoop = false;
        ChannelVolume = 1.0f;
        ChannelPriority = channelPriority;
    }
    public AudioClip Clip
    {
        get;
        set;
    }
    public string ChannelName
    {
        get;
        set;
    }
    public int ChannelNumber
    {
        get;
        set;
    }
    //defines the start time of the clip
    public double StartTime
    {
        get;
        set;
    }
    //defines the end time of the clip
    public double EndTime
    {
        get;
        set;
    }
    //tells the player if it can loop
    public bool CanLoop
    {
        get;
        set;
    }
    //sets if it should be played over other clips
    public int ChannelPriority
    {
        get;
        set;
    }
    //sets channel volume between 0 to 1.0
    public float ChannelVolume
    {
        get;
        set;
    }
}
