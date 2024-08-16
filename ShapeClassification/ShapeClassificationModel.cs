namespace ShapeClassification
{
    public class ShapeClassificationClass : IShapeClassificationClass
    {
        public ShapeClassificationClass()
        {

        }

        public void ObterClassificacaoFormato()
        {
            var imageBytes = File.ReadAllBytes(@"C:\Users\122589\OneDrive - Havan S.A\Área de Trabalho\ShapeClassification\Oval\circle-0.jpg");
            ShapeClassification.ModelInput sampleData = new ShapeClassification.ModelInput()
            {
                ImageSource = imageBytes,
            };

            var result = ShapeClassification.Predict(sampleData);
        }
    }
}
