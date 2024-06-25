using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AmongUsBlackScreenBootFix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the current Windows username
            string windowsUser = Environment.UserName;

            // Construct the path to the settings file
            string filePath = $@"C:\Users\{windowsUser}\AppData\LocalLow\Innersloth\Among Us\settings.amogus";

            // Open a console window for logging
            Console.WriteLine("Among Us Boot Fix Program");

            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"File found: {filePath}");

                    // Read the file content
                    string content = File.ReadAllText(filePath);

                    // Modify the content as needed
                    string modifiedContent = ModifyContent(content);

                    // Write the modified content back to the file
                    File.WriteAllText(filePath, modifiedContent);
                }
                else
                {
                    Console.WriteLine($"File not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Wait for user input before closing the console
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static string ModifyContent(string content)
        {
            // Parse the JSON content
            JObject jsonObject = JObject.Parse(content);

            // Remove the specified properties
            var multiplayer = jsonObject["multiplayer"];

            if ((string)multiplayer["normalHostOptions"] != ""
                || (string)multiplayer["normalSearchOptions"] != ""
                || (string)multiplayer["hideNSeekHostOptions"] != ""
                || (string)multiplayer["hideNSeekSearchOptions"] != "")
            {
                Console.WriteLine("File has been modified and saved successfully.");
                Console.WriteLine("Among Us black screen boot up has been fixed, enjoy!!!");

                multiplayer["normalHostOptions"]?.Replace(new JValue(""));
                multiplayer["normalSearchOptions"]?.Replace(new JValue(""));
                multiplayer["hideNSeekHostOptions"]?.Replace(new JValue(""));
                multiplayer["hideNSeekSearchOptions"]?.Replace(new JValue(""));
            }
            else
            {
                Console.WriteLine("File has already been modified.");
                Console.WriteLine("Among Us black screen boot up has been fixed, enjoy!!!");
            }

            // Serialize the modified JSON object back to a string
            return jsonObject.ToString();
        }
    }
}
