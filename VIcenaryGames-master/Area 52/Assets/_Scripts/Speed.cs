using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script creates an object with variables to act as speed values
/// </summary>
namespace Util
{
    [System.Serializable]
    public class Speed
    {
        //allows for inspector to set how many units a player moves
        public float min;
        public float max;
    }
}
