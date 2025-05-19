
using System.Text.RegularExpressions;

public class CommandParsingService
{
    public void PrintResult(String command)
    {
        CommandDto dto = ParseCommand(command);
        Console.WriteLine($"Command: {dto.GetCommand()}");
        foreach (var arg in dto.GetArguments())
        {
            Console.WriteLine($"Argument: {arg.Key}, Parameters: {string.Join(", ", arg.Value)}");
        }
    }

    // made by mistral because im lazy
    public CommandDto ParseCommand(string commandLine)
    {
        String command = "";
        var parts = Regex.Matches(commandLine, @"[^\s""]+|""([^""]*)""");

        if (parts.Count > 0)
        {
            command = parts[0].Value.Trim('"');
        }

        var arguments = new Dictionary<string, List<string>>();

        for (int i = 1; i < parts.Count; i++)
        {
            var part = parts[i].Value.Trim('"');

            if (part.StartsWith("--"))
            {
                // Handle double dash parameters
                foreach (char c in part.Substring(2))
                {
                    AddArgument(arguments, $"-{c}", new List<string>());
                }
            }
            else if (part.StartsWith("-"))
            {
                // Handle single dash arguments
                var argName = part;
                var parameters = new List<string>();

                // Check for parameters
                while (i + 1 < parts.Count && !parts[i + 1].Value.StartsWith("-"))
                {
                    parameters.Add(parts[++i].Value.Trim('"'));
                }

                AddArgument(arguments, argName, parameters);
            }
        }


        return new CommandDto(command, arguments);
    }

    private void AddArgument(Dictionary<string, List<string>> arguments, string argName, List<string> parameters)
    {
        if (!arguments.ContainsKey(argName))
        {
            arguments[argName] = new List<string>();
        }
        arguments[argName].AddRange(parameters);
    }
}
