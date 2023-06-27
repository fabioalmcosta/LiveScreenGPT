namespace LiveScreenGPT.Data
{
    public class Language
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
