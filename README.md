# supreme-couscous

argon + secrets management

## secrets

```bash
touch secrets.json

echo "{ \"username\": \"admin\", \"password\": \"password\" }" >> secrets.json

aws secretsmanager create-secret --name test-secret-1 --secret-string file://secrets.json --endpoint-url "http://localstack:4566" > /dev/null

# optionally:
# aws secretsmanager list-secrets --endpoint-url "http://localstack:4566"
```

### questions

* [done] retrieval
* [wip] rotation
* [tbd] caching

## commands:

* [create-secret](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/secretsmanager/create-secret.html)
* [list-secrets](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/secretsmanager/list-secrets.html)
* [rotate-secret](https://awscli.amazonaws.com/v2/documentation/api/latest/reference/secretsmanager/rotate-secret.html)

## start

`./start.sh`

## exit

* `exit`:
  * detaches from argon shell
  * stops argon container
* [optional] `docker compose down`:
  * stops and removes the development stack
  * execute only if you want to get rid of the whole stack
  * you can keep the stack alive even when you exit and shut down the argon container and when you're ready to start argon again, running `./start.sh` is just going to start argon - the rest of the stack is already running.
  * your workflow could look like this: `./start.sh` -> exit -> `./start.sh` -> exit -> `./start.sh` -> `...` 

## resources

* [Retrieve secrets from AWS Secrets Manager](https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieving-secrets.html)
* [Retrieve AWS Secrets Manager secrets in .NET applications](https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieving-secrets_cache-net.html) - this is about caching as the caching package is the preferred/recommended way of interacting with the secrets manager.
* [Secrets Manager examples using AWS SDK for .NET](https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/csharp_secrets-manager_code_examples.html)
* [AmazonSecretsManagerClient](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SecretsManager/TSecretsManagerClient.html)
* [AmazonSecretsManagerConfig](https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SecretsManager/TSecretsManagerConfig.html)
* [Rotate AWS Secrets Manager secrets](https://docs.aws.amazon.com/secretsmanager/latest/userguide/rotating-secrets.html)