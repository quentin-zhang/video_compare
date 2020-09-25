using System;
using VideoConsole.FFmpegOP;
using VideoConsole.OpenCVOP;

namespace VideoConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            //GetVideoKeyFrame();
            CompareImages();
        }

        /// <summary>
        /// 取关键帧
        /// </summary>
        private static void GetVideoKeyFrame()
        {
            ISample videoWorker = new VideoWorker();
            videoWorker.Run();
        }

        /// <summary>
        /// 比对图片
        /// </summary>
        private static void CompareImages()
        {
            ISample compareImage = new CompareImages();
            compareImage.Run();
        }
    }
}
