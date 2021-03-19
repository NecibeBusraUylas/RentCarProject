﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string CarModel { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string ImagePath { get; set; }
    }
}