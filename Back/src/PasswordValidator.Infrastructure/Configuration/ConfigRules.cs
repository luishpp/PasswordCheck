namespace PasswordValidator.Infrastructure.Configuration;

public class RegexRule
{
    public string Pattern { get; set; }
}

public class RetryRules
{
    public int MaxRetryAttempts { get; set; }
    public TimeSpan RetryDelay  { get; set; }     
}
