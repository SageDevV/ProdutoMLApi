namespace Api.Dto
{
    public class LabelScore
    {
        public LabelScore(string label, float[] scores)
        {
            Label = label;
            Scores = scores;
        }

        public string Label { get; set; }
        public float[] Scores { get; set; }
    }

}
