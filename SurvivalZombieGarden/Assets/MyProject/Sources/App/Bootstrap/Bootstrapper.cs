using System;
using MyProject.Sources.App.Core;
using MyProject.Sources.OldVersion.PlayerS.Factories.App;
using UnityEngine;

namespace MyProject.Sources.App.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        private AppCore _appCore;

        private void Awake()
        {
            _appCore = FindObjectOfType<AppCore>() ?? new AppCoreFactory().Create();
        }
    }
}