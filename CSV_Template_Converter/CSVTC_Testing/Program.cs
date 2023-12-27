using Microsoft.VisualBasic.FileIO;
using System;
using System.Xml;

namespace CSVTC_Testing
{
    internal class Program
    {
        static string TEMPLATE_DELIMITER_START = "{{";
        static string TEMPLATE_DELIMITER_END = "}}";
        static void Main()
        {
            string csvFilePath = "D:\\Projects\\Alex\\CSV_Template_Converter\\CSV_Template_Converter\\CSVTC_Testing\\Data\\Input.csv";
            string outputFilePath = "D:\\Projects\\Alex\\CSV_Template_Converter\\CSV_Template_Converter\\CSVTC_Testing\\Data\\Output.xml";
            string templateFilePath = "D:\\Projects\\Alex\\CSV_Template_Converter\\CSV_Template_Converter\\CSVTC_Testing\\Data\\Template.xml";

            if (!File.Exists(csvFilePath) || !File.Exists(templateFilePath))
            {
                Console.WriteLine("No file found...");
                return;
            }

            string template = File.ReadAllText(templateFilePath);
            string output = "<output>" + Environment.NewLine;

            using (var parser = new TextFieldParser(csvFilePath))
            {
                parser.SetDelimiters(",");

                string[] headers = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    var values = parser.ReadFields();

                    if (values.Length >= headers.Length)
                    {
                        string currentEntry = new(template);

                        for (int i = 0; i < headers.Length; i++)
                        {
                            string propertyName = headers[i].Replace(" ", "");
                            currentEntry = currentEntry.Replace(TEMPLATE_DELIMITER_START + propertyName + TEMPLATE_DELIMITER_END, values[i]);
                        }
                        output += currentEntry;
                    }
                    else
                    {
                        Console.WriteLine("Missing values in CSV File...");
                        return;
                    }
                }
            }
            output += "</output>";

            File.WriteAllText(outputFilePath, output);

            Console.WriteLine("Sucessfully created output file: " + outputFilePath);
        }
    }
}
