using OpenCvSharp;
using System;
using System.IO;

namespace VideoConsole.OpenCVOP
{
    public class CompareImages : ISample
    {
        string imageAPath = SampleConfiguration.SOURCE_KEY_FRAME_PATH + SampleConfiguration.FILENAMEHEAD + SampleConfiguration.FILENAMENUMBER;
        string imageBPath = SampleConfiguration.CUT_KEY_FRAME_PATH + SampleConfiguration.FILENAMEHEAD;
        public void Run()
        {
            DateTime dateTime1 = DateTime.Now;
            


            //Mat grayA = imageA.CvtColor(ColorConversionCodes.BGR2GRAY);
            //Mat grayB = imageB.CvtColor(ColorConversionCodes.BGR2GRAY);
            var sourceKeyFrameFileCount = Directory.GetFiles(SampleConfiguration.SOURCE_KEY_FRAME_PATH).Length;
            var cutKeyFrameFileCount = Directory.GetFiles(SampleConfiguration.CUT_KEY_FRAME_PATH).Length;
            for (int i = 0; i < sourceKeyFrameFileCount; i++)
            {
                for (int j = 0; j < cutKeyFrameFileCount; j++)
                {
                    string index = i.ToString();
                    //if (i < 10)
                    //{
                    //    index = "0" + i.ToString();
                    //}
                    Mat imageA = Cv2.ImRead(SampleConfiguration.SOURCE_KEY_FRAME_PATH + SampleConfiguration.FILENAMEHEAD  + i.ToString() + ".jpeg");
                    Mat imageB = Cv2.ImRead(SampleConfiguration.CUT_KEY_FRAME_PATH + SampleConfiguration.FILENAMEHEAD  + j.ToString() + ".jpeg");
                    ComareImages(imageA, imageB);
                }
            }
            

            DateTime dateTime2 = DateTime.Now;
            TimeSpan timeSpan1 = new TimeSpan();
            timeSpan1 = dateTime2 - dateTime1;
            //SSIMResult compareResult = SSIMResult.GetMSSIM(grayA, grayB);
            
            Console.WriteLine(timeSpan1);
            Console.ReadLine();
        }

        private void ComareImages(Mat imageA, Mat imageB)
        {
            var ssim = OpenCvUtils.CalculateSSIM(imageA, imageB);
            var averageValue = (ssim[0] + ssim[1] + ssim[2]) / 3;
            Console.WriteLine(averageValue);
        }
    }
}
