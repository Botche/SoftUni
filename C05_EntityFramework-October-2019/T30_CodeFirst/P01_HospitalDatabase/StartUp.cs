﻿using P01_HospitalDatabase.Data.Models;
using P01_HospitalDatabase.Data;

using System;
using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new HospitalContext())
            {
                db.Database.Migrate();
            }
        }
    }
}