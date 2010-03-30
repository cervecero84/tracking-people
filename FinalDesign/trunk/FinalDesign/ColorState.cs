using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FinalSolution
{
    [Serializable()]
    public class ColorState
    {
        public DenseHistogram CbHist { get; set; }
        public DenseHistogram CrHist { get; set; }
        public double ThresholdValue { get; set; }
        public int ErosionValue { get; set; }
        public int DilationValue { get; set; }
        public byte BinSize { get; set; }

        public ColorState()
        {
            BinSize = 32;
            CbHist = new DenseHistogram(BinSize, new RangeF(0, 255));
            CrHist = new DenseHistogram(BinSize, new RangeF(0, 255));
            ThresholdValue = ErosionValue = DilationValue = 0;
        }

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

            // If the band is not found (all probabilies are 0)
            if (colorProbs[3].Value < 0.01) return BandColor.NotFound;

            return colorProbs[3].Key;
        }

        /// <summary>
        /// Pass in the image representing the current color for the state to store the color information
        /// </summary>
        /// <param name="img">Image representing the current color</param>
        public void Learn(Image<Ycc, Byte> img)
        {
            CbHist = new DenseHistogram(BinSize, new RangeF(0, 255));
            CrHist = new DenseHistogram(BinSize, new RangeF(0, 255));
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

        public void Learn(Image<Ycc, Byte> img, int t, int e, int d)
        {
            Learn(img);
            ThresholdValue = t;
            ErosionValue = e;
            DilationValue = d;
        }

        /// <summary>
        /// Get the probability of the current color for a given image
        /// </summary>
        /// <param name="img">The image which is to be evaluated for current color</param>
        /// <returns></returns>
        public Image<Gray, Byte> GetProbabilityImage(Image<Ycc, Byte> img)
        {
            Image<Gray, Byte>[] sourceChannels = img.Split();

            // Initialization
            IntPtr[] sourcePtr = new IntPtr[1];

            // Use the Cr-channel
            sourcePtr[0] = sourceChannels[1];
            Image<Gray, Byte> backProjectCr = new Image<Gray, byte>(img.Size);
            CvInvoke.cvCalcBackProject(sourcePtr, backProjectCr, CrHist);
            
            // Use the Cb-channel
            sourcePtr[0] = sourceChannels[2];
            Image<Gray, Byte> backProjectCb = new Image<Gray, byte>(img.Size);
            CvInvoke.cvCalcBackProject(sourcePtr, backProjectCb, CbHist);

            // Change color of the detected band in the output image
            Image<Gray, Byte> result = backProjectCr.And(backProjectCb);

            // In place thresholding, erosion and dilation
            if (ThresholdValue > 0) result._ThresholdBinary(new Gray(ThresholdValue), new Gray(255));
            result = result.Erode(ErosionValue);
            result = result.Dilate(DilationValue);

            return result;
        }

        /// <summary>
        /// Gets the probability image in a particular color
        /// </summary>
        /// <param name="img">The source image which is to be converted to the current color probability image</param>
        /// <param name="color">HSV value to show when 100% color match</param>
        /// <returns></returns>
        public Image<Hsv, Byte> GetProbabilityImage(Image<Ycc, Byte> img, Hsv color)
        {
            Image<Gray, Byte> gray = GetProbabilityImage(img);
            Image<Hsv, Byte> hsv = new Image<Hsv, byte>(img.Width, img.Height);
            CvInvoke.cvMerge(gray.Mul(color.Hue), gray, gray, IntPtr.Zero, hsv);
            return hsv;
        }
    }
}
