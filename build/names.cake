public static class Names {
    public const string SONARCUBE_API_TOKEN = "CI_CONAR_TOKEN";
    public const string SONARQUBE_URI = "CI_SONAR_URL";
    public const string NUGET_URI = "NUGET_REPO_URL";
    public const string NUGET_API_TOKEN = "NUGET_API_KEY";

    public const string PROJECT_ID = "WD.ValueValidators";

    public const string PROJECT_TITLE = "WebDucer value validation library";
    public static readonly string[] PROJECT_AUTHORS = {"Eugen [WebDucer] Richter"};
    public static readonly string[] PROJECT_OWNERS = {"Eugen [WebDucer] Richter"};
    public const string PROJECT_DESCRIPTION = @"WebDucer library for value validation on UI intefaces";
    public static readonly string PROJECT_COPYRIGHTS = string.Format("MIT - (c) {0} Eugen [WebDucer] Richter", DateTime.Now.Year);
    public static readonly string[] PROJECT_TAGS = {"Value", "Validation", "Validator", "WebDucer", "Rule"};

    public const string SONARQUBE_ORGANISATION = "webducer-oss";

    public const string DEFAULT_CONFIGURATION = "Release";
}