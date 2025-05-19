public class CommandDto
{
    private String command;
    private Dictionary<String, List<String>> arguments;

    public CommandDto(String command, Dictionary<String, List<String>> arguments)
    {
        this.command = command;
        this.arguments = arguments;
    }

    public String GetCommand()
    {
        return command;
    }

    public List<String> GetParameter(String key)
    {
        return arguments[key];
    }

    public String GetFirstParameter(String key){
        return arguments[key][0];
    }

    public Dictionary<String, List<String>> GetArguments()
    {
        return arguments;
    }
}