using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPercentable
{
    public event Action Changed;
    
    public float Percent { get; }
}
