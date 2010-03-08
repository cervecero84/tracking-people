using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FinalSolution
{
    class ColorState
    {
        public DenseHistogram CbHist { get; set; }
        public DenseHistogram CrHist { get; set; }
        public double ThresholdValue { get; set; }
        public int ErosionValue { get; set; }
        public int DilationValue { get; set; }

        public ColorState(DenseHistogram cbHist, DenseHistogram crHist,
            double thresholdValue, int erosionValue, int dilationValue)
        {
            CbHist = cbHist;
            CrHist = crHist;
            ThresholdValue = thresholdValue;
            ErosionValue = erosionValue;
            DilationValue = dilationValue;
        }

        public static double FindProbabilityOfBand(Image<Ycc, Byte> region, ColorState state)
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
