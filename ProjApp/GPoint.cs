using System;
using System.Collections.Generic;
using System.Text;
using ZXY;

namespace ProjApp
{
    public class GPoint : Point
    {
        public override string ToString()
        {
            return $"{Name}, {X}, {Y}, {dmsB}, {dmsL}";
        }

        private double _dmsB;

        public double dmsB
        {
            get
            {
                return _dmsB;
            }
            set
            {
                _dmsB = value;
                RaisePropertyChanged();
            }
        }

        private double _dmsL;

        public double dmsL
        {
            get
            {
                return _dmsL;
            }
            set
            {
                _dmsL = value;
                RaisePropertyChanged();
            }
        }

        private double _Gamma;

        public double Gamma
        {
            get => _Gamma;
            set
            {
                _Gamma = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => GammaDmsString);
            }
        }

        public string GammaDmsString
        {
            get => ZXY.SurMath.RadianToDmsString(Gamma);
        }

        private double _m;

        public double m
        {
            get => _m;
            set
            {
                _m = value;
                RaisePropertyChanged();
            }
        }
    }
}