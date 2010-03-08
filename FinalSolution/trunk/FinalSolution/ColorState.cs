using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FinalSolution
{
    public class ColorState
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
            IntPtr[] regionPtr = new IntPtr[1];

            // Use the Cr-channel
            regionPtr[0] = regionChannels[1];

            Image<Gray, Byte> backProjectCr = new Image<Gray, byte>(region.Size);
            CvInvoke.cvCalcBackProject(regionPtr, backProjectCr, state.CrHist);

            // Use the Cb-channel
            regionPtr[0] = regionChannels[2];

            Image<Gray, Byte> backProjectCb = new Image<Gray, byte>(region.Size);
            CvInvoke.cvCalcBackProject(regionPtr, backProjectCb, state.CbHist);

            // Change color of the detected band in the output image
            Image<Gray, Byte> result = backProjectCr.And(backProjectCb);

            result = result.ThresholdBinary(new Gray(state.ThresholdValue), new Gray(255));
            result = result.Erode(state.ErosionValue);
            result = result.Dilate(state.DilationValue);

            return ((double)(result.CountNonzero())[0] / (result.Size.Height * result.Size.Width)); ;
        }

        public static BandColor FindBand(Image<Ycc, Byte> img, ColorStateSet colors)
        {
            List<KeyValuePair<BandColor, double>> colorProbs = new List<KeyValuePair<BandColor,double>>();
            colorProbs.Add(new KeyValuePair<BandColor, double>(BandColor.Red, FindProbabilityOfBand(img, colors.Red)));
            colorProbs.Add(new KeyValuePair<BandColor, double>(BandColor.Green, FindProbabilityOfBand(img, colors.Green)));
            colorProbs.Add(new KeyValuePair<BandColor, double>(BandColor.Blue, FindProbabilityOfBand(img, colors.Blue)));
            colorProbs.Add(new KeyValuePair<BandColor, double>(BandColor.Yellow, FindProbabilityOfBand(img, colors.Yellow)));

            colorProbs.Sort((firstPair, nextPair) => { return firstPair.Value.CompareTo(nextPair.Value); });

            return colorProbs[0].Key;
        }

        public void Learn(Image<Ycc, Byte> img)
        {
            Image<Gray, Byte>[] bandImageChannels = img.Split();
            IntPtr[] bandImageChannelsPtr = new IntPtr[1];
            // Use the whole image
            Image<Gray, Byte> mask = new Image<Gray, byte>(img.Width, img.Height, new Gray(255));

            // Use the Cr-channel
            bandImageChannelsPtr[0] = bandImageChannels[1];
            CvInvoke.cvCalcHist(bandImageChannelsPtr, CrHist, false, mask);

            // Use the Cb-channel
            bandImageChannelsPtr[0] = bandImageChannels[2];
            CvInvoke.cvCalcHist(bandImageChannelsPtr, CbHist, false, mask);
        }
    }
}
