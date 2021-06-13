using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using fengshui.Entity.DBContext;
using fengshui.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace fengshui.App
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("..Loading...");
            try
                {
                    using (var _context = new FengShuiDBContext())
                    {
                        _context.Database.EnsureCreated();
                        var phoneNumers = _context.MobileNumbers.ToList();

                        foreach (var phoneNumer in phoneNumers)
                        {
                            Console.Write($"{phoneNumer.PhoneNumber,-20}");
                            Console.Write($"Provider: {phoneNumer.ServiceProvider,-20}");

                            //----------------------------Check Criterias-----------------------------------
                            var validFormat = CheckStringFormat(phoneNumer.PhoneNumber);
                            if (validFormat != "OK")
                            {
                                Console.WriteLine(validFormat);
                                continue;
                            } 

                            var violated = CheckViolated(phoneNumer.PhoneNumber);
                            if (violated != "OK")
                            {
                                Console.WriteLine(violated);
                                continue;
                            }

                            var goodFengShui = CheckGoodFengShui(phoneNumer.PhoneNumber);
                            Console.WriteLine(goodFengShui);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"{ex.Message.ToString()}");
                }
                finally {
                    Console.ReadKey();
                }
        }


        public static string CheckStringFormat(string phoneNumber)
        {
            var ProviderPrefixes = new List<string>(){
                "086", "096", "097",
                "089", "090", "093",
                "088", "091", "094",
            };

            var proPrefixes = phoneNumber.Substring(0, 3);

            if (phoneNumber.Length !=10){
                return string.Format("Phone Number is have length equal to 10");
            }

            if (!ProviderPrefixes.Any(x => x == proPrefixes))
            {
                return string.Format("Prefixes of Phone Number should belong to as" + Environment.NewLine +
                            "- Viettel: 086xxx, 096xxx, 097xxx" + Environment.NewLine +
                            "- Mobi: 089xxx, 090xxx, 093xxx" + Environment.NewLine +
                            "- VinaPhone: 088xxx, 091xxx, 094xxx");
            }
            return "OK";
        }


        public static string CheckViolated(string phoneNumber) {
            var last2Char = phoneNumber.Substring(phoneNumber.Length - 2, 2);
            var violatedPairChar = new List<string> {   "00", "66",
                                                        "04", "45", "85", "27", "67",
                                                        "17", "57", "97", "98", "58",
                                                        "42", "82",
                                                        "69" };
            if (violatedPairChar.Contains(last2Char))
            {
                return "VIOLATED-LAST-PAIR";
            }
            else
            {
                return "OK";
            }
        }

        public static string CheckGoodFengShui(string phoneNumber)
        {
            //Total first 5 nums / Total last 5 nums: matches 1 in 2 conditions: 24/29 or 24/28
            var Sum5ofFist = phoneNumber.Take(5).Sum(x => Convert.ToDecimal(x.ToString()));
            var Sum5ofLast = phoneNumber.Reverse().Take(5).Reverse().Sum(x => Convert.ToDecimal(x.ToString()));
            var SumOfMatch = new List<decimal>{ (24M/29), (24M/28) };
            
            var violatedPairChar = new List<string> {   "00", "66",
                                                        "04", "45", "85", "27", "67",
                                                        "17", "57", "97", "98", "58",
                                                        "42", "82",
                                                        "69" };

            //Last nice pair of numbers: 19, 24, 26, 37, 34
            var last2Char = phoneNumber.Substring(phoneNumber.Length - 2, 2);

            var LastNicePair = new List<string> { "19", "24", "26", "37", "34" };
            

            if (SumOfMatch.Any(x => x.Equals(Sum5ofFist/Sum5ofLast)))
            {
                if (LastNicePair.Contains(last2Char))
                {
                    return "Good feng shui number !";
                }
            }
            return "Normal";
        }
    }
}
