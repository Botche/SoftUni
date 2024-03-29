﻿using System;

using ViceCity.IO;
using ViceCity.IO.Contracts;
using ViceCity.Core.Contracts;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

            controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        var name = input[1];

                        writer.WriteLine(controller.AddPlayer(name));
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var gunName = input[2];

                        writer.WriteLine(controller.AddGun(type, gunName));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var playerName=input[1];

                        writer.WriteLine(controller.AddGunToPlayer(playerName));
                    }
                    else if (input[0] == "Fight")
                    {
                        writer.WriteLine(controller.Fight());
                    }            
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
