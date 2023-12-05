#!/bin/zsh

USER_NAME="argon"
HOME_DIRECTORY="/home/$USER_NAME"
WORKING_DIRECTORY="$HOME_DIRECTORY/code"
CERTIFICATE_DIRECTORY="$HOME/.ssh/"

docker run \
  -it \
  -v "$(pwd):$WORKING_DIRECTORY" \
  -v "$CERTIFICATE_DIRECTORY:$HOME_DIRECTORY/.ssh:ro" \
  -w "$WORKING_DIRECTORY" \
  --rm "piotrjustyna/argon:1.1" "./entrypoint.sh" "$WORKING_DIRECTORY"