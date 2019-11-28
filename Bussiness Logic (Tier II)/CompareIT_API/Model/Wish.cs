namespace CompareIT_API.Model
{
    public class Wish
    {
        public string URL { get; set; }

        public Wish(string URL)
        {
            this.URL = URL;
        }

        public string ToString()
        {
            return $"URL: {URL}";
        }
    }
}