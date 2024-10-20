namespace WebApplication1
{
    public class TestData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Id, this.Name, this.IsComplete);
        }
    }
}
