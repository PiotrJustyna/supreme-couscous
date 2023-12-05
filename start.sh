#!/bin/zsh

docker compose --env-file ./.env up -d
docker attach "supreme-couscous-argon"
