using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using ControlModul.Handlers.Loger;

namespace ConcreteSampleTransformers
{
    public static class PropertiesManager
    {
        public static bool autosaveFunction { get; set; }
        public static char inputNfiSeparator { get; set; }
        public static char outputNfiSeparator { get; set; }

        public static Dictionary<char, string> numberFormatInfoMap = new Dictionary<char, string>();

        //Column (field) separator of input data
        public const char defaultFieldSeparator = ';';
        private const string tabSettingValue = "TAB";
        public static char inputFieldSeparator { get; set; } = defaultFieldSeparator;
        //Column (field) separator of generated CSV files
        public static char outputFieldSeparator { get; set; } = defaultFieldSeparator;
        public static Dictionary<char, string> fieldSeparatorMap = new Dictionary<char, string>();

        public static NumberFormatInfo CurrentNfo = NumberFormatInfo.CurrentInfo;

        public static string fileNameIN { get; set; }
        public static string fileNameOUT { get; set; }

        //Properities
        public static string inputDataPath { get; set; }
        public static string outputDataPath { get; set; }
        public static string reportDataPath { get; private set; } = "\\reports\\";
        public static string logsDataPath { get; private set; } = "\\logs\\";

        public const string fileTypeCSV = ".csv";
        public const string fileTypeDatabase = "SQL Database";
        public const string fileTypeAll = "CSV + SQL";
        public const string fileTypeReport = ".txt";
        public const string unknownFileType = ".dat";

        public static string connectionString { get; set; }

        public static string currentDirectoryPath { get; set; }

        public static TypesEnums.FileType ActualFileType;

        public static string GetOutputFileType {
            get {
                if (ActualFileType == TypesEnums.FileType.CSV) return fileTypeCSV;
                if (ActualFileType == TypesEnums.FileType.DATABASE) return fileTypeDatabase;
                if (ActualFileType == TypesEnums.FileType.ALL) return fileTypeAll;
                else return unknownFileType;
            }
        }

        public static void Init(){
            ProperitiesSamples.MapSamplesLabels();

            generateLanguageList();
            loadSettings();
            checkDirectory();
            initLoger();

            Console.WriteLine("ProperitiesManager initialized!");
        }

        private static void generateLanguageList()
        {
            numberFormatInfoMap.Clear();

            numberFormatInfoMap.Add(',', "Czech");
            numberFormatInfoMap.Add('.', "English");

            fieldSeparatorMap.Clear();

            fieldSeparatorMap.Add(';', "; (Semicolon)");
            fieldSeparatorMap.Add('\t', "TAB (Tabulator)");
            fieldSeparatorMap.Add(',', ", (Comma)");
        }

        //Field separator is stored as string, TAB is stored by name (whitespace is not safe in config XML)
        private static char FieldSeparatorFromSetting(string value)
        {
            if (string.IsNullOrEmpty(value)) return defaultFieldSeparator;
            if (value == tabSettingValue) return '\t';

            char separator = value[0];
            return fieldSeparatorMap.ContainsKey(separator) ? separator : defaultFieldSeparator;
        }

        private static string FieldSeparatorToSetting(char separator)
        {
            return separator == '\t' ? tabSettingValue : separator.ToString();
        }

        private static void checkDirectory(){
            currentDirectoryPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(currentDirectoryPath + reportDataPath)){ 
                Directory.CreateDirectory(currentDirectoryPath + reportDataPath);
            }
            if (!Directory.Exists(currentDirectoryPath + logsDataPath))
            {
                Directory.CreateDirectory(currentDirectoryPath + logsDataPath);
            }
        }

        private static void loadSettings(){
            inputNfiSeparator = Properties.Settings.Default.inputNfi;
            outputNfiSeparator = Properties.Settings.Default.outputNfi;
            inputFieldSeparator = FieldSeparatorFromSetting(Properties.Settings.Default.inputFieldSeparator);
            outputFieldSeparator = FieldSeparatorFromSetting(Properties.Settings.Default.outputFieldSeparator);
            autosaveFunction = Properties.Settings.Default.autosaveFunction;
            inputDataPath = Properties.Settings.Default.inputDataPath;
            outputDataPath = Properties.Settings.Default.outputDataPath;
            connectionString = Properties.Settings.Default.connectionString;
            ActualFileType = (TypesEnums.FileType)Properties.Settings.Default.outputFileType;

            Console.WriteLine("Settings load!");
        }

        private static void initLoger()
        {
            Loger.SetLogDir(currentDirectoryPath + logsDataPath);
        }

        public static void SaveSettings(){
            Properties.Settings.Default.inputNfi = inputNfiSeparator;
            Properties.Settings.Default.outputNfi = outputNfiSeparator;
            Properties.Settings.Default.inputFieldSeparator = FieldSeparatorToSetting(inputFieldSeparator);
            Properties.Settings.Default.outputFieldSeparator = FieldSeparatorToSetting(outputFieldSeparator);
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
