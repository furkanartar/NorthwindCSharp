﻿using System;

namespace Business.CSS
{
    public class FileLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya loglandı.");
        }
    }
}