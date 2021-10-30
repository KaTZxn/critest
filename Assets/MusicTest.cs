
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicTest : MonoBehaviour
{
    private CriAtomEx.CueInfo[] cueInfoList;
    private CriAtomExPlayer atomExPlayer;
    private CriAtomExAcb atomExAcb;
    private CriAtomExPlayback playback;
    public Text Timing;
    public Text Ti;
    public Text BPM;
    private double TT;
    private double SongBPM;

    IEnumerator Start()
    {
        /* キューシートファイルのロード待ち */
        while (CriAtom.CueSheetsAreLoading) {
            yield return null;
        }
        /* Cue情報の取得 */
        atomExAcb = CriAtom.GetAcb("FDCueSheet");
        cueInfoList = atomExAcb.GetCueInfoList();
        /* AtomExPlayerの生成 */
        atomExPlayer = new CriAtomExPlayer(true);
        //atomExPlayer.SetCue(atomExAcb,cueInfoList[0].name);
        //playback = atomExPlayer.Start();
        
    }

    private void Update() 
    {
        long playTime = playback.GetTimeSyncedWithAudio();
        //Debug.Log(atomExAcb.GetCueInfo());
        Timing.text = playTime + "ms";
        TT = playTime/(60000/SongBPM);
        Ti.text =Math.Floor(TT)+"";
        BPM.text = "BPM:"+SongBPM;
    }

    public void OnB1()
    {
        if(atomExPlayer.GetStatus() == CriAtomExPlayer.Status.Playing) 
        {
            atomExPlayer.Stop();
        }
        SongBPM = 222.22;
        atomExPlayer.SetCue(atomExAcb,cueInfoList[0].name);
        playback = atomExPlayer.Start();
    }

    public void OnB2()
    {
        if(atomExPlayer.GetStatus() == CriAtomExPlayer.Status.Playing) 
        {
            atomExPlayer.Stop();
        }
        SongBPM = 225;
        atomExPlayer.SetCue(atomExAcb,cueInfoList[1].name);
        playback = atomExPlayer.Start();
        
        
    }
    public void OnPause()
    {
        if(atomExPlayer.IsPaused() != true)
        {
            atomExPlayer.Pause();
        }
        else
        {
            atomExPlayer.Resume(CriAtomEx.ResumeMode.PausedPlayback);
        }

    }

}
