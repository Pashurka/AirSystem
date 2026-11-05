using System;
using System.Collections.Generic;

namespace AirSystem.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class PollenInfo
    {
        public DailyInfo[] DailyInfo { get; set; }
    }

    public class DailyInfo
    {
        public DateInfo Date { get; set; }
        public List<PollenTypeInfo> PollenTypeInfo { get; set; }
        public List<PlantInfo> PlantInfo { get; set; }
    }

    public class DateInfo
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }

    public class PollenTypeInfo
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool InSeason { get; set; }
        public IndexInfo IndexInfo { get; set; }
        public List<string> HealthRecommendations { get; set; }
    }

    public class IndexInfo
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public int Value { get; set; }
        public string Category { get; set; }
        public string IndexDescription { get; set; }
    }

    public class PlantInfo
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool InSeason { get; set; }
        public IndexInfo IndexInfo { get; set; }
    }
}