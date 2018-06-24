﻿namespace Ixen
{
    public class IxenApplicationInitOptions
    {
        public string Title { get; set; } = "Ixen Application";
    }

    public class IxenSizedApplicationInitOptions : IxenApplicationInitOptions
    {
        public int Width { get; set; } = 640;
        public int Height { get; set; } = 480;
    }
}
