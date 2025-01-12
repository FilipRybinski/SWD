# Enums

## ProjectType
```json
{
    "Ecommerce",
    "Dashboard",
    "Blog",
    "CustomApplication"
}
```

## ScaleContentType
```json
{
    "Rich",
    "Medium",
    "Poor"
}
```

## ScaleDegreesType
```json
{
    "High",
    "Medium",
    "Low"
}
```

## UtilityUsageScaleType
```json
{
    "VeryLow",
    "Low",
    "Medium",
    "High",
    "VeryHigh"
}
```

# Example Post Schema
```json
{
  "ProjectType": "Dashboard",
  "Scalability": "High",
  "Performance": "Medium",
  "CommunitySupport": "High",
  "LearningSpeed": "Low",
  "ImplementationCost": "Medium",
  "Ecosystem": "Rich",
  "SEO": "High",
  "Usage": {
    "ScalabilityUsage": "High",
    "PerformanceUsage": "Medium",
    "CommunitySupportUsage": "VeryHigh",
    "LearningSpeedUsage": "Low",
    "ImplementationCostUsage": "Medium",
    "EcosystemUsage": "High",
    "SEOUsage": "VeryLow"
  }
}
```
