using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SetFrameRate : MonoBehaviour
    {
        private void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}