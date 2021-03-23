
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestProj.Extensions;

namespace TestProj
{
    class Program
    {
        static void Main(string[] args)
        {
            //string logFile = "#DATE|yyyy-MMM#_#JULIAN_DAY#_Deppul_#HostName#.log";
            string logFile = "MR-DATE|yyMMddHHmmss#%";

            var parsedFileName =  ParseFileName(logFile, "1232");

           // var parsedLogFile = ParseFileName(logFile);

            Console.ReadKey();
        }


        public static string ParseFileName(string input, string payeeID)
        {
            {
                string output = "";
                try
                {
                    string[] stringParts = input.Split('#');

                    bool parameterFound = false;
                    foreach (string stringPart in stringParts)
                    {
                        if (stringPart == "")
                        {
                            if (parameterFound)
                            {
                                output += "#";
                            }
                            else
                            {
                                parameterFound = true;
                            }
                        }
                        else if (parameterFound)
                        {
                            // Parameter Could have two parts separated by pipe (|)
                            // First Part tells the name of the parameter
                            // Second Part tells the format to be used for the given parameter
                            string[] strPart = stringPart.Split('|');
                            switch (strPart[0].ToUpper())
                            {
                                case "HOSTNAME":
                                    output += Dns.GetHostName();
                                    parameterFound = false;
                                    break;

                                case "PAYEE_ID":
                                    output += payeeID;
                                    parameterFound = false;
                                    break;

                                case "DATE":
                                    string dateFormat = string.Empty;
                                    if (strPart.Length == 2)
                                    {
                                        dateFormat = strPart[1];
                                    }
                                    if (String.IsNullOrEmpty(dateFormat) || (strPart.Length != 2))
                                    {
                                        throw new InvalidOperationException(String.Format("Invalid Date format[{0}] passed in file name [{1}] ", stringPart, input));
                                    }
                                    output += DateTime.Now.ToString(dateFormat);
                                    parameterFound = false;
                                    break;

                                case "JULIAN_DAY":
                                    JulianCalendar calendar = new JulianCalendar();
                                    DateTime dateInJulian = calendar.ToDateTime(DateTime.Today.Year,
                                                                                DateTime.Today.Month,
                                                                                DateTime.Today.Day,
                                                                                DateTime.Today.Hour,
                                                                                DateTime.Today.Minute,
                                                                                DateTime.Today.Second,
                                                                                DateTime.Today.Millisecond);

                                    int julianDay = calendar.GetDayOfYear(dateInJulian);
                                    output += Convert.ToString(julianDay);
                                    parameterFound = false;
                                    break;

                                default:
                                    output += "#" + stringPart;
                                    break;
                            }
                        }
                        else
                        {
                            output += stringPart;
                            parameterFound = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    //_logger.ErrorFormat("Failed to parse file name [{0}]. Error: {1}", input, ex.ToString());
                    throw;
                }
                return output;
            }

        }

    }
}
