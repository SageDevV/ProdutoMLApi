using AllClassificationApi;
using Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassificationController : ControllerBase
    {
        private readonly PredictionEnginePool<AllClassificationModel.ModelInput, AllClassificationModel.ModelOutput> _allPredictionEnginePool;
        private readonly PredictionEnginePool<ColorClassificationModel.ModelInput, ColorClassificationModel.ModelOutput> _colorPredictionEnginePool;
        private readonly PredictionEnginePool<ShapeClassificationModel.ModelInput, ShapeClassificationModel.ModelOutput> _shapePredictionEnginePool;
        private readonly PredictionEnginePool<ProductClassification.ModelInput, ProductClassification.ModelOutput> _productPredictionEnginePool;

        public ClassificationController(
            PredictionEnginePool<AllClassificationModel.ModelInput, AllClassificationModel.ModelOutput> allPredictionEnginePool,
            PredictionEnginePool<ColorClassificationModel.ModelInput, ColorClassificationModel.ModelOutput> colorPredictionEnginePool,
            PredictionEnginePool<ShapeClassificationModel.ModelInput, ShapeClassificationModel.ModelOutput> shapePredictionEnginePool,
            PredictionEnginePool<ProductClassification.ModelInput, ProductClassification.ModelOutput> productPredictionEnginePool)
        {
            _allPredictionEnginePool = allPredictionEnginePool;
            _colorPredictionEnginePool = colorPredictionEnginePool;
            _shapePredictionEnginePool = shapePredictionEnginePool;
            _productPredictionEnginePool = productPredictionEnginePool;
        }

        [HttpPost, Route("all-classification")]
        public IActionResult ObterAllClassification([FromBody] string urlBase64)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(urlBase64);

                var input = new AllClassificationModel.ModelInput
                {
                    ImageSource = byteArray,
                };

                var allClassificationModelResult = _allPredictionEnginePool.Predict(input);

                var labelScore = new LabelScore(allClassificationModelResult.PredictedLabel, allClassificationModelResult.Score);

                return Ok(labelScore);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost, Route("mixed-classification")]
        public IActionResult ObterMixedClassification([FromBody] string urlBase64)
        {
            try
            {
                List<LabelScore> labelScoreLista = new();

                byte[] byteArray = Convert.FromBase64String(urlBase64);

                var productClassification = new ProductClassification.ModelInput
                {
                    ImageSource = byteArray,
                };

                var productClassificationResult = _productPredictionEnginePool.Predict(productClassification);

                labelScoreLista.Add(new LabelScore(productClassificationResult.PredictedLabel, productClassificationResult.Score));

                var shapeClassificationModel = new ShapeClassificationModel.ModelInput
                {
                    ImageSource = productClassificationResult.ImageSource
                };

                var shapeClassificationModelResult = _shapePredictionEnginePool.Predict(shapeClassificationModel);

                labelScoreLista.Add(new LabelScore(shapeClassificationModelResult.PredictedLabel, shapeClassificationModelResult.Score));

                var colorClassificationModel = new ColorClassificationModel.ModelInput
                {
                    ImageSource = productClassificationResult.ImageSource
                };

                var colorClassificationModelResult = _colorPredictionEnginePool.Predict(colorClassificationModel);

                labelScoreLista.Add(new LabelScore(colorClassificationModelResult.PredictedLabel, colorClassificationModelResult.Score));

                var labelScore = new LabelScoreResult(labelScoreLista);

                return Ok(labelScore);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPost("color-classification")]
        public IActionResult ObterColorClassification([FromBody] string urlBase64)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(urlBase64);

                var input = new ColorClassificationModel.ModelInput
                {
                    ImageSource = byteArray,
                };

                var colorClassificationModelResult = _colorPredictionEnginePool.Predict(input);

                var labelScore = new LabelScore(colorClassificationModelResult.PredictedLabel, colorClassificationModelResult.Score);

                return Ok(labelScore);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("shape-classification")]
        public IActionResult ObterShapeClassification([FromBody] string urlBase64)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(urlBase64);

                var input = new ShapeClassificationModel.ModelInput
                {
                    ImageSource = byteArray,
                };

                var shapeClassificationModelResult = _shapePredictionEnginePool.Predict(input);

                var labelScore = new LabelScore(shapeClassificationModelResult.PredictedLabel, shapeClassificationModelResult.Score);

                return Ok(labelScore);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("product-classification")]
        public IActionResult ObterProductClassification([FromBody] string urlBase64)
        {
            try
            {
                byte[] byteArray = Convert.FromBase64String(urlBase64);

                var input = new ProductClassification.ModelInput
                {
                    ImageSource = byteArray,
                };

                var productClassificationModelResult = _productPredictionEnginePool.Predict(input);

                var labelScore = new LabelScore(productClassificationModelResult.PredictedLabel, productClassificationModelResult.Score);

                return Ok(labelScore);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
