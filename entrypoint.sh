#!/bin/zsh

# --- input ------------------------------------ #

WORKING_DIRECTORY=$1

# --- configuring git -------------------------- #

git config --global --add safe.directory "$WORKING_DIRECTORY"

# --- configuring aws cli ---------------------- #

aws configure set aws_access_key_id S3RVER

aws configure set aws_secret_access_key S3RVER

aws configure set region us-east-1

# --- populating secrets ----------------------- #

touch secrets.json

echo "{ \"username\": \"admin\", \"password\": \"password\" }" >> secrets.json

aws secretsmanager create-secret \
  --name "test-secret" \
  --secret-string "file://secrets.json" \
  --endpoint-url "http://localstack:4566" > \/dev/null

/bin/zsh