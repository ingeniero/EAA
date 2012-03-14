namespace EAA
{
    using System;
    using System.IO;
    using System.Text;

    public class Class1
    {
        static bool _timeCompare;
        //static DateTime _lastDay;
        static bool _endOfDay;
        static TimeSpan _timeNow;
        static TimeSpan _timeStop;
        static bool _newCompare;
        static DateTime _startTime = new DateTime(2012, 2, 1, 15, 00, 00);
        static readonly DateTime StopTime = new DateTime(2012, 2, 2, 15, 00, 00);
        static TimeSpan _timeBegin;
        static TimeSpan _timeClearing;
        static TimeSpan _endClearing;
        static TimeSpan _timeNowFirst;

        static void Main()
        {
            // My method
            if (DateTime.Now.Hour < 18) _timeCompare = true;
            if (DateTime.Now.Hour == 18) _timeCompare = DateTime.Now.Minute < 45;
            if (DateTime.Now.Hour > 18) _timeCompare = false;

            // Moadip method
            _endOfDay = false;
            //_timeNow = DateTime.Now.TimeOfDay;
            _timeNow = _startTime.TimeOfDay;
            _timeBegin = Convert.ToDateTime("10:00:00").TimeOfDay;
            _timeStop = Convert.ToDateTime("18:45:00").TimeOfDay;
            _timeClearing = Convert.ToDateTime("14:00:00").TimeOfDay;
            _endClearing = Convert.ToDateTime("14:03:00").TimeOfDay;

            while (_startTime < StopTime)
            {
                _timeNow = _startTime.TimeOfDay;
                _timeNowFirst = _timeNow;

                if (_timeNow < _timeBegin)
                {
                    //_startTime += TimeSpan.FromHours(5);
                    Console.WriteLine("_timeNow < _timeBegin");
                    Console.WriteLine("EarlyMorning");
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    _timeNow += TimeSpan.FromHours(10);
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.ReadLine();
                }

                if (_timeNow >= _timeBegin && _timeNow < _timeClearing)
                {
                    Console.WriteLine("_timeNow < _timeClearing");
                    Console.WriteLine("UtroSession");
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    _timeNow += TimeSpan.FromHours(1);
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.ReadLine();
                }

                if (_timeNow >= _timeClearing && _timeNow <= _endClearing)
                {
                    Console.WriteLine("_timeNow = Clearing");
                    Console.WriteLine("DailyClearing");
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    _timeNow += TimeSpan.FromHours(1);
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.ReadLine();
                }

                if (_timeNow > _endClearing && _timeNow < _timeStop)
                {
                    Console.WriteLine("_timeNow > _endClearing");
                    Console.WriteLine("MainSession");
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    _timeNow += TimeSpan.FromHours(1);
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.ReadLine();
                }

                if (_timeNow > _timeStop && !_endOfDay)
                {
                    _newCompare = false;
                    _endOfDay = true;
                    //_startTime += TimeSpan.FromHours(1);
                    Console.WriteLine("_timeNow > _timeStop");
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    _timeNow += TimeSpan.FromHours(1);
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.ReadLine();
                }

                if (_startTime < StopTime)
                {
                    _newCompare = true;
                    _endOfDay = false;
                    Console.WriteLine("_startTime < StopTime");
                    Console.WriteLine("_timeNow = {0}", _timeNow);
                    Console.WriteLine("_timeNowFirst = {0}", _timeNowFirst);
                    Console.WriteLine("_startTime = {0}", _startTime);
                    _startTime += (_timeNow - _timeNowFirst);
                    //_startTime += TimeSpan.FromDays(1);
                    Console.WriteLine("_startTime = {0}", _startTime);
                    Console.ReadLine();
                }
            }

            //DateTime myDateTime = Convert.ToDateTime("18:45:00");
            //Console.WriteLine("Convert.ToDateTime(18:45:00) = {0}", myDateTime);
            Console.WriteLine();
            Console.WriteLine("My method results");
            Console.WriteLine("DateTime.Now = {0}", DateTime.Now);
            Console.WriteLine("_timeCompare = {0}", _timeCompare);
            Console.WriteLine();
            Console.WriteLine("Moadip method results");
            Console.WriteLine("_timeNow = {0}", _timeNow);
            Console.WriteLine("_timeStop = {0}", _timeStop);
            //Console.WriteLine("_lastDay = {0}", _lastDay);
            Console.WriteLine("_endOfDay = {0}", _endOfDay);
            Console.WriteLine("_newCompare = {0}", _newCompare);
            Console.ReadLine();

            try
            {
                //Open the File
                var sw = new StreamWriter("C:\\Test.txt", true, Encoding.Unicode);

                //Write a line of text
                sw.WriteLine();
                sw.WriteLine("My method results");
                sw.WriteLine("DateTime.Now = {0}", DateTime.Now);
                sw.WriteLine("_timeCompare = {0}", _timeCompare);
                sw.WriteLine();
                sw.WriteLine("Moadip method results");
                sw.WriteLine("_timeNow = {0}", _timeNow);
                sw.WriteLine("_timeStop = {0}", _timeStop);
                //sw.WriteLine("_lastDay = {0}", _lastDay);
                sw.WriteLine("_endOfDay = {0}", _endOfDay);
                sw.WriteLine("_newCompare = {0}", _newCompare);

                //close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block");
            }

            Console.ReadLine();
        }
    }
}
