using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgressBar
{
    public event EventHandler<BarProgressChangedEventArgs> BarProgressChanged;
    public class BarProgressChangedEventArgs : EventArgs {
        public float progress;
    }

}
