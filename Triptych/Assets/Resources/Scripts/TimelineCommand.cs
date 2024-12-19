using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;
using Yarn.Unity;

public class TimelineCommand : MonoBehaviour
{
    public PlayableDirector endDirector;
    public Animator busAnim;
    public AudioSource audioHolder;
    public AudioClip debussy;
    public Button endButton;

    private Scene currentScene;
    // Start is called before the first frame update

    private void Awake()
    {
        endDirector = GetComponent<PlayableDirector>();
        currentScene = SceneManager.GetActiveScene();
        busAnim.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("playDebussy")]
    public void MusicPlay()
    {
        audioHolder.clip = debussy;
        audioHolder.Play();
    }

    [YarnCommand("timelineStart")]
    public void TimelineStart()
    {
        Debug.Log("end");
        busAnim.gameObject.SetActive(true);
        StartCoroutine(WaitToEnd());
        endButton.gameObject.SetActive(true);
        endDirector.Play();
    }

    [YarnCommand ("quitRestart")]
    public void EndGame()
    {
        Debug.Log("closing the game");
        StartCoroutine("WaitToEnd");
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(2f);
    }

    public void Restart()
    {
        SceneManager.LoadScene("BusScene");
    }
}
