﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealogicsSocket.Interface
{
    internal interface IServer
    {
        void Start(Action<(string ip, string port, string fileName)> func);
    }
}
