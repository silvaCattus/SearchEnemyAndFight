using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public class EnemyData
{
    public List<Results> results;

    [Serializable]
    public class Results
    {
        public Login login;
        public Picture picture;

        [Serializable]
        public class Login
        {
            public string username;
        }
        [Serializable]
        public class Picture
        {
            public string medium;
        }

    }

}
