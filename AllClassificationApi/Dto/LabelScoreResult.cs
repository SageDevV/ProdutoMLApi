namespace Api.Dto
{
    public class LabelScoreResult
    {
        public List<LabelScore> LabelScoreLista { get; set; }

        public LabelScoreResult(List<LabelScore> labelScoreLista)
        {
            LabelScoreLista = labelScoreLista;
        }
    }
}
