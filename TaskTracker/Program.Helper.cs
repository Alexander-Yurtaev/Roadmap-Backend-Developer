public partial class Program
{
    public static (string command, string, string) ParseArgs(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("Args must have least one value.");
        }

        string command = args[0];
        string arg1 = string.Empty;
        string arg2 = string.Empty;

        if (args.Length > 1)
        {
            arg1 = args[1];
        }

        if (args.Length > 2)
        {
            arg2 = args[2];
        }

        return (command, arg1, arg2);
    }

    public static string ToUpperFirstLetter(string source)
    {
        if (string.IsNullOrEmpty(source))
            return string.Empty;
        // convert to char array of the string
        char[] letters = source.ToCharArray();
        // upper case the first char
        letters[0] = char.ToUpper(letters[0]);
        // return the array made of the new char array
        return new string(letters);
    }
}