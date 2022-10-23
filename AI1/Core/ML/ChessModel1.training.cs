﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace AI1
{
    public partial class ChessModel1
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"Kc", @"Kc"),new InputOutputColumnPair(@"Rc", @"Rc"),new InputOutputColumnPair(@"kc2", @"kc2")})      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Kr", @"Kr"),new InputOutputColumnPair(@"Rr", @"Rr"),new InputOutputColumnPair(@"kr2", @"kr2")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Kc",@"Rc",@"kc2",@"Kr",@"Rr",@"kr2"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(@"result", @"result"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastForest(new FastForestBinaryTrainer.Options(){NumberOfTrees=4,FeatureFraction=1F,LabelColumnName=@"result",FeatureColumnName=@"Features"}), labelColumnName: @"result"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(@"PredictedLabel", @"PredictedLabel"));

            return pipeline;
        }
    }
}
