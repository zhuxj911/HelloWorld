﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ZXY.Drawing;

namespace SurApp
{
    public class AzimuthWindowVM : NotificationObject
	{     
        private SPoint _A = new SPoint
        {
            Name = "A",
            X = 50342.464,
            Y = 3528.978    };
        public SPoint A
        {
            get => _A;
        }

        private SPoint _B = new SPoint
        {
            Name = "B",
            X = 50289.874,
            Y = 3423.232
        };
        public SPoint B
        {
            get => _B;
        }


        private string _AZName = "坐标方位角";
        public string AZName
        {
            get { return _AZName; }
            set
            {
                _AZName = value;
                RaisePropertyChanged("AZName");
            }
        }

        private string _azValue;
        public string AZValue
        {
            get { return _azValue; }
            set
            {
                _azValue = value;
                RaisePropertyChanged("AZValue");
            }
        }

        private double _dist;
        public double Dist
        {
            get { return Math.Round(_dist,3); }
            set
            {
                _dist = value;
                RaisePropertyChanged("Dist");
            }
        }

        public void CalculateAzimuth()
        {
            var ad = ZXY.SurMath.Azimuth(A.X, A.Y, B.X, B.Y);
            AZValue = ZXY.SurMath.RadtoString(ad.a);
            Dist = ad.d;
            AZName = $"{A.Name} -> {B.Name} 坐标方位角";
        }
    }
}
