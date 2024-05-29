using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Enemy _this;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        Debug.Log(_this.gameObject.name + " IsMoving = " + _this.IsMoving());
        if (_this.IsMoving())
        {
            _animator.SetFloat("Speed", 1f);
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }
    }
}
