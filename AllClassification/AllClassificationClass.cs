namespace AllClassification
{
    public class AllClassificationClass
    {
        public AllClassificationClass()
        {

        }
        public void ObterAllClassificacoes()
        {
            var imageBytes = File.ReadAllBytes(@"C:\Users\122589\OneDrive - Havan S.A\Área de Trabalho\Dataset\Dataset_train\fritadeira_cilindrico_preto\1.jpg");
            AllClassificationModel.ModelInput sampleData = new AllClassificationModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            // Make a single prediction on the sample data and print results.
            var sortedScoresWithLabel = AllClassificationModel.PredictAllLabels(sampleData);
            Console.WriteLine($"{"Class",-40}{"Score",-20}");
            Console.WriteLine($"{"-----",-40}{"-----",-20}");

            foreach (var score in sortedScoresWithLabel)
            {
                Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
            }
        }
    }
}