namespace ProductClassification
{
    public class ProductClasificationClass : IProductClasificationClass
    {
        public ProductClasificationClass()
        {
                
        }

        public void ObterClassificacaoProduto()
        {
            var imageBytes = File.ReadAllBytes(@"C:\Users\122589\OneDrive - Havan S.A\Área de Trabalho\ProductClassification\Fritadeira\fritadeira_1.jpg");
            ProductClassificationModel.ModelInput sampleData = new ProductClassificationModel.ModelInput()
            {
                ImageSource = imageBytes,
            };

            var result = ProductClassificationModel.Predict(sampleData);
        }
    }
}
