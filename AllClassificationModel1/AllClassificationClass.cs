using AllClassificationModel1;

namespace AllClassification
{
    public class AllClassificationClass
    {
        public AllClassificationClass()
        {

        }

        public dynamic ObterAllClassification()
        {
            var imageBytes = File.ReadAllBytes(@"C:\Users\122589\OneDrive - Havan S.A\Área de Trabalho\Dataset\Dataset_train\fritadeira_cilindrico_preto\1.jpg");
            AllClassificationModel.ModelInput sampleData = new AllClassificationModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            var sortedScoresWithLabel = AllClassificationModel.PredictAllLabels(sampleData);
            Console.WriteLine($"{"Class",-40}{"Score",-20}");
            Console.WriteLine($"{"-----",-40}{"-----",-20}");

            var previsoesLista = new List<dynamic>();

            foreach (var sortedScoreWithLabel in sortedScoresWithLabel)
                previsoesLista.Add(sortedScoreWithLabel);

            return previsoesLista;
        }
    }
}