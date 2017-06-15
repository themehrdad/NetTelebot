namespace NetTelebot.Commands
{
    public class ParameterInfo
    {
        public string Name { get; set; }
        public ParameterTypes Type { get; set; }
        public string StaticPrompt { get; set; }
        public bool Optional { get; set; }
        public string EmptyValue { get; set; }

    }
}
