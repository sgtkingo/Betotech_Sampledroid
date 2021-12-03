using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConcreteSampleTransformers
{
    public static class PropertiesManager
    {
        public static bool autosaveFunction { get; set; }
        public static char inputNfiSeparator { get; set; }
        public static char outputNfiSeparator { get; set; }

        public static Dictionary<char, string> numberFormatInfoMap = new Dictionary<char, string>();

        public static NumberFormatInfo CurrentNfo = NumberFormatInfo.CurrentInfo;

        public static string fileNameIN { get; set; }
        public static string fileNameOUT { get; set; }

        //Properities
        public static string inputDataPath { get; set; }
        public static string outputDataPath { get; set; }
        public static string reportDataPath { get; private set; }

        public const string fileTypeCSV = ".csv";
        public const string fileTypeDatabase = "SQL Database";
        public const string fileTypeReport = ".txt";
        public const string unknownFileType = ".dat";

        public static string connectionString { get; set; }

        public static string currentDirectoryPath { get; set; }

        public static TypesEnums.FileType ActualFileType;

        public static string GetOutputFileType {
            get {
                if (ActualFileType == TypesEnums.FileType.CSV) return fileTypeCSV;
                if (ActualFileType == TypesEnums.FileType.DATABASE) return fileTypeDatabase;
                else return unknownFileType;
            }
        }

        public static void Init(){
            ProperitiesSamples.MapSamplesLabels();

            generateLanguageList();
            loadSettings();
            checkDirectory();

            Console.WriteLine("ProperitiesManager initialized!");
        }

        private static void generateLanguageList()
        {
            numberFormatInfoMap.Clear();

            numberFormatInfoMap.Add(',', "Czech");
            numberFormatInfoMap.Add('.', "English");
        }

        private static void checkDirectory(){
            currentDirectoryPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(currentDirectoryPath + reportDataPath)){ 
                Directory.CreateDirectory(currentDirectoryPath + reportDataPath);
            }
        }

        private static void loadSettings(){
            inputNfiSeparator = Properties.Settings.Default.inputNfi;
            outputNfiSeparator = Properties.Settings.Default.outputNfi;
            autosaveFunction = Properties.Settings.Default.autosaveFunction;
            inputDataPath = Properties.Settings.Default.inputDataPath;
            outputDataPath = Properties.Settings.Default.outputDataPath;
            reportDataPath = Properties.Settings.Default.reportDataPath;
            connectionString = Properties.Settings.Default.connectionString;
            ActualFileType = (TypesEnums.FileType)Properties.Settings.Default.outputFileType;

            Console.WriteLine("Settings load!");
        }

        public static void SaveSettings(){
            Properties.Settings.Default.inputNfi = inputNfiSeparator;
            Properties.Settings.Default.outputNfi = outputNfiSeparator;
            Properties.Settings.Default.autosaveFunction = autosaveFunction;
            Properties.Settings.Default.inputDataPath = inputDataPath;
            Properties.Settings.Default.outputDataPath = outputDataPath;
            Properties.Settings.Default.outputFileType = (int)ActualFileType;

            Properties.Settings.Default.connectionString = connectionString;

            Properties.Settings.Default.Save();

            Console.WriteLine("Settings save!");
        }

        public static string GetSampleFileName() {
            return fileNameOUT+GetOutputFileType;
        }
        public static string GetSampleFilePath()
        {
            return outputDataPath + @"\" + GetSampleFileName();
        }

        public static string GetSampleFileNameByType(TypesEnums.SampleType sampleType)
        {
            return fileNameOUT + ProperitiesSamples.GetSampleExtensionNameByType(sampleType) + GetOutputFileType;
        }
        public static string GetSampleFilePathByType(TypesEnums.SampleType sampleType)
        {
            return outputDataPath + @"\" + GetSampleFileNameByType(sampleType);
        }
    }
}
