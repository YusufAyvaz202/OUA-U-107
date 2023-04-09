using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayVideo);

        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = true;

        videoPlayer.url = "file:///C:/path/to/video.mp4"; // video dosyası eklenecek
    }

    void PlayVideo()
    {
        videoPlayer.Play();
    }
}