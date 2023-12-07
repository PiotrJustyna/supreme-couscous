module SecretsService.Workers

open System
open System.Threading
open System.Threading.Tasks
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Amazon.SecretsManager
open Amazon.SecretsManager.Model

type VanillaWorker(logger : ILogger<VanillaWorker>) =
  inherit BackgroundService()

  let _logger = logger

  override _.ExecuteAsync(stoppingToken : CancellationToken) =
    let f : Task<unit> = task {
      let secretsConfig = AmazonSecretsManagerConfig()
      secretsConfig.ServiceURL <- "http://localstack:4566"

      let client = new AmazonSecretsManagerClient("S3RVER", "S3RVER", secretsConfig)

      while not stoppingToken.IsCancellationRequested do
        let request = GetSecretValueRequest()
        request.SecretId <- "test-secret"

        let! mySecret = client.GetSecretValueAsync(request)
        _logger.LogInformation($"Worker running at: {DateTimeOffset.Now} - {mySecret.SecretString}")

        do! Task.Delay(5000)
    }

    f