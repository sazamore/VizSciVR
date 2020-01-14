//Created by Sharri Zamore on 12/18/2019
//Adapted from tutorial: https://www.youtube.com/watch?v=N1omYggpq2g

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStreaming : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    //public AudioSource audioSource; //uncomment to add sound to the video
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        //create wait function, to pause while video is being prepared
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture; //render texture for video player to raw image player
        videoPlayer.Play(); //play video
        //audioSource.Play(); //uncomment to add sound to the video
    }
}
