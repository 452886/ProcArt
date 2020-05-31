using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HoudiniEngineUnity;


namespace Demo
{
    public class Controller : BuildSettings
    {
        public void Start()
        {
            City procCity = new City(this as BuildSettings);
            procCity.InitializeCity();
        }
    }
}

