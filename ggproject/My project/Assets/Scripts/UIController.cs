using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _manager;
    [SerializeField] private AudioSource _audioSource;
    public void OnClickPlay()
    {
        _manager.SetActive(true);
        gameObject.SetActive(false);
        _audioSource.Play();
    }

    public void OnClickExit()
    {

    }
}
