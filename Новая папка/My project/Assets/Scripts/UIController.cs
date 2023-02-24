using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _manager;
    public void OnClickPlay()
    {
        _manager.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnClickExit()
    {

    }
}
