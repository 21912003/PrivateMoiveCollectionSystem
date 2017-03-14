using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTest
{
    public class MediaInfoEntity
    {
        private String fileName;
        private String fileSize;
        private String videoHeight;
        private String videoWidth;
        private String videoTime;
        private String videoBitRate;
        private String fileParent;
        private String fileRoot;
        private String fileNameOfChn;

        private String subtitles;
        private long fileLength;
        private String disk;
        private String completePath;//Complete name

        public String CompletePath
        {
            get { return completePath; }
            set { completePath = value; }
        }

        public String Disk
        {
            get { return disk; }
            set { disk = value; }
        }

        public long FileLength
        {
            get { return fileLength; }
            set { fileLength = value; }
        }

        public String Subtitles
        {
            get { return subtitles; }
            set { subtitles = value; }
        }

        public String FileNameOfChn
        {
            get { return fileNameOfChn; }
            set { fileNameOfChn = value; }
        }

        public String FileRoot
        {
            get { return fileRoot; }
            set { fileRoot = value; }
        }

        public String FileParent
        {
            get { return fileParent; }
            set { fileParent = value; }
        }

        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public String FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public String VideoHeight
        {
            get { return videoHeight; }
            set { videoHeight = value; }
        }

        public String VideoWidth
        {
            get { return videoWidth; }
            set { videoWidth = value; }
        }

        public String VideoTime
        {
            get { return videoTime; }
            set { videoTime = value; }
        }

        public String VideoBitRate
        {
            get { return videoBitRate; }
            set { videoBitRate = value; }
        }

    }
}
