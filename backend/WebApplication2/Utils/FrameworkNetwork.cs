using Smile;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Commands;
using WebApplication2.Dictionary;
using WebApplication2.DTO;
using WebApplication2.Enums;

namespace WebApplication2.Utils
{
    public static class FrameworkNetwork
    {
        private static Network network;
        private static readonly double[] utility = new double[3] { 0.5, 0.5, 0.5 };

        public static List<FrameworksDTO> CreateAndProcessNetwork(FrameworkNetworkCommand command)
        {
            network = new Network();
            network.ReadFile(FrameworkNetworkDictionary.ProjectPath);
            var frameworks = GetFrameworks();
            SetProjectType(command.ProjectType);
            SetNodesDefinitions(
                GetFrameworkUtilityUsage(command.Usage),
                GetUtilityArray(command.Scalability),
                GetUtilityArray(command.Performance),
                GetUtilityArray(command.CommunitySupport),
                GetUtilityArray(command.LearningSpeed),
                GetUtilityArray(command.ImplementationCost),
                GetUtilityArray(command.Ecosystem),
                GetUtilityArray(command.SEO)
                );
            network.UpdateBeliefs();
            return GetFinalResult(frameworks);
        }

        private static double[] GetUtilityArray(object scale)
        {
            if (scale is ScaleDegreesType)
            {
                switch ((ScaleDegreesType)scale)
                {
                    case ScaleDegreesType.High:
                        return new double[] { 1.0, 0.5, 0.5 };
                    case ScaleDegreesType.Medium:
                        return new double[] { 0.5, 1.0, 0.5 };
                    case ScaleDegreesType.Low:
                        return new double[] { 0.5, 0.5, 1.0 };
                    default:
                        return utility;
                }
            }
            else if (scale is ScaleContentType)
            {
                switch ((ScaleContentType)scale)
                {
                    case ScaleContentType.Rich:
                        return new double[] { 1.0, 0.5, 0.5 };
                    case ScaleContentType.Medium:
                        return new double[] { 0.5, 1.0, 0.5 };
                    case ScaleContentType.Poor:
                        return new double[] { 0.5, 0.5, 1.0 };
                    default:
                        return utility;
                }
            }

            throw new ArgumentException($"Unsupported scale type: {scale}");
        }

        private static void SetProjectType(ProjectType project)
        {
            switch (project)
            {
                case ProjectType.Ecommerce:
                    network.SetEvidence(FrameworkNetworkDictionary.ProjectType, FrameworkNetworkDictionary.Ecommerce);
                    break;
                case ProjectType.Dashboard:
                    network.SetEvidence(FrameworkNetworkDictionary.ProjectType, FrameworkNetworkDictionary.Dashboard);
                    break;
                case ProjectType.Blog:
                    network.SetEvidence(FrameworkNetworkDictionary.ProjectType,FrameworkNetworkDictionary.Blog);
                    break;
                case ProjectType.CustomApplication:
                    network.SetEvidence(FrameworkNetworkDictionary.ProjectType, FrameworkNetworkDictionary.CustomApplication);
                    break;
                default:
                    throw new Exception("Invalid project type");
            }
        }

        private static FrameworksDTO GetFinalResult(List<string> frameworks)
        {
            var frameworksResult = new List<FrameworksDTO>();

            foreach (var framework in frameworks)
            {
                network.SetEvidence(FrameworkNetworkDictionary.FrameworkOutcome, framework);
                network.UpdateBeliefs();

                frameworksResult.Add(new FrameworksDTO
                {
                    Framework = framework,
                    Utility = network.GetNodeValue(FrameworkNetworkDictionary.FrameworkFactor)[0]
                });
            }

            return frameworksResult.OrderByDescending(u => u.Utility).ToList();
        }

        private static List<string> GetFrameworks()
        {
            var outcome = network.GetOutcomeCount(FrameworkNetworkDictionary.FrameworkOutcome);
            List<string> frameworks = new List<string>();

            for (var i = 0; i < outcome; i++)
            {
                frameworks.Add(network.GetOutcomeId(FrameworkNetworkDictionary.FrameworkOutcome, i));
            }
            return frameworks;
        }

        private static double[] GetFrameworkUtilityUsage(FrameworkUtilityUsage command)
        {
            return new double[]
            {
                (double)command.ScalabilityUsage,
                (double)command.PerformanceUsage,
                (double)command.CommunitySupportUsage,
                (double)command.LearningSpeedUsage,
                (double)command.ImplementationCostUsage,
                (double)command.EcosystemUsage,
                (double)command.SEOUsage
            };
        }

        private static void SetNodesDefinitions(double[] utilityFramework, double[] utilityScalability, double[] utilityPerformance, double[] utilityCommunitySupport, double[] utilityLearningSpeed, double[] utilityImplementationCost, double[] utilityEcosystem, double[] utilitySEO )
        {
            network.SetNodeDefinition(FrameworkNetworkDictionary.FrameworkFactor, utilityFramework);
            network.SetNodeDefinition(FrameworkNetworkDictionary.ScalabilityFactor, utilityScalability);
            network.SetNodeDefinition(FrameworkNetworkDictionary.PerformanceFactor, utilityPerformance);
            network.SetNodeDefinition(FrameworkNetworkDictionary.CommunitySupportFactor, utilityCommunitySupport);
            network.SetNodeDefinition(FrameworkNetworkDictionary.LearningSpeedFactor, utilityLearningSpeed);
            network.SetNodeDefinition(FrameworkNetworkDictionary.ImplementationCostFactor, utilityImplementationCost);
            network.SetNodeDefinition(FrameworkNetworkDictionary.EcosystemFactor, utilityEcosystem);
            network.SetNodeDefinition(FrameworkNetworkDictionary.SEOFactor, utilitySEO);
        }

    }
}