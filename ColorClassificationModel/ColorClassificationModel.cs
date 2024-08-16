namespace ColorClassification
{
    public class ColorClassificationClass : IColorClassificationClass
    {

        public ColorClassificationClass()
        {
                
        }
        public void ObterClassificacaoCor()
        {
            var imageBytes = File.ReadAllBytes(@"C:\Users\122589\OneDrive - Havan S.A\Área de Trabalho\ColorClassification\Amarelo\1.jpg");
            ColorClassificationModel.ModelInput sampleData = new ColorClassificationModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            var result = ColorClassificationModel.Predict(sampleData);
        }
    }
}
