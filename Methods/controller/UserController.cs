using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Methods.services;

namespace Methods.controllers
{
    public class UserController
    {
        private CommandParsingService parser;
        private AllowedTemperatureChecker allowedTemperatureChecker;
        private ControlWorkCalculator controlWorkCalculator;
        private DiscountPriceCalculator discountPriceCalculator;
        private PersonWeightCalculator personWeightCalculator;
        private RectangleAreaService rectangleAreaService;
        private SalesStatisticsCalculator salesStatisticsCalculator;
        private TaxiPriceCalculator taxiPriceCalculator;
        private TemperatureChecker temperatureChecker;
        private TournamentResultCalculator tournamentResultCalculator;
        private TriangeCalcualtor triangeCalcualtor;
        public UserController()
        {
            parser = new CommandParsingService();
            allowedTemperatureChecker = new AllowedTemperatureChecker();
            controlWorkCalculator = new ControlWorkCalculator();
            discountPriceCalculator = new DiscountPriceCalculator();
            personWeightCalculator = new PersonWeightCalculator();
            rectangleAreaService = new RectangleAreaService();
            salesStatisticsCalculator = new SalesStatisticsCalculator();
            taxiPriceCalculator = new TaxiPriceCalculator();
            temperatureChecker = new TemperatureChecker();
            tournamentResultCalculator = new TournamentResultCalculator();
            triangeCalcualtor = new TriangeCalcualtor();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    CommandDto dto = parser.ParseCommand(Console.ReadLine());
                    switch (dto.GetCommand())
                    {
                        case "exit":
                            return;
                        case "help":
                            Help();
                            break;
                        default:
                            System.Console.WriteLine("Unknown command");
                            break;
                        case "alltemp":
                            CheckTemp(dto);
                            break;
                        case "controlwork":
                            CalculateControlWork(dto);
                            break;
                        case "discount":
                            CalculateDiscountPrice(dto);
                            break;
                        case "weight":
                            CalculateWeight(dto);
                            break;
                        case "area":
                            CalculateArea(dto);
                            break;
                        case "sales":
                            CalculateWeeklySales(dto);
                            break;
                        case "taxi":
                            CalculateTaxiPrice(dto);
                            break;
                        case "antemp":
                            AnaliseTemaperature(dto);
                            break;
                        case "tournament":
                            AnaliseTournament(dto);
                            break;
                        case "triangle":
                            CalculateTrianglePerimeter(dto);
                            break;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Data);
                    System.Console.WriteLine(e.Message);
                }
            }
        }

        private void Help()
        {
            System.Console.WriteLine("exit - leave");
            System.Console.WriteLine("help - get this message");
            System.Console.WriteLine("alltemp - check allowed temperature: -min {decimal} -max {decimal} -current {decimal}");
            System.Console.WriteLine("controlwork - calculate control work grades: -grades {integers, }");
            System.Console.WriteLine("discount - calculate discount price: -price {decimal} -discount {decimal}");
            System.Console.WriteLine("weight - analize person weigth changes: -weights {decimals, }");
            System.Console.WriteLine("area - calculate rectange area: -l {decimal} -w {decimal}");
            System.Console.WriteLine("sales - analize weekly sales: -sales {decimals, = 7}");
            System.Console.WriteLine("taxi - calculate taxi price: -distance {decimal} -price {decimal} -night {decimal}");
            System.Console.WriteLine("antemp - analize temperature: -temp {decimals}");
            System.Console.WriteLine("tournament - analize tournament: -time {integers}");
            System.Console.WriteLine("triangle - calculate triangle perimeter: -l {decimals, = 3}");
        }

        private void CheckTemp(CommandDto dto)
        {
            double min = ParseDouble(dto.GetFirstParameter("-min"));
            double max = ParseDouble(dto.GetFirstParameter("-max")); 
            allowedTemperatureChecker.CheckTemp(ParseDouble(dto.GetFirstParameter("-current")), ref min, ref max);
        }

        private void CalculateControlWork(CommandDto dto)
        {
            int[] arr = ParseIntArr(dto.GetParameter("-grades"));
            int maxResults, midResults, minResults, max, min, average;
            controlWorkCalculator.CalculateControlWork(arr,
            out maxResults, out midResults, out minResults,
            out max, out min, out average);
            System.Console.WriteLine("Grades: " + String.Join(", ", arr)
            + $"\nMax results: {maxResults}, mid results: {midResults}, min results {minResults}"
            + $"\nMaximum result: {max}, minimum result: {min}, average result: {average}");
        }

        private void CalculateDiscountPrice(CommandDto dto)
        {
            double fullPrice = ParseDouble(dto.GetFirstParameter("-price"));
            double discount = ParseDouble(dto.GetFirstParameter("-discount"));
            double result = discountPriceCalculator.CalculateDiscountPrice(fullPrice, ref discount);
            System.Console.WriteLine($"The price of {fullPrice} with discount of {discount} is {result}");
        }

        private void CalculateWeight(CommandDto dto)
        {
            double[] arr = ParseDoubleArr(dto.GetParameter("-weights"));
            PersonWeightCalculator.PersonWeights personWeights;
            personWeightCalculator.CalculateWeight(arr, out personWeights);
            System.Console.WriteLine("Person weight measurments: " + String.Join(", ", arr)
            + $"\nIncreased: {personWeights.increased}, decreased: {personWeights.decreased}, not changed: {personWeights.notChanged}"
            + $"\nMax increase: {personWeights.maxIncrease}, max decrease: {personWeights.maxDecrease}, average weight: {personWeights.average}");
        }

        private void CalculateArea(CommandDto dto)
        {
            double length = ParseDouble(dto.GetFirstParameter("-l"));
            double width = ParseDouble(dto.GetFirstParameter("-w"));
            double result = rectangleAreaService.CalculateArea(ref length, ref width);
            System.Console.WriteLine($"Area of reactangle: {result}, length and width after changes: {length}, {width}");
        }

        private void CalculateWeeklySales(CommandDto dto)
        {
            double[] arr = ParseDoubleArr(dto.GetParameter("-sales"));
            int maxSales, midSales, minSales;
            double max, min, average;
            salesStatisticsCalculator.CalculateWeeklySales(arr,
            out maxSales, out midSales, out minSales,
            out max, out min, out average);
            System.Console.WriteLine("Weekly sales: " + string.Join(", ", arr)
            + $"\nAmount of: max sales: {maxSales}, mid sales: {midSales}, min sales: {minSales}"
            + $"\nMax sale: {max}, min sale: {min}, average sale: {average}");
        }

        private void CalculateTaxiPrice(CommandDto dto)
        {
            double distance = ParseDouble(dto.GetFirstParameter("-distance"));
            double pricePerKm = ParseDouble(dto.GetFirstParameter("-price"));
            double nightMultiplier = ParseDouble(dto.GetFirstParameter("-night"));
            double result = taxiPriceCalculator.CalculateTaxiPrice(ref distance, ref pricePerKm, ref nightMultiplier);
            System.Console.WriteLine($"Total price of the ride is {result}"
            + $"\nDistance {distance}km * price {pricePerKm} * night multiplier {nightMultiplier}");
        }

        private void AnaliseTemaperature(CommandDto dto)
        {
            double[] arr = ParseDoubleArr(dto.GetParameter("-temp"));
            double max, min, average;
            int negative, positive;
            temperatureChecker.AnaliseTemaperature(arr, out min, out max,
            out negative, out positive, out average);
            System.Console.WriteLine("Temperature checks: " + string.Join(", ", arr)
            + $"\nMax recorded temperature: {max}"
            + $"\nMin recorded temperature: {min}"
            + $"\nAverage recorded temperature: {average}"
            + $"\nAmount of neagtive: {negative}"
            + $"\nAmount of positive: {positive}");
        }

        private void AnaliseTournament(CommandDto dto)
        {
            int[] arr = ParseIntArr(dto.GetParameter("-time"));
            int less60, between60n120, more120,
            min, max, average;
            tournamentResultCalculator.AnaliseTournament(arr,
            out less60, out between60n120, out more120,
            out min, out max, out average);
            System.Console.WriteLine("Tournament times: " + string.Join(", ", arr)
            + $"\nTime > 120: {more120}, 120 > time > 60: {between60n120}, time < 60: {less60}"
            + $"\nMinimal time: {min}, Max time: {max}, Average: {average}");
        }

        private void CalculateTrianglePerimeter(CommandDto dto)
        {
            double[] arr = ParseDoubleArr(dto.GetParameter("-l"));
            double a = arr[0], b = arr[1], c = arr[2];
            double result = triangeCalcualtor.CalculateTrianglePerimeter(ref a, ref b, ref c);
            System.Console.WriteLine($"Perimeter of triangle with sides {a} + {b} + {c} = {result}");
        }

        private int ParseInt(string s)
        {
            int i = 0;
            if (!int.TryParse(s, out i))
            {
                throw new FormatException("Entered value is not an integer");
            }
            return i;
        }

        private double ParseDouble(string s)
        {
            double d = 0;
            if (!double.TryParse(s, out d))
            {
                throw new FormatException("Entered value is not a decimal");
            }
            return d;
        }

        private int[] ParseIntArr(List<string> s)
        {
            int[] arr = new int[s.Count];
            for (int i = 0; i < s.Count; i++)
            {
                arr[i] = ParseInt(s[i]);
            }
            return arr;
        }

        private double[] ParseDoubleArr(List<string> s)
        {
            double[] arr = new double[s.Count];
            for (int i = 0; i < s.Count; i++)
            {
                arr[i] = ParseDouble(s[i]);
            }
            return arr;
        }
    }
}