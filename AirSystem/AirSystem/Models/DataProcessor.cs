using System.Linq;
using SQLite;
using System.Collections.Generic;
using System;

namespace AirSystem.Models
{
    // Модель для таблиці Indicator
    public class Indicator
    {
        [PrimaryKey, AutoIncrement]
        public int SensorDataID { get; set; }
        public DateTime TakingDateTime { get; set; }
        public int ParameterID { get; set; }
    }

    // Модель для таблиці Parameter
    public class Parameter
    {
        [PrimaryKey, AutoIncrement]
        public int ParameterID { get; set; }
        public int ParameterTypeID { get; set; }
        public int ActionID { get; set; }
        public double Value { get; set; }
    }

    // Модель для таблиці ParameterType
    public class ParameterType
    {
        [PrimaryKey, AutoIncrement]
        public int ParameterTypeID { get; set; }
        public string Description { get; set; }
        public string NameParameter { get; set; }
    }

    // Модель для таблиці SensorData
    public class SensorData
    {
        [PrimaryKey, AutoIncrement]
        public int SensorDataID { get; set; }
        public int StationID { get; set; }
    }

    // Модель для таблиці Station
    public class Station
    {
        [PrimaryKey, AutoIncrement]
        public int StationID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }

    // Модель для таблиці Action
    public class Action
    {
        [PrimaryKey, AutoIncrement]
        public int ActionID { get; set; }
        public string Recommendation { get; set; }
    }

    // Модель для результату запиту
    public class LastIndicator
    {
        public int StationID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double CatchValue { get; set; }
        public double ParameterValue { get; set; }
        public string Recommendation { get; set; }
        public DateTime TakingDateTime { get; set; }
        public string NameParameter { get; set; }
        public string Description { get; set; }
        public string MajorName { get; set; }
    }

    public class DataProcessor
    {
        private readonly SQLiteConnection _connection;

        public DataProcessor(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public List<LastIndicator> GetLastIndicators()
        {
            // Отримання даних з бази за допомогою LINQ
            var result = (from m in _connection.Table<Indicator>()
                          join p in _connection.Table<Parameter>() on m.ParameterID
                          equals p.ParameterID
                          join pt in _connection.Table<ParameterType>()
                          on p.ParameterTypeID
                          equals pt.ParameterTypeID
                          join sd in _connection.Table<SensorData>() on m.SensorDataID
                          equals sd.SensorDataID
                          join s in _connection.Table<Station>() on sd.StationID
                          equals s.StationID
                          join a in _connection.Table<Action>() on p.ActionID
                          equals a.ActionID
                          let majorName = _connection.Table<Station>().
                          FirstOrDefault()?.Name
                          group new { m, p, pt, s, a, majorName } by new
                          {
                              s.Latitude,
                              s.Longitude,
                              s.Name,
                              p.Value,
                              m.TakingDateTime,
                              a.Recommendation,
                              pt.NameParameter,
                              pt.Description,
                              s.StationID,
                              m.SensorDataID
                          }
                into grouped
                          select new LastIndicator
                          {
                              StationID = grouped.Key.StationID,
                              Latitude = grouped.Key.Latitude,
                              Longitude = grouped.Key.Longitude,
                              Name = grouped.Key.Name,
                              CatchValue = grouped.Sum(g => g.m.SensorDataID),
                              ParameterValue = grouped.Key.Value,
                              Recommendation = grouped.Key.Recommendation,
                              TakingDateTime = grouped.Key.TakingDateTime,
                              NameParameter = grouped.Key.NameParameter,
                              Description = grouped.Key.Description
                          }).ToList();

            return result;
        }
    }
}


