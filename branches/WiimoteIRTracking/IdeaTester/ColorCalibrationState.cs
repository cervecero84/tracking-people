using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace IdeaTester
{
    public class ColorCalibrationState
    {
        BandColor _color;
        DenseHistogram _cbHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _crHist = new DenseHistogram(16, new RangeF(0, 255));
        double _thresholdValue = 0;
        int _erosionValue = 0;
        int _dilationValue = 0;

        public ColorCalibrationState(BandColor color, DenseHistogram cbHist, DenseHistogram crHist,
            double thresholdValue, int erosionValue, int dilationValue)
        {
            _color = color;
            _cbHist = cbHist;
            _crHist = crHist;
            _thresholdValue = thresholdValue;
            _erosionValue = erosionValue;
            _dilationValue = dilationValue;
        }

        public BandColor Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public DenseHistogram CbHist
        {
            get
            {
                return _cbHist;
            }
            set
            {
                _cbHist = value;
            }
        }

        public DenseHistogram CrHist
        {
            get
            {
                return _crHist;
            }
            set
            {
                _crHist = value;
            }
        }

        public double ThresholdValue
        {
            get
            {
                return _thresholdValue;
            }
            set
            {
                _thresholdValue = value;
            }
        }

        public int ErosionValue
        {
            get
            {
                return _erosionValue;
            }
            set
            {
                _erosionValue = value;
            }
        }

        public int DilationValue
        {
            get
            {
                return _dilationValue;
            }
            set
            {
                _dilationValue = value;
            }
        }

        public static double findProbabilityOfBand(Image<Ycc, Byte> region, ColorCalibrationState state)
        {
            Image<Gray, Byte>[] regionChannels = region.Split();
            // Use the whole image

            // Initialization
            int channelIndex;
            IntPtr[] regionPtr = new IntPtr[1];

            // Use the Cb-channel
            channelIndex = 1;
            regionPtr[0] = regionChannels[channelIndex];

            Image<Gray, Byte> backProjectCb = new Image<Gray, byte>(region.Size);
            CvInvoke.cvCalcBackProject(regionPtr, backProjectCb, state.CbHist);

            // Use the Cr-channel
            channelIndex = 2;
            regionPtr[0] = regionChannels[channelIndex];

            Image<Gray, Byte> backProjectCr = new Image<Gray, byte>(region.Size);
            CvInvoke.cvCalcBackProject(regionPtr, backProjectCr, state.CrHist);

            // Change color of the detected band in the output image
            Image<Gray, Byte> result = backProjectCr.And(backProjectCb);

            result = result.ThresholdBinary(new Gray(state.ThresholdValue), new Gray(255));
            result = result.Erode(state.ErosionValue);
            result = result.Dilate(state.DilationValue);

            return ((double)(result.CountNonzero())[0] / (result.Size.Height * result.Size.Width)); ;
        }
    }
}
