using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject _w;
    [SerializeField] private GameObject _wDark;
    [SerializeField] private GameObject _s;
    [SerializeField] private GameObject _sDark;
    [SerializeField] private GameObject _a;
    [SerializeField] private GameObject _aDark;
    [SerializeField] private GameObject _d;
    [SerializeField] private GameObject _dDark;
    [SerializeField] private GameObject _space;
    [SerializeField] private GameObject _spaceDark;
    [SerializeField] private GameObject _shift;
    [SerializeField] private GameObject _shiftDark;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _w.SetActive(true);
            _wDark.SetActive(false);
        }
        else
        {
            _w.SetActive(false);
            _wDark.SetActive(true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _s.SetActive(true);
            _sDark.SetActive(false);
        }
        else
        {
            _s.SetActive(false);
            _sDark.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _a.SetActive(true);
            _aDark.SetActive(false);
        }
        else
        {
            _a.SetActive(false);
            _aDark.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _d.SetActive(true);
            _dDark.SetActive(false);
        }
        else
        {
            _d.SetActive(false);
            _dDark.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            _space.SetActive(true);
            _spaceDark.SetActive(false);
        }
        else
        {
            _space.SetActive(false);
            _spaceDark.SetActive(true);
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _shift.SetActive(true);
            _shiftDark.SetActive(false);
        }
        else
        {
            _shift.SetActive(false);
            _shiftDark.SetActive(true);
        }
    }
}
